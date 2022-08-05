using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BrevTools.AlbionEvents
{
    public class SayChatEvent
    {
        public string Sender;
        public string Message;

        public SayChatEvent(Dictionary<byte, object> parameters)
        {
            try
            {
                if (parameters.ContainsKey(0)) Sender = parameters[0].ToString();
                if (parameters.ContainsKey(1)) Message = parameters[1].ToString();
            } catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
