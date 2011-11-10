using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class RunSomeMeters : DriveTask
    {
        public RunSomeMeters(float distance)
            : base()
        {
            this.Distance = distance;
        }

        public float Distance { get; set; }

        public override void Go()
        {
            World.Robot.drv.RunLine(this.Distance, this.Speed, this.Acceleration);
        }
    }
}
