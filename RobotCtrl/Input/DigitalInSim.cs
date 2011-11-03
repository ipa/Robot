using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class DigitalInSim : DigitalIn
   {

        private int data;

        public DigitalInSim()
        {
            this.data = 0;
        }

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
                    OnDigitalInChanged(EventArgs.Empty);
                }
            }
        }
    }
}
