using BrevTools.Models;
using BrevTools.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BrevTools.Views
{
    /// <summary>
    /// Interaction logic for PlayerGearView.xaml
    /// </summary>
    public partial class PlayerGearView : UserControl
    {
        public PlayerGearViewModel playerGearViewModelObject = new PlayerGearViewModel();
        public PlayerGearView()
        {
            InitializeComponent();
            _PlayerGearView = this;
            playerGearViewModelObject.LoadPlayerGear();
            dataGrid.ItemsSource = playerGearViewModelObject.PlayerGear;
        }

        public static PlayerGearView _PlayerGearView;

        public void UpdateDataTable()
        {
            dataGrid.ItemsSource = playerGearViewModelObject.PlayerGear;
        }
    }
}
