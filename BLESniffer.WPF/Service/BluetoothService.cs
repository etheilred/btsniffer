using BLESniffer.WPF.Model;
using System;
using System.Linq;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Storage.Streams;

namespace BLESniffer.WPF.Service
{
    public delegate void AdvertismentDataRecievedHandler(object _sender, BLEModel _bleModel);
    public class BluetoothService
    {
        private BluetoothLEAdvertisementWatcher watcher;

        public event AdvertismentDataRecievedHandler NewDateRecieved;

        public BluetoothService()
        {
            watcher = new BluetoothLEAdvertisementWatcher();
            watcher.Received += Watcher_Received;
            watcher.Start();
        }

        private void Watcher_Received(BluetoothLEAdvertisementWatcher _sender, BluetoothLEAdvertisementReceivedEventArgs _args)
        {
            var manufacturerDataCollection = _args.Advertisement.ManufacturerData.ToList();
            foreach (var item in manufacturerDataCollection)
            {
                var result = new BLEModel();
                result.Company = item.CompanyId;
                result.Data = ReadBuffer(item.Data);
                result.ID = _args.BluetoothAddress;
                NewDateRecieved?.Invoke(this, result);
            }
        }

        private byte[] ReadBuffer(IBuffer theBuffer)
        {
            byte[] result = new byte[theBuffer.Length];
            using (var dataReader = DataReader.FromBuffer(theBuffer))
            {
                dataReader.ReadBytes(result);
            }
            return result;
        }
    }
}
