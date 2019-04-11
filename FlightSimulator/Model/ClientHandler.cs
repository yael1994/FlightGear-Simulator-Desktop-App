using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ClientHandler : IClientHandler
    {
        public void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            
            
        }
    }
}
