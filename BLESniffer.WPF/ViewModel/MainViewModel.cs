using BLESniffer.WPF.Model;
using BLESniffer.WPF.Service;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Storage.Streams;

namespace BLESniffer.WPF.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<BLEModel> Data { get; set; } = new ObservableCollection<BLEModel>();

        readonly BluetoothService bluetoothService;
        public MainViewModel()
        {
            bluetoothService = App.AppContainer.GetService(typeof(BluetoothService)) as BluetoothService;
            bluetoothService.NewDateRecieved += BluetoothService_NewDateRecieved;
        }

        private void BluetoothService_NewDateRecieved(object _sender, BLEModel _bleModel)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Data.Add(_bleModel);
            }, DispatcherPriority.Normal);
        }
    }
}
