﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Diagnostics;

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
            this.actualDoor = 2;
        }

        public override void Go()
        {
            this.thread.Start();
        }

        internal override void Stop()
        {
            this.end = true;
        }

        int actualDoor;

        private void RunAround()
        {
            const int WAITTIME = 100;
            Drive drive = World.Robot.drv;
   
            while (!end)
            {
                int nextDoor = GetFreeDoor();
                Debug.WriteLine(string.Format("Free Door: {0}", nextDoor));

                if (nextDoor != actualDoor)
                {
                    int diffDoor = nextDoor - actualDoor;
                    float angle = diffDoor < 0 ? -90 : 90;
                    
                    drive.RunTurn(angle, this.Speed, this.Acceleration);
                    while (!drive.Done) { Thread.Sleep(10); }
                    
                    drive.RunLine(Math.Abs(actualDoor - nextDoor), this.Speed, this.Acceleration);
                    while (!drive.Done) { Thread.Sleep(10); }

                    drive.RunTurn(-angle, this.Speed, this.Acceleration);
                    while (!drive.Done) { Thread.Sleep(10); }
                }

                drive.RunLine(2f, this.Speed, this.Acceleration);
                while (!drive.Done) { Thread.Sleep(10); }

                actualDoor = nextDoor;
            }

            World.Robot.drv.Halt();
        }

        private int GetFreeDoor()
        {
            if (World.Robot.Radar.Distance > 1.5f)
            {
                return actualDoor;
            }

            float angle = actualDoor == 3 ? -45f : 45f;

            World.Robot.drv.RunTurn(angle, this.Speed, this.Acceleration);
            while (!World.Robot.drv.Done) { Thread.Sleep(10); }

            float distance = World.Robot.Radar.Distance;

            World.Robot.drv.RunTurn(-angle, this.Speed, this.Acceleration);
            while (!World.Robot.drv.Done) { Thread.Sleep(10); }

            if (distance < 1.5f)
            {
                return actualDoor == 1 ? 3 : 1;
            }
            else
            {
                return actualDoor == 3 ? 2 : actualDoor + 1;
            }
        }
    }
}
