using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class DigitalInHW : DigitalIn, IDisposable
    {
        System.Threading.Timer tPoll;
        private int data, port;

        public DigitalInHW(int port)
        {
            this.port = port;
            tPoll = new System.Threading.Timer(new System.Threading.TimerCallback(update),
                                                                    null,
                                                                    100,
                                                                    40);

            
            
        }

        private void update(object state)
        {
            int newData = IOPort.Read(this.port);
            if (this.data != newData)
            {
                this.data = newData;
                OnDigitalInChanged(EventArgs.Empty);
            }
            
        }

        public override int Data
        {
            get
            {
                return data;
            }
            set
            {
               
            }
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (tPoll != null)
            {
                tPoll.Dispose();
            }
        }

        #endregion
    }
}
