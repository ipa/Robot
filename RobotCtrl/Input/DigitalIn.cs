using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public abstract class DigitalIn : IDisposable
    {
        public event EventHandler DigitalInChanged;

        public virtual void Dispose() { }

        public abstract int Data
        {
            get;
            set;
        }

        protected void OnDigitalInChanged(EventArgs e)
        {
            if (DigitalInChanged != null)
            {
              
                DigitalInChanged(this, e);
            }
        }

        public virtual bool this[int bit]
        {
            get { return (Data & 1 << bit) != 0; }
            set { Data = value ? Data | (1 << bit) : Data & ~(1 << bit); }
        }
    }
}