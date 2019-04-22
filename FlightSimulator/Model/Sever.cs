using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class Server:IServer
    {
        private SymboleTable symboleTable;
        private TcpListener listener;
        private TcpClient client;
        private IPEndPoint ep;
        private IClientHandler<string[]> ch;
        public static Server instance;
        public Server(int port)
        {
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            ch = new ClientHandler();
            listener = new TcpListener(ep);
            listener.Start();
            symboleTable = SymboleTable.getInstance();
        }

        public void Start()
        {
                        Console.WriteLine("Waiting for connections...");
                     client = listener.AcceptTcpClient();
                    Console.WriteLine("Got new connection");
            Read();
        }
        

        public void Read()
        {

            while (true)
            {
                NetworkStream stream = client.GetStream();
                // Buffer to store the response bytes.
                Byte[] data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                //Console.WriteLine("Received: {0}", responseData);
                string[] retStr = responseData.Split(',');
                symboleTable.Set("rudder",Convert.ToDouble (retStr[21]));
                symboleTable.Set("throttle", Convert.ToDouble(retStr[23]));
                symboleTable.Set("aileron", Convert.ToDouble(retStr[19]));
                symboleTable.Set("elevators", Convert.ToDouble(retStr[20]));
                symboleTable.Set("lon", Convert.ToDouble(retStr[0]));
                symboleTable.Set("lat", Convert.ToDouble(retStr[1]));
         
                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();
                // Send the message to the connected TcpServer. 
                // stream.Write(data, 0, data.Length);


            }
            

        }
        //To close the Accept Blocker
        public void Stop()
        {
            listener.Stop();
        }

    }
    }
        

