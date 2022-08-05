using BrevTools.Models;
using BrevTools.Views;
using System.Collections.ObjectModel;

namespace BrevTools.ViewModel
{
    public class PlayerGearViewModel
    {
        public ObservableCollection<PlayerGear> PlayerGear { get; set; }

        public void LoadPlayerGear()
        {
            ObservableCollection<PlayerGear> PlayerGear = new ObservableCollection<PlayerGear>();
            this.PlayerGear = PlayerGear;
        }

        public void AddGear(PlayerGear gear)
        { 
            PlayerGear.Add(gear);
            PlayerGearView._PlayerGearView.UpdateDataTable();
        }
    }
}
