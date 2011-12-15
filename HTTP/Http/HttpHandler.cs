using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using ServerPattern;
using System.IO;
using System.Net.Sockets;

namespace Http
{
	class HttpHandler : AbstractHandler
	{
		// Multipurpose Internet Mail Extensions (MIME)
		// Internet Erweiterungen für die Einbindung von Daten.
		private string[,] mimetypes = {
		  {"html","text/html"},
		  {"htm", "text/html"},
		  {"txt", "text/plain"},
		  {"gif", "image/gif"},
		  {"jpg", "image/jpeg"},
		  {"jpeg","image/jpeg"}
		};

		private int id;
		private NetworkStream nws;
		private StreamReader sr;
		private StreamWriter sw;
		private string url;

		public HttpHandler(Socket client, int id) : base(client)
		{
			this.id = id;
			nws = new NetworkStream(client, true);
			sr = new StreamReader(nws);
			sw = new StreamWriter(nws);
		}

		override protected bool ReadRequest() 
		{
			Console.WriteLine(id+". Incoming request...");
			string headerline;
			ArrayList request = new ArrayList();
			// Request-Header-Zeilen lesen bis zur Leerzeile
			while ((headerline = sr.ReadLine()) != null && headerline != "") {
				request.Add(headerline);
				Console.WriteLine("< " + headerline);
			}
			// 1. Request-Zeile auf HTTP Methode GET untersuchen
			string[] tokens = ((string)request[0]).Split(new char[] { ' ' });
			if (tokens.Length >= 2 && tokens[0] == "GET") {
				// URL ermittlen
				if (tokens[1].StartsWith("/"))
					url = tokens[1];
				// Start URL setzen
				if (url.EndsWith("/"))
					url += HttpServer.startdoc;
				return true;			
			}
			else {
				WriteError(400, "Bad Request");
				return false;
			}
		}

		override protected void CreateResponse()
		{
			try {
				string filename = HttpServer.htdocs+url;
				filename = filename.Replace("..", "");
				FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
				long len = fs.Length;
				byte[] bytes = new byte[len];
				fs.Read(bytes, 0, (int)len);
				// Alles OK
				WriteResult("HTTP/1.0 200 OK");
				// Servererkennung senden
				WriteResult("Server: ExperimentalWebServer 1.0");
				// Content-Length ermitteln und senden
				WriteResult("Content-Length: "+bytes.Length.ToString());
				// Content-Type ermitteln und senden
				// Beginnen mit unbekanntem Dateityp
				String mimestring = "application/octet-stream";
				for (int i = 0; i < mimetypes.Length/2; ++i) {
					if (url.EndsWith(mimetypes[i,0])) {
						mimestring = mimetypes[i,1];
						break;
					}
				}
				WriteResult("Content-Type: " + mimestring);
				// Leerzeile senden
				WriteResult("");
				// Daten senden
				nws.Write(bytes, 0, (int)len);
				nws.Flush();
				fs.Close();
			}
			catch (FileNotFoundException) {
				WriteError(404, "File Not Found");
			}
			catch (DirectoryNotFoundException) {
				WriteError(404, "File Not Found");
			}
			catch (Exception e) {
				WriteError(410, "Unknown Exception");
				Console.Error.WriteLine(e);
			}
		}

		public void WriteResult(string message) 
		{
			Console.WriteLine("> " + message);
			sw.Write(message+"\r\n");
			sw.Flush();
		}

		public void WriteError(int status, string message)
		{
			string output = "<h1>HTTP/1.0 " + status + " " + message + "</h1>";
			Console.WriteLine("> " + status.ToString() + " " + message);
			sw.Write(output + "\r\n");
			sw.Flush();
		}
	}
}
