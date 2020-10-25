using System;
using System.Collections.Generic;
using Windows.Devices.Bluetooth.Advertisement;

namespace BLESniffer.WPF.Model
{
    public class BLEWatcherFilter
    {
        public List<BluetoothLEManufacturerData> ManufacturersFilters { get; set; } = new List<BluetoothLEManufacturerData>();
        public List<Guid> GuidFilters { get; set; } = new List<Guid>();
        public List<BluetoothLEAdvertisementDataSection> PatternFilters { get; set; } = new List<BluetoothLEAdvertisementDataSection>();
    }
}
