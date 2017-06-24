using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.Domain.Entities
{
    public class DroneState
    {
        public double XAngle { get; set; }
        public double YAngle { get; set; }
        public double ZAngle { get; set; }
        public double Speed { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }
    }
}
