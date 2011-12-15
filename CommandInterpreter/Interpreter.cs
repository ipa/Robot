using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using RobotDriveProtocol;
using RobotCtrl;
using System.Reflection;
using System.Threading;
using Executor;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace CommandInterpreter
{
    public class Interpreter : IInterpreter
    {
        private static IExecutor executor;
        
        static Interpreter()
        {
            executor = new WorkerPool(1);
        }
        
        public void InterpretMessage(string message)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Command));
            XmlReader xmlReader = XmlReader.Create(new StringReader(message));
            if (serializer.CanDeserialize(xmlReader))
            {
                object o = serializer.Deserialize(xmlReader);
                if (o is Command)
                {
                    Command cmd = (Command)o;
                    this.InterpretCommand(cmd);
                }
            }
            else
            {
                Console.WriteLine("could not deserialize message");
            }
        }

        public void InterpretCommand(Command cmd)
        {
            Drive drive = World.Robot.drv;
            MethodInfo methodInfo = drive.GetType().GetMethod(cmd.Method, cmd.GetTypes().ToArray());
            if (methodInfo != null && methodInfo.GetCustomAttributes(typeof(RunMethod), false).Length == 1)
            {
                ParametrizedThreadStart driveCmd = new ParametrizedThreadStart(methodInfo.Invoke, drive, cmd.GetValues().ToArray());
                executor.Execute(new ThreadStart(driveCmd.Start));
            }
            else
            {
                Console.WriteLine("could not interpret command");
            }
        }
    }
}
