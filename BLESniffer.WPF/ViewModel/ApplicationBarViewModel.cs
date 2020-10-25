using BLESniffer.WPF.Common;
using BLESniffer.WPF.Service;
using System.Windows.Input;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace BLESniffer.WPF.ViewModel
{
    public class ApplicationBarViewModel : BaseViewModel
    {
        readonly BluetoothService _bluetoothService;

        public bool ScanningState
        {
            get => _bluetoothService.CurrentScanningState;
            set
            {
                _bluetoothService.ChangeScanningState();
                OnPropertyChanged(nameof(ScanningState));
            }
        }

        private ICommand exportCommand;
        public ICommand ExportData
        {
            get
            {
                if (exportCommand is null)
                    exportCommand = new RelayCommand(ExportRawData);
                return exportCommand;
            }
        }

        public string Info { get;private set; }

        public ApplicationBarViewModel(BluetoothService bluetoothService)
        {
            _bluetoothService = bluetoothService;
        }

        private async void ExportRawData(object arg)
        {
            var exportService = App.AppContainer.GetService(typeof(ExportService)) as ExportService;
            Info = await exportService.ExportData();
            OnPropertyChanged(nameof(Info));
        }
    }
}
