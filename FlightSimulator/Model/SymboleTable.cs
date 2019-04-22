using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class SymboleTable
    {
        private Dictionary<string, double> SymboleMap;
        private static SymboleTable instance;
        private SymboleTable() {
            SymboleMap = new Dictionary<string, double>();
            SymboleMap.Add("rudder", 0);
            SymboleMap.Add("throttle", 0);
            SymboleMap.Add("aileron", 0);
            SymboleMap.Add("elevators", 0);
            SymboleMap.Add("lon", 0);
            SymboleMap.Add("lat", 0);

        }

        public static SymboleTable getInstance()
        {
            if (instance == null)
            {
                instance = new SymboleTable();
            }
            return instance;
        }

        public void Set(string key, double value)
        {
            if (SymboleMap.ContainsKey(key))
            {
                SymboleMap[key] = value;
            }
        }

        public double Get(string key)
        {
            if (SymboleMap.ContainsKey(key))
            {
                return SymboleMap[key];
            }
            return 0;
        }
    }
}
