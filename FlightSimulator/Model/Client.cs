using FlightSimulator.Model.Interface;
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
    class Client 
    {
        private TcpClient tcpClient;
        private static Client instance = null;
       private NetworkStream stream;
        private BinaryWriter writer;
        private Client() { }
    
        public static Client getInstance()
        {

            if(instance == null)
            {
                instance = new Client();
            }
            return instance;
        }
        
        public void Connect(string ip, int port)
        {
           
            tcpClient = new TcpClient();
            Task task = new Task(() =>
            {
                while (!tcpClient.Connected) { 
                try
                {
                 //  Console.WriteLine("trying to connect..");
                    tcpClient.Connect(ip, port);

                }
                catch (SocketException )
                {
                        continue;

                }
            }
              //  Console.WriteLine("new Connection");
                stream = tcpClient.GetStream();
                writer = new BinaryWriter(stream);
            });
            task.Start();
            task.Wait();
          


        }

        public void Disconnect()
        {
            tcpClient.Dispose();
        }

    
            public  void Write(string  command)
        {

            string commands = command.ToString();
           Task t = new Task(() => { 
           // Console.Write("Starting TO write...");
          
            Byte[] buffer = new byte[1024];
                buffer = Encoding.ASCII.GetBytes(command);
                string send = command + "\r\n";
               // Console.WriteLine("Sends: " + send);
                //send the message to the server
                if (tcpClient != null && tcpClient.Connected)
                {
                    writer.Write(System.Text.Encoding.ASCII.GetBytes(send));
                    


                    //check the pilot response
                    Byte[] data = new Byte[256];

                    // String to store the response ASCII representation.
                    String responseData = String.Empty;

                    // Read the first batch of the TcpServer response bytes.
                   Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
               //     Console.WriteLine("Received: {0}", responseData);
                }  
         
           });t.Start();
      
            
        }
        public bool isConnect()
        {
            return tcpClient.Connected;
        }
        ~Client()
        {
            tcpClient.Close();
        }
    }
}


