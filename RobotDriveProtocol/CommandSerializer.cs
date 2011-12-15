using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Xml.Serialization;

namespace RobotDriveProtocol
{
    public static class CommandSerializer
    {
        public static List<Command> Deserialize(string message)
        {
            List<Command> cmd = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Command>));
            XmlReader xmlReader = XmlReader.Create(new StringReader(message));
            if (serializer.CanDeserialize(xmlReader))
            {
                object o = serializer.Deserialize(xmlReader);
                if (o is List<Command>)
                {
                    cmd = (List<Command>)o;
                }
            }
            else
            {
                Console.WriteLine("could not deserialize message");
            }
            return cmd;
        }

        public static string Serialize(List<Command> commands)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Command>));
            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter);

            serializer.Serialize(xmlWriter, commands);
            xmlWriter.Flush();

            return stringWriter.ToString();
        }
    }
}
