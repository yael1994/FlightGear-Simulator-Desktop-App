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
    class FlightBoardModel : IFlightModel
    {
        private FlightBoardViewModel flightVM;
        private IServer server;
        private IClient client;
        private Boolean isStop;
        public event PropertyChangingEventHandler PropertyChanging;

        public FlightBoardModel()
        {
        }

        private double lon = 0;
        public double Lon
        {
            get
            {
                return lon;
            }
            set
            {
                lon = value;
                
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
                    Lon = Double.Parse(values[0]);
                    Lat = Double.Parse(values[1]);

                    Console.WriteLine(Lon);
                    Console.WriteLine(Lat);
                }
            });
            thread.Start();
            client = Client.getInstance();
            client.Connect(model.FlightServerIP, model.FlightCommandPort);
        }

        public void DrawRoud()
        {
            throw new NotImplementedException();
        }
               
    }
}
