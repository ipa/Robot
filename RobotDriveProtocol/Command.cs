using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotDriveProtocol
{
    public class Command
    {
        public string Method;

        public Dictionary<Type, Object> Parameters;

        public override string ToString()
        {
            string args = "";
            this.Parameters.Values.ToList().ForEach(el => args += (el.ToString() + " : "));
            return string.Format("{0} - {1}", this.Method, args);
        }
    }
}
