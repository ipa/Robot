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

        private const int xMin = -1;
        private const int xMax = 6;
        private const int yMin = -1;
        private const int yMax = 3;


        public FormWorldControl()
        {
            InitializeComponent();

            Drive drv = new Drive(RunMode.Virtual);
            this.runLineView1.drive = drv;
            this.driveView1.Drive = drv;
            this.trackArc1.drive = drv;
            this.trackTurnView1.drive = drv;
            
            Robot r = new Robot(RunMode.Virtual);

            r.ConfigurePathRecording(0.05f, 0.1f);

            drv.Position = new PositionInfo(0f, 1.5f, 0f);

            r.drv = drv;
            r.Color = Color.Red;
            World.Robot = r;

            RobotConsole rc = r.RobotConsole;
           
            consoleView1.RobotConsole = rc;

            if (r.RunMode == RunMode.Virtual)
            {
                World.ObstacleMap = new ObstacleMap(RobotView.Resource.ObstacleMap1a, xMin+0.5f, xMax+0.5f, yMin+0.5f, yMax+0.5f); //korrektur wg. doofen bildern
            }

            FormWorldView view = new FormWorldView(xMin, yMin, xMax, yMax);
            view.ViewPort = new RobotView.ViewPort(xMin, xMax, yMin, yMax);
            view.Show();

            BlinkingLed led = rc[BlinkingLeds.BlinkingLed4];
            led.Frequency = 5;
            led.LedEnabled = true;

        }
    }
}