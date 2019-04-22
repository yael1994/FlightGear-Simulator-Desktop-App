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
                return SymboleTable.getInstance().Get("throttle");
            }
            set
            {
                Client.getInstance().Write("set" + pathTable["throttle"] + value);
                NotifyPropertyChanged("Throttle");
            }
        }

        private double aileron;
        public double Aileron
        {
            get
            {
                return SymboleTable.getInstance().Get("aileron");
            }
            set
            {
                Client.getInstance().Write("set" + pathTable["aileron"] + value);
                NotifyPropertyChanged("Aileron");
            }
        }

        private double elevator;
        public double Elevator
        {
            get
            {
                return SymboleTable.getInstance().Get("elevators");
            }
            set
            {
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

