using BLESniffer.WPF.Model;
using BLESniffer.WPF.Service;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace BLESniffer.WPF.ViewModel
{
    public class DisplayRawDataViewModel : BaseViewModel
    {
        readonly BluetoothService _bluetoothService;

        public ObservableCollection<BLEModel> Data { get; set; } = new ObservableCollection<BLEModel>();

        public DisplayRawDataViewModel(BluetoothService bluetoothService)
        {
            _bluetoothService = bluetoothService;
            _bluetoothService.NewDateRecieved += _bluetoothService_NewDateRecieved;
        }

        private void _bluetoothService_NewDateRecieved(object _sender, BLEModel _bleModel)
        {
            Application.Current.Dispatcher?.Invoke(() =>
            {
                Data.Add(_bleModel);
            }, DispatcherPriority.Normal);
        }
    }
}
