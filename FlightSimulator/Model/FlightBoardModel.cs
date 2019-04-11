using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class FlightBoardModel : IFlightModel
    {
        private FlightBoardViewModel flightVM;
        private IServer server;
        private IClient client;

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
                NotifyPropertyChanged("Lat");
            }
        }
        public void StartRead(String ip, int port)
        {
            server.openServer(ip, port);
            new Thread(delegate ()
            {
                while (true)
                {
                    String[] data = server.readFromClient();
                    Lon = Convert.ToDouble(data[0]);
                    Lat = Convert.ToDouble(data[1]);
                    Console.WriteLine("from client:1:" + lon);
                    Console.WriteLine("from client:2:" + lat);
                }
            }).Start();
        }


        public void Connect()
        {
            server = new Server();
           ISettingsModel model = ApplicationSettingsModel.Instance;
            server.Start(model.FlightInfoPort);
        //    client.Connect(model.FlightServerIP, model.FlightCommandPort);
        }

        public void DrawRoud()
        {
            throw new NotImplementedException();
        }
        public void Setting()
        {
           
        }
    }
}
