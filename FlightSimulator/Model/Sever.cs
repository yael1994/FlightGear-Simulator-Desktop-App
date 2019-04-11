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
    class Server
    {
        private TcpListener listener;
        private TcpClient m_client;
        private IPEndPoint ep;
        private IClientHandler ch;
        private NetworkStream strean;
        private BinaryReader reader;
        private BinaryWriter writer;

        public Server(int port)
        {
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            ch = new ClientHandler();
           
        }

        public void Start()
        {
            listener = new TcpListener(ep);
            listener.Start();            Console.WriteLine("Waiting for connections...");            Thread thread = new Thread(() => {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("Got new connection");           
                        ch.HandleClient(client);
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
        public void Stop()
        {
            listener.Stop();
        }

    }

    
    }
        
