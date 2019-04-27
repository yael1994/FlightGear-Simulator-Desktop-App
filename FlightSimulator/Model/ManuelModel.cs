using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ManualModel:BaseNotify
    {
        private Dictionary<string, string> pathTable;
        private double throttle;
        public double Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                Client.getInstance().Write("set" + pathTable["aileron"] + value);
                NotifyPropertyChanged("Throttle");
            }
        }

        private double aileron;
        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                Client.getInstance().Write("set" + pathTable["aileron"] + value);
                NotifyPropertyChanged("Aileron");
            }
        }

        private double elevator;
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = value;
                Client.getInstance().Write("set" + pathTable["elevators"] + value);
                NotifyPropertyChanged("Elevator");
            }
        }

        private double rudder;
        public double Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;

                Client.getInstance().Write("set"+ pathTable["rudder"] + value);
                NotifyPropertyChanged("Rudder");
            }
        }

        //Declare on path table to send a "set" to the simulator
        public ManualModel()
        {
            pathTable = new Dictionary<string, string>();
            pathTable.Add("rudder", " controls/flight/rudder ");
            pathTable.Add("throttle", " controls/engines/current-engine/throttle ");
            pathTable.Add("aileron", " controls/flight/aileron ");
            pathTable.Add("elevators", " controls/flight/elevator ");

        }

    }
}

