using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : BaseNotify
    {
        public string TextToSend { get; set; }
        public Action WhiteBackgroundAction { get; set; }

        private ICommand _oKCommand;
        public ICommand OKCommand
        {
            get
            {
                return _oKCommand ?? (_oKCommand = new CommandHandler(() => OnOK()));
            }
        }
        private void OnOK()
        {
            WhiteBackgroundAction();
            Client.getInstance().Write(TextToSend);
            

        }
    }
    }

