using System.Net.Sockets;

namespace FlightSimulator.Model
{
    internal interface IClientHandler<T>
    {
       T HandleClient(TcpClient client);
    }
}