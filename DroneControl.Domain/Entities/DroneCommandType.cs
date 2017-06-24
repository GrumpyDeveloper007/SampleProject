using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.Domain.Entities
{
    public enum DroneCommandType
    {
        SetWaypoint,
        EnableAutoPilot,
        DisableAutoPilot,
        GoTo,
    }
}
