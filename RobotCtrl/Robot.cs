using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RobotCtrl
{
    public class Robot
    {
        public Robot(RunMode runMode)
        {
            this.RunMode = runMode;
            this.Radar = new Radar(runMode);
            this.RobotConsole = new RobotConsole(runMode);

            this.RobotConsole[Switches.Switch1].SwitchStateChanged += SwitchStateChangedRunAroundObstacles;
            //this.RobotConsole[Switches.Switch2].SwitchStateChanged += SwitchStateChanged;
            //this.RobotConsole[Switches.Switch3].SwitchStateChanged += SwitchStateChanged;
            //this.RobotConsole[Switches.Switch4].SwitchStateChanged += SwitchStateChanged;
        }

        public RunMode RunMode
        { get; set; }

        public Color Color
        { get; set; }

        public PositionInfo Position
        { get { return drv.Position; } }

        public Drive drv {get;set;}

        public Radar Radar { get; set; }


        public RobotConsole RobotConsole
        {
            get;
            private set;
        }

        public DriveTask ActualDriveTask { get; private set; }

        private void SwitchStateChangedRunAroundObstacles(object sender, SwitchEventArgs e)
        {
            if (e.SwitchEnabled)
            {
                if (ActualDriveTask != null)
                {
                    this.ActualDriveTask.Stop();
                }
                this.ActualDriveTask = new RunAroundObstacles();
                this.ActualDriveTask.Go();
            }
            else
            {
                if (this.ActualDriveTask != null)
                {
                    this.ActualDriveTask.Stop();
                }
            }
        }
    }
}
