using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Executor;

namespace ServerPattern
{
    public abstract class AbstractServer
    {
        private Boolean running = true;
        private int port;
        private string host;
        public const int DEFAULTPORT = 4711;
        public const string DEFAULTHOST = "localhost";

        protected void Run() {
            try {
                IExecutor executor = CreateExecutor();
                Socket listen = CreateServerSocket();
                while (running) {
                    AbstractHandler handler = CreateHandler(listen.Accept());
                    executor.Execute(handler.Run);
                }
            } catch (Exception e) {
                Console.Error.WriteLine(e);
            }
        }

        virtual protected IExecutor CreateExecutor() {
            return new PlainThreadExecutor();
        }

        virtual protected Socket CreateServerSocket() {
            IPAddress ipAddress = Dns.GetHostEntry(host).AddressList[0];
            TcpListener listener = new TcpListener(ipAddress, port);
            listener.Start();
            return listener.Server;
        }

        public void Start() {
            this.Start(DEFAULTPORT, DEFAULTHOST);
        }

        public void Start(int port) {
            this.Start(port, DEFAULTHOST);
        }

        public void Start(int port, string host) {
            if ((port <= 0) || (host == null)) throw
                new ArgumentOutOfRangeException("host or port");
            Thread server = new Thread(Run);
            this.port = port;
            this.host = host;
            server.Start();
        }

        public void Stop() {
            running = false;
            new TcpClient(host, port);
        }

        public int GetPort() {
            return port;
        }

        public string GetHost() {
            return host;
        }

        abstract protected AbstractHandler CreateHandler(Socket client);
    }
}
