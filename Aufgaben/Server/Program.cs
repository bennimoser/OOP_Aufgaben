using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {

        public static void Main(string[] args)
        {
            NetworkActivity activity = new NetworkActivity();
            activity.StartNetwork();
        }
    }

    public class NetworkActivity
    {
        public List<Client> clients { get; set; }


        public void StartNetwork()
        {
            this.clients = new List<Client>();

            NetworkActivity activity = new NetworkActivity();

            TcpListener listener = new TcpListener(GetAddress(), 270);
            listener.Start();
            Console.WriteLine("Server started on Port: 270");
            int id = 0;
            while (true)
            {
                TcpClient tcpclient = listener.AcceptTcpClient();
                Client client = new Client() { TCPClient = tcpclient, Id = id,  };
                clients.Add(client);
                Console.WriteLine("Client accepted");
                client.Start();
                id++;
            }

        }


        public IPAddress GetAddress()
        {
            string hostname = Dns.GetHostName();
            IPAddress[] addresslist = Dns.GetHostEntry(hostname).AddressList;
            foreach (IPAddress address in addresslist)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address;
                }
            }
            return IPAddress.None;
        }
    }

    public class Client
    {
        public int Id { get; set; }

        public Thread Thread { get; set; }

        public TcpClient TCPClient { get; set; }

        public void Start()
        {
            this.Thread = new Thread(new ThreadStart(NetworkWorker));
            this.Thread.Start();
        }

        public void NetworkWorker()
        {
            NetworkStream stream = this.TCPClient.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            while (true)
            {
                try
                {
                    string returnmessage = reader.ReadLine();
                    Console.WriteLine($"Received message from client {Id} : " + returnmessage);
                    string message = "Thank you for your kind message! Hi from the Server";
                    writer.WriteLine(message);
                }
                catch(Exception e)
                {
                    Console.WriteLine("An error has occured on Client Nr. " + Id);
                    Thread.Abort();
                }
            }
        }
    }
}
