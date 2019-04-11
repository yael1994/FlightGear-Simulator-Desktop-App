using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    interface IFlightModel
    {
        void Connect();
        void Setting();
        void DrawRoud();
    }
}
