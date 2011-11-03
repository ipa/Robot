using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RobotView
{
    public partial class CommonRunParameters : UserControl
    {
        public EventHandler<CommonRunParameterEventArgs> AccelerationChanged;
        public EventHandler<CommonRunParameterEventArgs> SpeedChanged;

        public CommonRunParameters()
        {
            InitializeComponent();
        }

        private void OnAccelerationChanged(int newAcceleration)
        {
            if (AccelerationChanged != null)
            {
                this.AccelerationChanged.Invoke(this, new CommonRunParameterEventArgs(newAcceleration));
            }
        }

        private void OnSpeedChanged(int newSpeed)
        {
            if(this.SpeedChanged != null)
            {
                this.SpeedChanged.Invoke(this, new CommonRunParameterEventArgs(newSpeed));
            }
        }

        private void upDownAcceleration_ValueChanged(object sender, EventArgs e)
        {
            this.OnAccelerationChanged(Convert.ToInt32(upDownAcceleration.Value));
        }

        private void upDownSpeed_ValueChanged(object sender, EventArgs e)
        {
            this.OnSpeedChanged(Convert.ToInt32(upDownSpeed.Value));
        }

        public class CommonRunParameterEventArgs : EventArgs 
        {
            public CommonRunParameterEventArgs(int newValue)
            {
                this.NewValue = newValue;
            }

            public int NewValue
            { get; set; }
        }
    }
}
