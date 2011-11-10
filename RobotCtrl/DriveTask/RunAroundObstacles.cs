using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;

namespace RobotCtrl
{
    public class RunAroundObstacles : DriveTask
    {
        Thread thread;
        bool end = false;

        public RunAroundObstacles()
            : base()
        {
            this.thread = new Thread(new ThreadStart(this.RunAround));
        }

        public override void Go()
        {
            this.thread.Start();
        }

        internal override void Stop()
        {
            this.end = true;
        } 

        private void RunAround()
        {
            const int WAITTIME = 100;
            int actualDoor = 2;

            while (!end)
            {
                if (World.Robot.Radar.Distance < 1.0f)
                {
                    
                }
                else
                {
                    World.Robot.drv.RunLine(0.5f, this.Speed, this.Acceleration);
                }

                Thread.Sleep(WAITTIME);
            }

            World.Robot.drv.Halt();
        }

        private int GetFreeDoor()
        {
            return 0;
            Drive drive = World.Robot.drv;
            Radar radar = World.Robot.Radar;
            RectangleF map = World.ObstacleMap.Area;



            // turn to door 3
            float angle = drive.Position.Angle;
            drive.RunTurn(-angle, this.Speed, this.Acceleration);
            while (!drive.Done) { Thread.Sleep(10); }

            // look at 0°
            if (radar.Distance > 2)
            {
                return 1;
            }


        }
    }
}
