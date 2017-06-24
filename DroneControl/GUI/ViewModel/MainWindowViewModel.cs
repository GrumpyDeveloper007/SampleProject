using DroneControl.Domain.Entities;
using DroneControl.GUI.Helpers;
using DroneControl.GUI.Service;
using DroneControl.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DroneControl.GUI.Model
{
    class MainWindowViewModel : ViewModelBase
    {
        DroneStateViewModel _SelectedDroneState;
        DroneStateViewModel _NewDroneState;
        ObservableCollection<DroneStateViewModel> _DroneStateHistory;
        DroneUpdateService _DroneUpdateService;

        public IEnumerable<DroneStateViewModel> DroneStateHistory { get { return _DroneStateHistory; } }
        public DroneStateViewModel SelectedDroneState { get { return _SelectedDroneState; } set { _SelectedDroneState = value; _NewDroneState.Update(value); OnPropertyChanged("SelectedDroneState"); } }
        public DroneStateViewModel NewDroneState { get { return _NewDroneState; } set { _NewDroneState = value; OnPropertyChanged("NewDroneState"); } }

        private ICommand _SendNewDroneCommand;

        public ICommand SendNewDroneCommand { get { return _SendNewDroneCommand; } set { _SendNewDroneCommand = value; } }
        public MainWindowViewModel()
        {
            SendNewDroneCommand = new RelayCommand(SendNewDroneCommandLocal, param => true);
            _DroneUpdateService = new DroneUpdateService();
            _DroneUpdateService.StatusUpdateReceivedFromDrone += _DroneUpdateService_StatusUpdateReceivedFromDrone;

            _NewDroneState = new DroneStateViewModel();
            _DroneStateHistory = new ObservableCollection<DroneStateViewModel>();
            DroneStateViewModel a = new DroneStateViewModel();
            a.XAngle = 1;
            _DroneStateHistory.Add(a);
            SelectedDroneState = a;
            a = new DroneStateViewModel();
            a.XAngle = 2;
            _DroneStateHistory.Add(a);

            _DroneUpdateService.StartService();
        }

        private void _DroneUpdateService_StatusUpdateReceivedFromDrone(DroneState newState)
        {
            DispatchService.Invoke(() =>
            {
                if (_DroneStateHistory != null)
                    _DroneStateHistory.Add(new DroneStateViewModel(newState));
            });
            // todo: add to list, thread safe
        }

        public void Close()
        {
            _DroneUpdateService.Running = false;
        }

        private void SendNewDroneCommandLocal(object obj)
        {
            _DroneUpdateService.SendGotoCommandToDrone(NewDroneState.Model);
        }

    }
}
