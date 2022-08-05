using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BraveClient.network;
using SharpPcap;
using System.Threading;
using NLog;
using PacketDotNet;
using BraveClient.enums;

namespace Brave_Client
{
    class MainHandler
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private static PacketParser _parser;
        private static SocketServer _server;
        private static List<Thread> _deviceThreads;

        public static async Task<int> Main(string ip = "127.0.0.1", int port = 9999, bool debug = false)
        {
            SetupLogger();

            logger.Info("Sniffer Started! Setting up...");

            SetupServer(ip, port);
            SetupParser(false);
            SetupDevices();
            logger.Info("Setup Complete!");

            return 0;
        }
        private static void SetupLogger()
        {
            NLog.LogManager.Setup().LoadConfiguration(builder =>
            {
                var layout = "[${level}][${time}] : ${message}";
                builder.ForLogger().WriteToConsole(layout: layout, encoding: Encoding.UTF8);
                builder.ForLogger().WriteToFile(fileName: "log.txt", layout: layout, encoding: Encoding.UTF8);
            });
        }

        private static void SetupServer(string ip, int port)
        {
            logger.Info("Setting up server...");
            _server = new SocketServer(ip, port);
        }

        private static void SetupParser(bool debug)
        {
            logger.Info("Setting up parser...");
            _parser = new PacketParser();

            // Debugging settings, useful to find/learn about certain packets.
            _parser.Debug = true;
            _parser.DebugPacketValues = true;
            _parser.DebugEventCode = (short)EventCode.PlayerInformation;
            _parser.DebugRequestCode = (short)OperationCode.NONE;
            _parser.DebugResponseCode = (short)OperationCode.NONE;

            // Filter certain packets that we don't care about.
            // Mostly used for debugging, but this does filter them out completely.
            //Currently leave all unfiltered, event codes updated and unfound yet

            /*_parser.FilterCode(PacketType.EVENT, (short)EventCode.Move);
            _parser.FilterCode(PacketType.REQUEST, (short)OperationCode.Move);
            _parser.FilterCode(PacketType.EVENT, (short)EventCode.ChatMessage);
            _parser.FilterCode(PacketType.EVENT, (short)EventCode.Unknown144);
            _parser.FilterCode(PacketType.EVENT, (short)EventCode.InCombatStateUpdate);
            _parser.FilterCode(PacketType.REQUEST, (short)OperationCode.ClientHardwareStats);
            _parser.FilterCode(PacketType.EVENT, (short)EventCode.GuildMemberUpdate);
            _parser.FilterCode(PacketType.EVENT, (short)EventCode.GuildUpdate);
            _parser.FilterCode(PacketType.RESPONSE, (short)OperationCode.AllianceInfo);
            _parser.FilterCode(PacketType.REQUEST, (short)OperationCode.AllianceInfo);
            _parser.FilterCode(PacketType.EVENT, (short)EventCode.AllianceInfo);*/

            // Register packets.
            // Later we should use reflection to automatically register everything in TCC.Sniffer.Templates.

            _parser.OnHandlePacket(_server.SendData);
        }

        private static void SetupDevices()
        {
            logger.Info("Setting up devices...");

            _deviceThreads = new List<Thread>();

            foreach (var device in CaptureDeviceList.Instance)
            {
                Thread thread = new Thread(() =>
                {
                    device.OnPacketArrival += new PacketArrivalEventHandler(PacketHandler);
                    device.Open(DeviceModes.Promiscuous, 1000);
                    device.StartCapture();

                    //Console.WriteLine($"Listening on {device.Description}");
                    logger.Info("Listening to device: {0}", device.Description);
                });

                thread.Start();
                _deviceThreads.Add(thread);
            }
        }

        private static void PacketHandler(object s, PacketCapture e)
        {
            var raw = e.GetPacket();
            var packet = Packet.ParsePacket(raw.LinkLayerType, raw.Data).Extract<UdpPacket>();

            if (packet == null) return;
            if (packet.SourcePort != 5056 && packet.DestinationPort != 5056 && packet.SourcePort != 4535) return;

            _parser.ReceivePacket(packet.PayloadData);
        }
    }
}
