using DroneControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.GUI.Model
{
    public class DroneStateViewModel : ViewModelBase
    {
        DroneState _state;


        public double XAngle { get { return _state.XAngle; } set { _state.XAngle = value; OnPropertyChanged("XAngle"); } }
        public double YAngle { get { return _state.YAngle; } set { _state.YAngle = value; OnPropertyChanged("YAngle"); } }
        public double ZAngle { get { return _state.ZAngle; } set { _state.ZAngle = value; OnPropertyChanged("ZAngle"); } }
        public double Speed { get { return _state.Speed; } set { _state.Speed = value; OnPropertyChanged("Speed"); } }
        public double Longitude { get { return _state.Longitude; } set { _state.Longitude = value; OnPropertyChanged("Longitude"); } }
        public double Latitude { get { return _state.Latitude; } set { _state.Latitude = value; OnPropertyChanged("Latitude"); } }
        public double Altitude { get { return _state.Altitude; } set { _state.Altitude = value; OnPropertyChanged("Altitude"); } }

        public DroneState Model { get { return _state; } }

        public DroneStateViewModel()
        {
            _state = new DroneState();
        }

        public DroneStateViewModel(DroneState newState)
        {
            _state = newState;
        }

        public void Update(DroneStateViewModel model)
        {
            XAngle = model.XAngle;
            YAngle = model.YAngle;
            ZAngle = model.ZAngle;
            Speed = model.Speed;
            Longitude = model.Longitude;
            Latitude = model.Latitude;
            Altitude = model.Altitude;
        }
    }
}
