using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace FlightSimulator.Model
{
    class Client : IClient
    {
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
        TcpClient m_client = new TcpClient();

        

        public void Connect(string ip, int port)
        {
            m_client.Connect(ep);
            //TODO: delete this
            Console.WriteLine("You are connected");
        }

        public void Disconnect()
        {
            m_client.Close();
        }

        public string Read()
        {
        // Get result from server
        int result = reader.ReadInt32();
        Console.WriteLine("Result = {0}", result);
    }

        public void Write(string command)
        {
        Console.Write("Please enter a number: ");
        int num = int.Parse(Console.ReadLine());
        writer.Write(num);
    }
    }
}


