using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class ManualViewModel:BaseNotify
    {
        private ManualModel model;

        public double Throttle
        {
            get { return model.Throttle; }
        }

        public double Aileron
        {
            get { return model.Aileron; }
        }
        public double Elevator
        {
            get { return model.Elevator; }
        }

        public double Rudder
        {
            get { return model.Rudder; }
        }

        public ManualViewModel()
        {
            model = new ManualModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
        }
    }
}
