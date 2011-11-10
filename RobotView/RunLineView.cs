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
    public partial class RunLineView : UserControl
    {

        public Drive drive { get; set; }
        private int speed;
        private int acceleration;
        

        public RunLineView()
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

        private void btnStart_Click(object sender, EventArgs e)
        {


            if (drive == null) throw new HalbschueException("wöud dammi nonemou drive ned zuegwese hesch! Huere siech!");
            drive.RunLine((float)nudLength.Value, speed, acceleration);
        }

        private void btnChangeReverse_Click(object sender, EventArgs e)
        {
        }
    }

}
