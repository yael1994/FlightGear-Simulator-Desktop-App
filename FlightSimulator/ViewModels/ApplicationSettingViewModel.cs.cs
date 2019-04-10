using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    public class ApplicationSettingViewModel : INotifyPropertyChanged
    {
        public string VM_FlightServerIP {
            get { return modelSetting.FlightServerIP; }
        }
        public int VM_FlightInfoPort {
            get { return modelSetting.FlightInfoPort; }
        }
        public int VM_FlightCommandPort {
            get { return modelSetting.FlightCommandPort; }
        }
        private ISettingsModel modelSetting;
        public ApplicationSettingViewModel(ISettingsModel model)
        {
            this.modelSetting = model;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}