using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace TestMotorCE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if(Constants.IsWinCE)
            {
                driveCtrlView1.DriveCtrl = new DriveCtrlHW(Constants.IODriveCtrl);
                leftMotor.MotorCtrl = new MotorCtrlHW(Constants.IOMotorCtrlLeft);
                rightMotor.MotorCtrl = new MotorCtrlHW(Constants.IOMotorCtrlRight);
            
            
            }
            else
            {
                driveCtrlView1.DriveCtrl = new DriveCtrlSim();
                leftMotor.MotorCtrl = new MotorCtrlSim();
                rightMotor .MotorCtrl= new MotorCtrlSim();
            }

        }
    }
}