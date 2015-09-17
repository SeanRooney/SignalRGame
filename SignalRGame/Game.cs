using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRGame
{
    public class Client
    {
        public string Name { get; set; }
        public Client Opponent { get; set; }
        public bool IsPlaying { get; set; }
        public bool WaitingForMove { get; set; }
        public bool LookingForOpponent { get; set; }

        public string ConnectionId { get; set; }
    }

    public class Game : Hub
    {
        public static List<Client> _clients = new List<Client>();

        private object _syncRoot = new object();

        public void RegisterClient(string data)
        {
            lock(_syncRoot)
            {
                var client = _clients
                    .FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
                if (_clients == null)
                {
                    client = new Client { ConnectionId = Context.ConnectionId, Name = data };
                    _clients.Add(client);
                }

                client.IsPlaying = false;
            }

            Clients.Client(Context.ConnectionId).registerComplete();
        }
    }
}