using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new Connection("http://localhost:52037/Default");

            connection.Received += connection_Received;

            connection.Start().Wait();

            string input = null;
            //as long as something can be read from console
            //it will be sent to the server
            while((input = Console.ReadLine()) != null)
            {
                connection.Send(input);
            }
        }

        static void connection_Received(string data)
        {
            Console.WriteLine(data);
        }
    }
}
