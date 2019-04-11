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

        public void Connect()
        {
            throw new NotImplementedException();
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
