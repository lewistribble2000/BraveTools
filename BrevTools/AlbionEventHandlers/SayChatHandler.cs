using BrevTools.AlbionEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrevTools.AlbionEventHandlers
{
    public class SayChatHandler
    {
        public async Task OnActionAsync(SayChatEvent value)
        {
            //TODO: Do something with chat info

            await Task.CompletedTask;
        }
    }
}
