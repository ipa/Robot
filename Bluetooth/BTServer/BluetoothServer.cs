using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TA.Bluetooth;
using System.IO;
using ServerPattern;
using System.Net.Sockets;
using Executor;
using System.Threading;

namespace BTServer
{
    public class BluetoothServer : AbstractServer
    {
        private int call = 0;

        public static void Main()
        {
            StartServer();
        }

        public override void Start()
        {
            Thread server = new Thread(Run);
            server.Start();
        }

        public static void StartServer()
        {
            new BluetoothServer().Start();
        }

        protected override void Run()
        {
            try
            {
                IExecutor executor = CreateExecutor();
                BluetoothService service = CreateService();

                while (base.Running)
                {
                    BluetoothClient client;
                    // accept bluetooth connection
                    client = service.WaitForConnection();
                    Console.WriteLine("Incoming connection " + client.GetSocket().RemoteEndPoint);

                    AbstractHandler handler = CreateHandler(client.GetSocket());
                    executor.Execute(handler.Run);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }

        private BluetoothService CreateService()
        {
            BluetoothService service;
            // check if Bluetooth-Stick is available
            if (BluetoothRadio.IsSupported)
            {
                // Device visible for others
                // RadioMode setting not supported as long as the
                // WinCE image doesn't include the BthUtil.dll
                //BluetoothRadio.PrimaryRadio.Mode = 
                //     BluetoothRadioMode.Discoverable;

                // set device Name
                BluetoothRadio.PrimaryRadio.Name = "AbflussRobot";
                // desired service
                Guid serviceId = BluetoothServiceList.Robot06;
                //Guid serviceId = new Guid("{FB4B43E4-0328-4056-82A5-7E03BE347082}");

                // start new service
                service = new BluetoothService();
                service.CreateService(serviceId);
                Console.WriteLine("Service " + serviceId.ToString() + " started.");
            }
            else
            {
                Console.WriteLine("No Bluetooth-Stick is available");
                throw new BluetoothNotStartedException();
                return null;
            }
            return service;
        }

        protected override AbstractHandler CreateHandler(Socket client)
        {
            return new BluetoothHandler(client, ++call);
        }
    }
}
