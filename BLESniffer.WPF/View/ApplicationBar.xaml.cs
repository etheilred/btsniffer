using BLESniffer.WPF.Service;
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

namespace BLESniffer.WPF.View
{
    /// <summary>
    /// Interaction logic for ApplicationBar.xaml
    /// </summary>
    public partial class ApplicationBar : UserControl
    {
        public ApplicationBar()
        {
            InitializeComponent();
            var bluetoothService = App.AppContainer.GetService(typeof(BluetoothService)) as BluetoothService;
            DataContext = new ViewModel.ApplicationBarViewModel(bluetoothService);
        }
    }
}
