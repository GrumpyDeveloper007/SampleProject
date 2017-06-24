
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.Domain.Entities
{
    public class DroneCommand
    {
        public DroneCommandType Command { get; set; }
        public List<DroneState> DestinationData { get; set; } 

        public DroneCommand ()
        {
            DestinationData = new List<DroneState>();
        }
    }
}
