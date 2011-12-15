using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CommandInterpreter
{
    public class ParametrizedThreadStart
    {
        public delegate object ParametrizedDelegate(object obj, object[] parameters);

        private ParametrizedDelegate commandDelegate;
        private object invokeObj;
        private object[] parameters;

        public ParametrizedThreadStart(ParametrizedDelegate del, object obj, object[] parameters)
        {
            this.commandDelegate = del;
            this.invokeObj = obj;
            this.parameters = parameters;
        }

        public void Start()
        {
            this.commandDelegate(this.invokeObj, this.parameters);
        }
    }
}
