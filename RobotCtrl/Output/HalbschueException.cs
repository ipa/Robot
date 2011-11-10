using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class HalbschueException : Exception
    {
        string wieso;
        public HalbschueException(string wieso)
            : base()
        { this.wieso = wieso; }

        public override string Message
        {
            get
            {
                return "Grund, warum du ein Halbschue besch:" + wieso;
            }
        }
    }
}
