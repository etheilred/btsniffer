using BLESniffer.WPF.Common;
using BLESniffer.WPF.Service;
using System.Threading.Tasks;
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
                Task.Run(async () =>
                {
                    _bluetoothService.ChangeScanningState();
                    await Task.Delay(100);
                    OnPropertyChanged(nameof(ScanningState));
                });
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

        /// <summary>
        /// bla bla bla
        /// </summary>
        /// <param name="arg">Optional parameter</param>
        private async void ExportRawData(object arg)
        {
            var exportService = App.AppContainer.GetService(typeof(ExportService)) as ExportService;
            Info = await exportService.ExportData();
            OnPropertyChanged(nameof(Info));
        }
    }
}
