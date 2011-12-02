using Executor;
using System;
using System.Collections.Generic;
using System.Text;
using ServerPattern;
using System.Net.Sockets;
using System.Reflection;
using System.IO;

namespace Http
{
	/**
	 * Ein ganz einfacher Web-Server auf TCP und einem beliebigen Port. 
	 * Der Server ist in der Lage, Seitenanforderungen aus dem 
	 * Verzeichnis, das im Attribut "htdocs" steht, zu bearbeiten.
	 * Zudem kann der Server mit Hilfe der Program Parameter das
	 * Startvereichnis und -dokument konfiguriert werden.
	*/
	class HttpServer : AbstractServer
	{
		private int call = 0;

		/**
		 * html document base - Arbeitsverzeichnis f�r die html-Dokumente.<br>
		 */
		public static String htdocs = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase),"htdocs");
		public static String startdoc = "index.html";

		override protected AbstractHandler CreateHandler(Socket client)
		{
			return new HttpHandler(client, ++call);
		}

		override protected IExecutor CreateExecutor()
		{
			return new WorkerPool(20);
		}

		public static void Main(String[] args) 
		{
			int port = 8080;
			if (args.Length > 0)
			{
				port = Int32.Parse(args[0]);
				htdocs = args[1];
				startdoc = args[2];
			}
			new HttpServer().Start(port);
			Console.WriteLine("HTTP server running on port: " + port);
            Console.WriteLine("htdocs folder: " + htdocs);
		}
	}
}
