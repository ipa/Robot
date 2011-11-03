using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotView
{
    public partial class LedView : UserControl
    {

        private bool state;

        private Led led;

        public LedView()
        {
            InitializeComponent();
            State = false;
        }

        public bool State
        {
            get { return state; }
            set
            {
                
                state = value;
                pictureBox1.Image = value ? Resource.LedOn : Resource.LedOff;
            }
        }

        public Led Led
        {
            get { return led; }
            set
            {
                if (led != null) led.LedStateChanged -= LedStateChanged;
                led = value;
                if (led != null) led.LedStateChanged += LedStateChanged;
            }
        }

        void LedStateChanged(object sender, LedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler<LedEventArgs>(LedStateChanged), new object[] { sender, e });
            }
            else
            {
                State = e.LedEnabled;
            }
        }
    }
}
