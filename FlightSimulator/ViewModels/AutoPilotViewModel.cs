using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;


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
            Task task = new Task(() => { 
            string[] lines =TextToSend.Split('\n');
            Byte[] buffer = new byte[1024];
            for (int i = 0; i < lines.Length; i++)
            {
                buffer = Encoding.ASCII.GetBytes(lines[i]);
                if (lines[i].EndsWith("\n"))
                {
                    lines[i].Remove(lines[i].Length - 1);
                }
                Client.getInstance().Write(lines[i]);
                Thread.Sleep(2000);

            }
            Array.Clear(lines, 0, lines.Length);
            });task.Start();


        }

     
    }
    }

