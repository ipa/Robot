using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ServerPattern;
using System.Net.Sockets;
using System.IO;
using TA.Bluetooth;
using System.Threading;
using System.Xml.Serialization;
using CommandInterpreter;

namespace BTServer
{
    class BluetoothHandler : AbstractHandler
    {
        private int id;
        private NetworkStream nws;
        private StreamReader sr;
        private StreamWriter sw;
        private Socket client;

        private static IInterpreter interpreter;

        private string request;

        static BluetoothHandler()
        {
            interpreter = new Interpreter();
        }

        public BluetoothHandler(Socket client, int id)
            : base(client)
		{
			this.id = id;
            this.client = client;
			nws = new NetworkStream(client, true);
			sr = new StreamReader(nws);
			sw = new StreamWriter(nws);
		}

        protected override bool ReadRequest()
        {
            this.request = this.sr.ReadToEnd();

            interpreter.InterpretMessage(request);

            return true;
        }

        protected override void CreateResponse()
        {
            // Output data to stream
        //    sw.WriteLine("Hello from " + BluetoothRadio.PrimaryRadio.Name);

          //  sw.Flush();

            Thread.Sleep(100);

            client.Close();
        }
    }
}
