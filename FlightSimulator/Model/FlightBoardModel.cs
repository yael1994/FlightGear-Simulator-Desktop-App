using FlightSimulator.Model.Interface;
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
        public event PropertyChangedEventHandler PropertyChanged;
        
        private IServer server;
        private IClient client;

        public void Connect()
        {
            ISettingsModel model = ApplicationSettingsModel.Instance;
            server = new Server(model.FlightInfoPort);
      
            server.Start();
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
