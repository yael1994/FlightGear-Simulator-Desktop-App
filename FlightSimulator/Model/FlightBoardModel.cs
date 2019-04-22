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
        private static FlightBoardModel instance = null;
        private IServer server;
        private IClient client;
        public event PropertyChangingEventHandler PropertyChanging;
        private FlightBoardModel() { }
        
        public string [] Values { get; private set; }
        public static FlightBoardModel getInstance()
        {
            if(instance == null)
            {
                instance = new FlightBoardModel();
            }
            return instance;
        }
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
              //  Console.WriteLine(lon);
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
             set
            {
                lat = value;
               // Console.WriteLine(lat);
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
                    Values = server.Read();

                    Lon = Convert.ToDouble( Values[0]);
                    Lat = Convert.ToDouble(Values[1]);
                }
                /*while (true)
                {
                    string [] values = server.Read();
                    if(!values[0].Equals("nan"))
                    Lon = Double.Parse(values[0]);
                    if (!values[1].Equals("nan"))
                        Lat = Double.Parse(values[1]);

                   Console.WriteLine(Lon);
                    Console.WriteLine(Lat);
                }*/
            });
            thread.Start();
         
            client = Client.getInstance();
            client.Connect(model.FlightServerIP, model.FlightCommandPort);
        }       
    }
}
