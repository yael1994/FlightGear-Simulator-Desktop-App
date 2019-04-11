﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ClientHandler : IClientHandler<string []>
    {
        
        public string [] HandleClient(TcpClient client)
        {
            byte[] myReadBuffer = new byte[1024];
            NetworkStream stream = client.GetStream();
            StringBuilder myCompleteMessage = new StringBuilder();
            int numberOfBytesRead = 0;
            if (stream.CanRead)
            {
                do
                {
                    stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                    myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                } while (stream.DataAvailable);
            }
            String myString = myCompleteMessage.ToString();
            string [] values = myString.Split(',');
            return values;
        }
    }
}