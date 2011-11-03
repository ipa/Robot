using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public abstract class DigitalOut : IDisposable
    {
        public event EventHandler DigitalOutChanged;

        public virtual void Dispose() { }

        public abstract int Data
        {
            get;
            set;
        }

        protected void OnDigitalOutChanged(EventArgs e)
        {
            if (DigitalOutChanged != null)
            {
                DigitalOutChanged(this, e);
            }
        }

        public virtual bool this[int bit]
        {
            get { return (Data & 1 << bit) != 0; }
            set { Data = value ? Data | (1 << bit) : Data & ~(1 << bit);
 
            }
        }
    }
}