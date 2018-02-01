using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Linq;

namespace ChatServer {

    class Program {

        static void Main(string[] args) {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.
            string url = "http://localhost:9000";
            using(WebApp.Start(url)) {
                Console.WriteLine($"Server läuft auf {url}");
                Console.ReadLine();
            }
        }
    }

    class Startup {
        public void Configuration(IAppBuilder app) {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
            Console.WriteLine("Starte..");
        }
    }

    public class ChatHub : Hub {
        public void Send(string name, string message) {
            Clients.All.addMessage(name, message);
            Console.WriteLine($"{name}: {message}");
        }
    }

}
