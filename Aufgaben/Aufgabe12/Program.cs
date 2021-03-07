using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Aufgabe12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            
            IPAddress address = Dns.GetHostEntry("www.httpvshttps.com").AddressList.Where(ipa => ipa.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault() ;

            client.Connect(address, 80);

            string header = "GET http://localhost:2006/1.aspx HTTP/1.1\r\n" +
                "Host: Benjamin Moser\r\n" +
                "Connection: keep-alive\r\n" +
                "User-Agent: Mozilla/5.0\r\n" +
                "\r\n";

            client.Client.Send(Encoding.UTF8.GetBytes(header));

            byte[] buffer = new byte[2048];
            int readbytes = client.Client.Receive(buffer);
            byte[] copyarray = new byte[readbytes];
            Array.Copy(buffer, copyarray, readbytes);
            Console.WriteLine(Encoding.UTF8.GetString(copyarray));
        }
    }
}
