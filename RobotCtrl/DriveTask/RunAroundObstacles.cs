using System;
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
        public class DoorFoundEventArgs : EventArgs
        {
            public int FoundDoor
            {get;set;}
        }
        
        Thread thread;
        int maxCountDoors = 3;
        bool end = false;
        int actualDoor;
        float BoxToMeter = 0.5f;
        public delegate void DoorFoundEventHandler(Object sender, DoorFoundEventArgs e);
        public delegate void FinishedEventHandler(Object sender);
        public delegate void StartedEventHandler(Object sender);
        public event DoorFoundEventHandler DoorFoundEvent;
        public event FinishedEventHandler FinishedEvent;
        public event StartedEventHandler StartedEvent;


        public RunAroundObstacles()
            : base()
        {
            this.thread = new Thread(new ThreadStart(this.RunAround));
            this.actualDoor = 2;
            World.Robot.drv.Position = new PositionInfo(0f, 0.75f, 0f);
        }

        public override void Go()
        {
            this.thread.Start();
        }

        internal override void Stop()
        {
            this.end = true;
            World.Robot.drv.Halt();
        }

        

        private void RunAround()
        {
            StartedEvent(this);
            const int WAITTIME = 100;
            int countDoors = 0;
            Drive drive = World.Robot.drv;
   
            while (!end)
            {
                int nextDoor = GetFreeDoor();
                Debug.WriteLine(string.Format("Free Door: {0}", nextDoor));
                
                DoorFoundEvent(this,new DoorFoundEventArgs(){ FoundDoor = nextDoor});

                if (nextDoor != actualDoor)
                {
                    int diffDoor = nextDoor - actualDoor;
                    float angle = diffDoor < 0 ? -90 : 90;
                    
                    drive.RunTurn(angle, this.Speed, this.Acceleration);
                    while (!drive.Done) { Thread.Sleep(10); }
                    
                    drive.RunLine(Math.Abs(actualDoor - nextDoor)*BoxToMeter, this.Speed, this.Acceleration);
                    while (!drive.Done) { Thread.Sleep(10); }

                    drive.RunTurn(-angle, this.Speed, this.Acceleration);
                    while (!drive.Done) { Thread.Sleep(10); }
                }

                drive.RunLine(2f*BoxToMeter, this.Speed, this.Acceleration);
                while (!drive.Done) { Thread.Sleep(10); }

                actualDoor = nextDoor;
                countDoors++;
                if (countDoors >= maxCountDoors) 
                {
                    DriveToPosition(2);
                    end = true;
                   
                }
            }

            World.Robot.drv.Halt();
            FinishedEvent(this);
        }

        private int GetFreeDoor()
        {
            if (World.Robot.Radar.Distance > 1.5f*BoxToMeter)
            {
                return actualDoor;
            }

            float angle = actualDoor == 3 ? -45f : 45f;

            World.Robot.drv.RunTurn(angle, this.Speed, this.Acceleration);
            while (!World.Robot.drv.Done) { Thread.Sleep(10); }

            float distance = World.Robot.Radar.Distance;

            World.Robot.drv.RunTurn(-angle, this.Speed, this.Acceleration);
            while (!World.Robot.drv.Done) { Thread.Sleep(10); }

            if (distance < 1.5f*BoxToMeter)
            {
                return actualDoor == 1 ? 3 : 1;
            }
            else
            {
                return actualDoor == 3 ? 2 : actualDoor + 1;
            }
        }

        private void DriveToPosition(int doorPosition)
        {
            Drive drive = World.Robot.drv;
            int diffDoor = doorPosition - actualDoor;
            float angle = diffDoor < 0 ? -90 : 90;

            drive.RunTurn(angle, this.Speed, this.Acceleration);
            while (!drive.Done) { Thread.Sleep(10); }

            drive.RunLine(Math.Abs(actualDoor - doorPosition)*BoxToMeter, this.Speed, this.Acceleration);
            while (!drive.Done) { Thread.Sleep(10); }

            drive.RunTurn(-angle, this.Speed, this.Acceleration);
            while (!drive.Done) { Thread.Sleep(10); }
        
        
        }
    }
}
