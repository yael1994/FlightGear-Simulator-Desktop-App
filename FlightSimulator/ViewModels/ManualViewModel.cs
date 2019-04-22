using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class ManualViewModel : BaseNotify
    {
        private ManualModel model;

        public double Throttle
        {
            get { return model.Throttle; }
            set { model.Throttle = value; }
        }

        public double Aileron
        {
            get { return model.Aileron; }
            set
            { model.Aileron = value; }
        }
        public double Elevator
        {
            get { return model.Elevator; }
            set { model.Elevator = value; }
        }

        public double Rudder
        {
            get { return model.Rudder; }
            set { model.Rudder = value; }
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

    

