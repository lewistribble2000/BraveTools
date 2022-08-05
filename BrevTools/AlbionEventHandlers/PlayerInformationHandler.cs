using BrevTools.AlbionEvents;
using BrevTools.Models;
using BrevTools.ViewModel;
using BrevTools.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BrevTools.AlbionEventHandlers
{
    public class PlayerInformationHandler
    {
        private HttpClient httpClient = new HttpClient();

        
        public async Task OnActionAsync(PlayerInformationEvent value)
        {
            if (value.Items.Count == 0)
            {
                return;
            }
            Dictionary<string, string> items = new Dictionary<string, string>();
            int i = 0;
            foreach(short itemID in value.Items)
            {
                items.Add(i.ToString(), itemID.ToString());
                i++;
            }
            HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1:8000/incorrect-build", new FormUrlEncodedContent(items));
            HttpHeaders headerValues = response.Headers;
            try
            {
                var header = headerValues.GetValues("Reason").First();
                var itemList = headerValues.GetValues("Items").ToList();
                var itemImageList = itemList.Select(item => string.Format("https://render.albiononline.com/v1/item/{0}.png", item)).ToArray();

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    PlayerGearView._PlayerGearView.playerGearViewModelObject.AddGear(new PlayerGear { Mainhand = itemImageList[0], Offhand = itemImageList[1], Head = itemImageList[2], Chest = itemImageList[3], Shoes = itemImageList[4], Bag = itemImageList[5], Cape = itemImageList[6], Mount= itemImageList[7], Name = value.Name, Reason = header });

                });
                
            } catch(Exception e)
            {
                if(e is IndexOutOfRangeException)
                {
                    //Ignore IndexOutOfRangeException, does not crash functionality and is due to packet information being sent incomplete upon
                    //specific game interaction circumstances
                }
                else
                {
                    throw new Exception("Exception Message: " + e.Message + "\n" + "Exception Type: " + e.GetType().ToString());
                }
            }
            await Task.CompletedTask;
        }
    }
}
