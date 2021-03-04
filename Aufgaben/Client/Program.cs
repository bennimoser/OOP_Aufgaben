using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            CommunicateWithServer(client);
        }

        public static IPAddress GetAddress()
        {
            string hostname = Dns.GetHostName();
            IPAddress[] addresslist = Dns.GetHostEntry(hostname).AddressList;
            foreach(IPAddress address in addresslist)
            {
                if(address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address;
                }
            }
            return IPAddress.None;
        }

        public static void CommunicateWithServer(TcpClient client)
        {
            IPAddress address = GetAddress();
            client.Connect(address, 270);
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            while (true)
            {
                string message = "Hallihallo! Ich bin der Client!";
                Console.WriteLine("Gesendet wird: " + message);

                writer.WriteLine(message);
                string returnmessage = reader.ReadLine();
                Console.WriteLine("Antwort des Servers war: " + returnmessage);
                Thread.Sleep(1000);
            }

        }
    }
}
