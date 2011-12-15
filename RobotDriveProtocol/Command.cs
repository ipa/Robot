using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotDriveProtocol
{
    public class Command
    {
        public Command()
        {
            this.Parameters = new List<Object>();
        }

        public string Method;

        public List<Object> Parameters;

        public List<Type> GetTypes()
        {
            List<Type> types = new List<Type>();
            this.Parameters.ForEach(el => types.Add(el.GetType()));
            return types;
        }

        public List<object> GetValues()
        {
            List<object> parameters = new List<object>();
            this.Parameters.ForEach(el => parameters.Add(el));
            return parameters;
        }

        public override string ToString()
        {
            string args = "";
            this.GetValues().ForEach(el => args += (el.ToString() + " : "));
            return string.Format("{0} - {1}", this.Method, args);
        }
    }
}
