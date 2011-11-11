using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public abstract class DriveTask
    {
        protected DriveTask()
        {
            this.Acceleration = 0.5f;
            this.Speed = 0.5f;
        }

        public abstract void Go();

        public float Acceleration { get; set; }

        public float Speed { get; set; }


        internal virtual void Stop()
        {
            World.Robot.drv.Halt();
        }
    }
}
