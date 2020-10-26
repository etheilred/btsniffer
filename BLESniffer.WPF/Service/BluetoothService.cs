using BLESniffer.WPF.Model;
using System;
using System.Linq;
using System.Windows.Documents;
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

        private void Watcher_Received(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            var manufacturerDataCollection = args.Advertisement.ManufacturerData.ToList();
            foreach (var item in manufacturerDataCollection)
            {
                var result = new BLEModel();
                result.Manufacturer = new ManufacturerData() { ManufacturerID = item.CompanyId };
                result.Data = ReadBuffer(item.Data);
                result.ID = args.BluetoothAddress;
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

        public void AddFilters(BLEWatcherFilter filter)
        {
            watcher.Stop();
            watcher.AdvertisementFilter.Advertisement.ServiceUuids.Clear();
            watcher.AdvertisementFilter.Advertisement.ManufacturerData.Clear();

            foreach (var item in filter.GuidFilters)
                watcher.AdvertisementFilter.Advertisement.ServiceUuids.Add(item);
            foreach (var item in filter.ManufacturersFilters)
            {
                var manufacturerData = new BluetoothLEManufacturerData();
                manufacturerData.CompanyId = item.CompanyId;
                watcher.AdvertisementFilter.Advertisement.ManufacturerData.Add(manufacturerData);
            }

            watcher.Start();
        }

        public bool CurrentScanningState
        {
            get
            {
                if (watcher.Status == BluetoothLEAdvertisementWatcherStatus.Stopped)
                    return false;
                return true;
            }
        }
        public void ChangeScanningState()
        {
            if (CurrentScanningState)
                watcher.Stop();
            else
                watcher.Start();
        }
    }
}
