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
        public void InterpretMessage(string message)
        {
            List<Command> commands = CommandSerializer.Deserialize(message);
            if (commands != null)
            {
                this.InterpretCommand(commands);
            }
        }

        public void InterpretCommand(List<Command> cmds)
        {
            cmds.ForEach(el => this.ExecuteCommand(el));
        }

        private void ExecuteCommand(Command cmd)
        {

            StreamWriter writer = null;
            try
            {
                String path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "htdocs");
                path = Path.Combine(path, "drive.txt");
                writer = File.AppendText(path);
                
                Drive drive = World.Robot.drv;
                MethodInfo methodInfo = drive.GetType().GetMethod(cmd.Method, cmd.GetTypes().ToArray());
                if (methodInfo != null && methodInfo.GetCustomAttributes(typeof(RunMethod), false).Length == 1)
                {
                    methodInfo.Invoke(drive, cmd.GetValues().ToArray());
                    while (!drive.Done) { Thread.Sleep(20); }
                    writer.WriteLine(cmd.ToString());
                }
                else
                {
                    Console.WriteLine("could not interpret command");
                }
            }
            finally
            {
                if (writer != null)
                {
                    writer.Flush();
                    writer.Close();
                }
            }
        }
    }
}
