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
        private TcpListener listener;
        private TcpClient m_client;
        private IPEndPoint ep;
        private IClientHandler<string[]> ch;

        public Server(int port)
        {
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            ch = new ClientHandler();
            listener = new TcpListener(ep);
            listener.Start();
        }

        public void Start()
        {
                        Console.WriteLine("Waiting for connections...");            Thread thread = new Thread(() => {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("Got new connection");
                        while (true)
                        {
                            Read(client);
                        }
                       
                    }
                    catch (SocketException)
                    {
                        
                        break;
                    }
                }
                Console.WriteLine("Server stopped");
            });
            thread.Start();
        }

        public void Read(TcpClient client)
        {
            
            NetworkStream stream = client.GetStream();
            // Buffer to store the response bytes.
           Byte[] data = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            Byte[] send = System.Text.Encoding.ASCII.GetBytes("rec");

            // Get a client stream for reading and writing.
            //  Stream stream = client.GetStream();

           

            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}","rec");


        }
        public void Stop()
        {
            listener.Stop();
        }

    }
    }
        
