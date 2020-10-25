using BLESniffer.WPF.Service;

namespace BLESniffer.WPF.Model
{
    public class ManufacturerData
    {
        readonly ManufacturerDataService manufacturerDataService;
        public ManufacturerData() => manufacturerDataService = App.AppContainer.GetService(typeof(ManufacturerDataService)) as ManufacturerDataService;
        public string ManufacturerName
        {
            get
            {
                return manufacturerDataService.GetManufacturerName(ManufacturerID).Replace("/n","");
            }
        }

        public ushort ManufacturerID { get; set; }


    }
}
