using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe3
{
    class Program
    {
        public static void Main(string[] args)
        {
            var ipaddress = GetIpAddress();
            PingSubnet(ipaddress);
        }

        public static IPAddress GetIpAddress()
        {
            var hostname = Dns.GetHostName();
            var hostadresses = Dns.GetHostEntry(hostname).AddressList;
            IPAddress address = IPAddress.Any;
            foreach(var element in hostadresses)
            {
                if(element.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    address = element;
                }
            }
            return address;
        }

        public static void PingSubnet(IPAddress entryAddress)
        {
            List<string> numbers = entryAddress.ToString().Split('.').ToList();
            for (int i = 1; i < 255; i++)
            {
                numbers[numbers.Count - 1] = i.ToString();
                var addressString = string.Join(".", numbers);
                var adress = IPAddress.Parse(addressString);
                var ping = new Ping();
                PingReply result = ping.Send(adress);
                if(result.Status == IPStatus.Success)
                {
                    Console.WriteLine(adress);
                }
            }
        }
    }
}
