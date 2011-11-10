using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace TestWorldCE
{
    public partial class FormWorldControl : Form
    {
        private const int xMin = -4;
        private const int xMax = 5;
        private const int yMin = -4;
        private const int yMax = 5;

        public FormWorldControl()
        {
            InitializeComponent();

            Drive drv = new Drive(RunMode.Virtual);
            this.driveCtrlView1.DriveCtrl = drv.DriveCtrl;
            this.runLineView1.drive = drv;
            this.driveView1.Drive = drv;
            this.trackArc1.drive = drv;
            this.trackTurnView1.drive = drv;

            Robot r = new Robot(RunMode.Virtual);
            r.ConfigurePathRecording(0.05f, 0.1f);
            r.drv = drv;
            r.Color = Color.Red;
            World.Robot = r;

            if (r.RunMode == RunMode.Virtual)
            {
                World.ObstacleMap = new ObstacleMap(RobotView.Resource.ObstacleMap1b, xMin, xMax, yMin, yMax);
            }

            FormWorldView view = new FormWorldView();
            view.ViewPort = new RobotView.ViewPort(xMin, xMax, yMin, yMax);
            view.Show();
        }
    }
}