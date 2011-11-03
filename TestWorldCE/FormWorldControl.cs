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
        public FormWorldControl()
        {
            InitializeComponent();

            Drive drv = new Drive(RunMode.Virtual);
            this.driveCtrlView1.DriveCtrl = drv.DriveCtrl;
            this.runLineView1.drive = drv;
            this.driveView1.Drive = drv;
            this.trackArc1.drive = drv;
            this.trackTurnView1.drive = drv;
            Robot r = new Robot();
            r.drv = drv;
            r.Color = Color.Red;
            World.Robot = r;
            FormWorldView view = new FormWorldView();
            view.ViewPort = new RobotView.ViewPort(-5, 5, -5, 5);
            view.Show();
            
        }

      
    }
}