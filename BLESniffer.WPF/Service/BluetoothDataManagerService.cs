using BLESniffer.WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BLESniffer.WPF.Service
{
    public class BluetoothDataManagerService
    {
        readonly BluetoothService bluetoothService;
        public List<BLEModel> Data { get; set; } = new List<BLEModel>();
        public List<ManufacturerData> Manufacturers { get; set; } = new List<ManufacturerData>();
        public ObservableCollection<Guid> Guids { get; set; } = new ObservableCollection<Guid>();
        public BluetoothDataManagerService()
        {
            bluetoothService = App.AppContainer.GetService(typeof(BluetoothService)) as BluetoothService;
            bluetoothService.NewDateRecieved += BluetoothService_NewDateRecieved;

        }

        private void BluetoothService_NewDateRecieved(object _sender, BLEModel _bleModel)
        {
            Data.Add(_bleModel);
            if (!Manufacturers.ToList().Any(x => x.ManufacturerID == _bleModel.Manufacturer.ManufacturerID))
                Manufacturers.Add(_bleModel.Manufacturer);
        }
    }
}
