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
        private double throttle;
        public double Throttle
        {
            get
            {
                return SymboleTable.getInstance().Get("throttle");
            }
            set
            {
                SymboleTable.getInstance().Set("throttle",value);
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
                SymboleTable.getInstance().Set("aileron",value);
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
                SymboleTable.getInstance().Set("elevators",value);
                NotifyPropertyChanged("Elevator");
            }
        }

        private double rudder;
        public double Rudder
        {
            get
            {
                return SymboleTable.getInstance().Get("rudder");
            }
            set
            {
                SymboleTable.getInstance().Set("rudder",value);
                NotifyPropertyChanged("Rudder");
            }
        }

        public ManualModel()
        {
        
        }

    }
}

