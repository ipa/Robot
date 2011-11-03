using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace TestDriveCE
{
    public partial class Form1 : Form
    {
        Drive drv; Switch s1,s2,s3;
        public Form1()
        {
            InitializeComponent();
             drv = new Drive(RunMode.Real);
            this.driveCtrlView1.DriveCtrl = drv.DriveCtrl;
            this.runLineView1.drive = drv;
            this.trackTurnView1.drive = drv;
            this.driveView1.Drive = drv;
            this.trackArc1.drive = drv;
            drv.Power = true;

            DigitalInHW inHW = new DigitalInHW(Constants.IOConsoleSWITCH);
             s1= new Switch(inHW, Switches.Switch1);
            s2 = new Switch(inHW,Switches.Switch2);
            s3 = new Switch(inHW,Switches.Switch3);
            
            s1.SwitchStateChanged += new EventHandler<SwitchEventArgs>(s_SwitchStateChanged);
            s2.SwitchStateChanged += new EventHandler<SwitchEventArgs>(s2_SwitchStateChanged);
            s3.SwitchStateChanged += new EventHandler<SwitchEventArgs>(s3_SwitchStateChanged);
            
        }

        void s3_SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            if (e.SwitchEnabled)
            {

                drv.RunArcLeft(1.0f, 360.0f, 0.5f, 0.5f);
            }
            else
            {
                drv.Power = false;
                drv.Power = true;
            }
        }

        void s2_SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            if (e.SwitchEnabled)
            {

                drv.RunTurn(360.0f, 0.5f, 0.5f);
            }
            else
            {
                drv.Power = false;
                drv.Power = true;
            }
        }

        void s_SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            if (e.SwitchEnabled)
            {
                
                drv.RunLine(2.0f, 0.5f, 0.5f);
            }
            else
            {
                drv.Power = false;
                drv.Power = true;
            }
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        } 
    }
}