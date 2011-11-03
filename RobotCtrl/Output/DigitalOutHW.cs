using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class DigitalOutHW : DigitalOut
    {
        int port;
        int data;

        public DigitalOutHW(int port)
        {
            this.port = port;
        }


        public override int Data
        {
            get {

                return data;
            }
            set {

                if (data != value)
                {
                    data = value;
                    IOPort.Write(this.port, data);
                    OnDigitalOutChanged(EventArgs.Empty);
                }
            }
        }
    }
}
