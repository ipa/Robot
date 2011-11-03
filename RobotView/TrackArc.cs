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
    public partial class TrackArc : UserControl
    {
        public Drive drive { get; set; }
        private int speed;
        private int acceleration;
        

        public TrackArc()
        {
            InitializeComponent();
            this.commonRunParameters1.AccelerationChanged += new EventHandler<CommonRunParameters.CommonRunParameterEventArgs>(accelerationChanged);
            this.commonRunParameters1.SpeedChanged += new EventHandler<CommonRunParameters.CommonRunParameterEventArgs>(speedChanged);

        }
        private void accelerationChanged(object sender, CommonRunParameters.CommonRunParameterEventArgs e)
        {
            acceleration = e.NewValue;
        }

        private void speedChanged(object sender, CommonRunParameters.CommonRunParameterEventArgs e)
        {
            speed = e.NewValue;
        }

        private void btnHue_Click(object sender, EventArgs e)
        {
            drive.RunArcLeft((float)nudRadius.Value, (float)nudAngle.Value, speed, acceleration);
        }
    }
}
