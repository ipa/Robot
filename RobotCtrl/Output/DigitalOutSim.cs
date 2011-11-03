using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class DigitalOutSim : DigitalOut
    {
        public int data;
        public override int Data
        {
            get
            {
                return data;
            }
            set
            {
                if (data != value)
                {
                    data = value;
                    OnDigitalOutChanged(EventArgs.Empty);
                }
            }
        }
    }
}
