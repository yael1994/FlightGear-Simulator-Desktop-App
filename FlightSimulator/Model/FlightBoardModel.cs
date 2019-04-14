using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class FlightBoardModel : BaseNotify
    {
        private FlightBoardViewModel flightVM;
        private IServer server;
        private IClient client;
        public event PropertyChangingEventHandler PropertyChanging;

        private double lon = 0;
        public double Lon
        {
            get
            {
                return lon;
            }
            private set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        private double lat;


        public double Lat
        {
            get
            {
                return lat;
            }
            private set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        public void Connect()
        {
            ISettingsModel model = ApplicationSettingsModel.Instance;
            server = new Server(model.FlightInfoPort);
           server.Start();
            Thread thread = new Thread(() =>
            {
                
                while (true)
                {
                    string [] values = server.Read();
                    if(!values[0].Equals(""))
                    Lon = Double.Parse(values[0]);
                    if (!values[1].Equals(""))
                        Lat = Double.Parse(values[1]);

                 //   Console.WriteLine(Lon);
                   // Console.WriteLine(Lat);
                }
            });
            thread.Start();
            client = Client.getInstance();
            client.Connect(model.FlightServerIP, model.FlightCommandPort);
        }       
    }
}
