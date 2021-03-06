using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetzwerkProgrammierung
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region Ping

            Ping ping = new Ping();
            PingReply reply =  ping.Send("www.google.at");
            IPStatus status = reply.Status;
            IPAddress replyaddress = reply.Address;
            long time = reply.RoundtripTime;

            #endregion

            #region IP-Adressen

            string hostname = Dns.GetHostName();
            IPAddress[] addresslist = Dns.GetHostEntry(hostname).AddressList;
            foreach(var address in addresslist)
            {
                if(address.AddressFamily == AddressFamily.InterNetwork)
                {
                    //IPV4 Addresse
                }
                else if(address.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    //IPV6 Addresse
                }
            }

            IPAddress loopback = IPAddress.Loopback;
            IPAddress none = IPAddress.None;
            IPAddress parsed = IPAddress.Parse("10.0.0.27");
            IPAddress parsedV6 = IPAddress.Parse("fe80::913a:6730:644d:e189%13");
            string parsedstring = parsed.ToString();
            #endregion

            #region TCP 

            //Clientside
            TcpClient client = new TcpClient();
            client.Connect(loopback, 80);
            client.GetStream();
            bool connected = client.Connected;
            client.Close();

            //Serverside
            TcpListener listener = new TcpListener(loopback, 80);
            listener.Start();
            TcpClient acceptedclient = listener.AcceptTcpClient();
            acceptedclient.GetStream();
            connected = acceptedclient.Connected;
            acceptedclient.Close();
            #endregion

        }
    }
}
