using BLESniffer.WPF.Common;
using BLESniffer.WPF.Model;
using BLESniffer.WPF.Service;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Windows.Input;
using Windows.Devices.Bluetooth.Advertisement;

namespace BLESniffer.WPF.ViewModel
{
    /// <summary>
    /// Filtering is not implemented
    /// </summary>
    public class FiltersViewModel:BaseViewModel
    {
        private ManufacturerData selectedManufacturer;
        public ManufacturerData SelectedManufacturer 
        {
            get => selectedManufacturer;
            set
            {
                selectedManufacturer = value;
                OnPropertyChanged(nameof(SelectedManufacturer));
            }
        }
        public BluetoothDataManagerService bluetoothData { get; private set; }
        readonly BluetoothService bluetoothService;

        private ICommand _updateFilterCommand;
        public ICommand UpdateFilterCommand
        {
            get
            {
                if (_updateFilterCommand is null)
                {
                    _updateFilterCommand = new RelayCommand(UpdateFilter);
                }
                return _updateFilterCommand;
            }
        }

        private BLEWatcherFilter Filter = new BLEWatcherFilter();

        public FiltersViewModel()
        {
            bluetoothData = App.AppContainer.GetService(typeof(BluetoothDataManagerService)) as BluetoothDataManagerService;
            bluetoothService = App.AppContainer.GetService(typeof(BluetoothService)) as BluetoothService;
        }


        private void UpdateFilter(object obj)
        {
            System.Collections.IList items = (System.Collections.IList)obj;
            var collection = items.Cast<ManufacturerData>();
            Filter.ManufacturersFilters.Clear();
            foreach (var item in collection)
            {
                var manu = new BluetoothLEManufacturerData();
                manu.CompanyId = item.ManufacturerID;
                Filter.ManufacturersFilters.Add(manu);
            }
            bluetoothService.AddFilters(Filter);
        }


    }
}
