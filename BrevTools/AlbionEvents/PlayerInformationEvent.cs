using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;

namespace BrevTools.AlbionEvents
{
    public class PlayerInformationEvent
    {
        public string Name;
        public string GuildName;
        public List<short> Items = new List<short>();

        public PlayerInformationEvent(Dictionary<byte, object> parameters)
        {
            try
            {
                object itemsObject;
                object name;
                object guildName;
                if(parameters.TryGetValue(1, out name))
                {
                    this.Name = name.ToString();
                }

                if(parameters.TryGetValue(8, out guildName))
                {
                    this.GuildName = guildName.ToString();
                }

                if (parameters.TryGetValue(33, out itemsObject))
                {
                    IEnumerable itemEnumerable = itemsObject as IEnumerable;
                    foreach (object itemID in itemEnumerable)
                    {
                        Items.Add((short)itemID);
                    }
                }
            }
            catch (Exception e)
            {
                if (e is InvalidCastException)
                {
                    //Ignore InvalidCastException, all data correctly is put through
                    //extra packet information is sent in the short that is not required and unpredicatable 
                }
                else
                {
                    //Log any other unknown error
                    throw new Exception("Unknown Exception Thrown: "
                       + "\n  Type:    " + e.GetType().Name
                       + "\n  Message: " + e.Message);
                }
            }
        }
    }
}
