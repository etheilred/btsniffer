using BLESniffer.WPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BLESniffer.WPF.Service
{
    public class ExportService
    {
        readonly BluetoothDataManagerService _dataManagerService;

        public ExportService(BluetoothDataManagerService dataManagerService) => _dataManagerService = dataManagerService;

        public async Task<string> ExportData()
        {
            if (_dataManagerService.Data.Count() == 0)
                return "No data to export";
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            ((IInitializeWithWindow)(object)savePicker).Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            savePicker.SuggestedFileName = $"Export_{DateTime.Now.ToShortDateString()}";

            StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                try
                {
                    await FileIO.WriteTextAsync(file, PrepareDataForExport());
                    return "File " + file.Name + " was saved.";
                }
                catch
                {
                    return "File " + file.Name + " couldn't be saved.";
                }
            }
            else
                return "Operation cancelled.";
        }

        private string PrepareDataForExport()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("ID,ManufacturerName,RawData");
            foreach (var item in _dataManagerService.Data)
            {
                builder.AppendLine($"{item.ID},{item.Manufacturer.ManufacturerName},{item.DataDisplay}");
            }
            return builder.ToString();
        }
    }
}
