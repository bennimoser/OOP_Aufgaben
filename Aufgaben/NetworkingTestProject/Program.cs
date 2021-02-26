using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NetworkingTestProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region Ping
            Ping ping = new Ping();
            PingReply result = ping.Send("www.google.at",100);
            Console.WriteLine("Gepingt wurde:" + result.Address);
            Console.WriteLine("Status war: " + result.Status);
            Console.WriteLine("Gedauert hat es: " + result.RoundtripTime + "ms");

            #endregion

            #region Eigene IP Adressen bekommen
            string hostname = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostEntry(hostname).AddressList;
            IPAddress ipv4 = IPAddress.None;
            IPAddress ipv6 = IPAddress.None;
            foreach (var address in addresses)
            {
                if(address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipv4 = address;
                }
                else if(address.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    ipv6 = address;
                }
            }

            Console.WriteLine("Aktuelle IPV4 Adresse: " + ipv4.ToString());
            Console.WriteLine("Aktuelle IPV6 Adresse: " + ipv6.ToString());
            

            #endregion

            #region TCP und Stream
            TcpClient client = new TcpClient();
            client.Connect("webcode.me", 80);
            var stream = client.GetStream();

            //  Umgehen mit Networkstream:
            //      mit Read and Write
            if (stream.DataAvailable && stream.CanRead)
            {
                byte[] bytes = new byte[1024];
                stream.Read(bytes,0, bytes.Length);              
            }

            if (stream.CanWrite)
            {
                string message = "Hallo du da";
                byte[] bytemessage = Encoding.UTF8.GetBytes(message);
                stream.Write(bytemessage, 0, bytemessage.Length);
            }
            


            //      mit Readern und Writern
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            if(stream.DataAvailable && stream.CanRead)
            {
                string receivedmessage = reader.ReadLine();
            }

            if (stream.CanWrite)
            {
                string message = "Hallo du da";
                writer.WriteLine(message);
            }



            //      mit Formatter und eigenen Messagetypes
            BinaryFormatter formatter = new BinaryFormatter();
            if(stream.DataAvailable && stream.CanRead)
            {
                //Ergebnis casten ZB mit IMessageTypeInterface oder ähnlichem
                object outcome = formatter.Deserialize(stream);
            }

            if (stream.CanWrite)
            {
                string message = "Hallo du da";
                formatter.Serialize(stream, message);
            }

            #endregion

            #region NetworkInterface
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] networkinterfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach(NetworkInterface networkinterface in networkinterfaces)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Id: " + networkinterface.Id);
                    Console.WriteLine("Name: " + networkinterface.Name);
                    Console.WriteLine("Beschreibung: " + networkinterface.Description);
                    Console.WriteLine("Geschwindigkeit: " + networkinterface.Speed + "bit/s");
                    Console.WriteLine("Typ: " + networkinterface.NetworkInterfaceType);
                }
            }
            #endregion

            Console.ReadLine();
        }
    }
}
