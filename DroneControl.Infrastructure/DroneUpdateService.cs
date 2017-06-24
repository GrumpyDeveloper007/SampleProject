using DroneControl.Domain.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.Infrastructure
{
    public class DroneUpdateService
    {

        public delegate void StatusUpdateReceivedFromDroneEvent(DroneState newState);
        public event StatusUpdateReceivedFromDroneEvent StatusUpdateReceivedFromDrone;

        const int _10Seconds = 10000;

        private static readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        System.Threading.Thread _BackgroundWorker;

        public bool Running { get; set; }


        private void thread()
        {
            while (Running)
            {
                DroneState newState = new DroneState();
                StatusUpdateReceivedFromDrone?.Invoke(newState);


                System.Threading.Thread.Sleep(_10Seconds);
            }
        }

        public void StartService()
        {
            if (Running == false)
            {
                _logger.Log(LogLevel.Info, "Background service started");


                _BackgroundWorker = new System.Threading.Thread(new System.Threading.ThreadStart(thread));
                Running = true;
                _BackgroundWorker.Start();
            }
        }



        public void SendGotoCommandToDrone(DroneState state)
        {

        }


    }
}
