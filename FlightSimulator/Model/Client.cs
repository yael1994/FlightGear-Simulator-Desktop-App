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
        private TcpClient tcpClient;
       public Client() { }

        public void Connect(string ip, int port)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(ip,port);
        
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public string Read()
        {
            throw new NotImplementedException();
        }

        public void Write(string command)
        {
            NetworkStream stream = tcpClient.GetStream();
            Byte[] buffer = new byte[1024];
            buffer = Encoding.ASCII.GetBytes(command);
            stream.Write(buffer, 0, buffer.Length);

            Byte[] data = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);
        }
    }
}


