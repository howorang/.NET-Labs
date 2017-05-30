using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedCode;

namespace Server
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                TcpListener listener = new TcpListener(ipAddress, 8001);

                listener.Start();

                Console.WriteLine("Server is running");

                bool isRunning = true;
                while (isRunning)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Thread clientThread = new Thread(p => clientHandler(client));
                    clientThread.Start();
                    clientThread.Join();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        public static void clientHandler(TcpClient client)
        {
            Console.WriteLine("New client connected");
            Stream clientStream = client.GetStream();
            IFormatter formatter = new BinaryFormatter();
            FileTransfer fileTransfer = (FileTransfer)formatter.Deserialize(clientStream);
            FileManager.save(fileTransfer);
            Console.WriteLine("File {0} written to: {1}", fileTransfer.Name, System.Environment.CurrentDirectory);
        }
    }
}
