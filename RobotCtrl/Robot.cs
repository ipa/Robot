using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace RobotCtrl
{
    public class Robot : IDisposable
    {

        private float sigma=0.01f; //minimal change to save new path (in [m])
        private float recordTime = 0.1f; //intervall between to measurements (in [s]);
        private Timer recordTimer;
        private List<PositionInfo> storedPositions;  //no max size yet
        private object listBlocker = new object();
        public event EventHandler<SwitchEventArgs> SwitchStateChanged;


        public Robot(RunMode runMode)
        {
            this.RunMode = runMode;
            this.Radar = new Radar(runMode);

            storedPositions = new List<PositionInfo>();
            recordTimer = new Timer(StorePosition, null, (int)(recordTime * 1000),(int)( recordTime * 1000));

      	    this.RobotConsole = new RobotConsole(runMode);

            this.RobotConsole[Switches.Switch1].SwitchStateChanged += SwitchStateChangedRunAroundObstacles;
            this.RobotConsole[Switches.Switch1].SwitchStateChanged += SwitchStateChangedRedirect;
            this.RobotConsole[Switches.Switch2].SwitchStateChanged += SwitchStateChangedRedirect;
            this.RobotConsole[Switches.Switch3].SwitchStateChanged += SwitchStateChangedRedirect;
            this.RobotConsole[Switches.Switch4].SwitchStateChanged += SwitchStateChangedRedirect;
        }

        public void ResetPath()
        {
            lock (listBlocker)
            {
                storedPositions.Clear();
            }
        }


        /// <summary>
        /// Configures path recording.
        /// Calling this method automatically resets previous made recordings!
        /// </summary>
        /// <param name="sigma">Minimal change of position to be recorded, Standard 0.01m</param>
        /// <param name="recordTime">Time between to measurements, Standard 0.1s</param>
        public void ConfigurePathRecording(float sigma, float recordTime)
        {
            this.sigma = sigma;
            this.recordTime = recordTime;
            ResetPath();
        }

        public PositionInfo[] GetPath()
        {
            lock (listBlocker)
            {
                return storedPositions.ToArray();
            }

        }

        public RunMode RunMode
        { get; set; }

        public Color Color
        { get; set; }

        public PositionInfo Position
        { get { return drv.Position; } }

        public Drive drv {get;set;}

        public Radar Radar { get; set; }

   
        private void StorePosition(object state)
        {
            if (drv == null) return; //no drive, no info man!
            PositionInfo thisPoint = this.drv.Position;

            float difference = float.MaxValue ; //if no info about last position is found - we have max. difference
             if (storedPositions.Count > 0) 
             {
                 PositionInfo lastPoint = storedPositions.Last();
                 

                 difference = (float)Math.Sqrt(Math.Pow(lastPoint.X - thisPoint.X, 2) + Math.Pow(lastPoint.Y - thisPoint.Y, 2));
             }

            if (difference >= sigma)
            {
                lock (listBlocker)
                {
                    storedPositions.Add(thisPoint);
                }
            }
            
        }


        #region IDisposable Members

        public void Dispose()
        {
            if (drv!=null) drv.Dispose();
            if (recordTimer != null) drv.Dispose();
        }

        #endregion


        public RobotConsole RobotConsole
        {
            get;
            private set;
        }

        public DriveTask ActualDriveTask { get; private set; }

        private void SwitchStateChangedRedirect(object sender, SwitchEventArgs e)
        {
            this.SwitchStateChanged(sender, e);
        }

        private void SwitchStateChangedRunAroundObstacles(object sender, SwitchEventArgs e)
        {
            if (e.SwitchEnabled)
            {
                if (ActualDriveTask != null)
                {
                    this.ActualDriveTask.Stop();
                }
                RunAroundObstacles drvTask = new RunAroundObstacles();
                drvTask.DoorFoundEvent += new RunAroundObstacles.DoorFoundEventHandler(drvTask_DoorFoundEvent);
                drvTask.FinishedEvent += new RunAroundObstacles.FinishedEventHandler(drvTask_FinishedEvent);
                drvTask.StartedEvent += new RunAroundObstacles.StartedEventHandler(drvTask_StartedEvent);
                this.ActualDriveTask = drvTask;
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

        void drvTask_StartedEvent(object sender)
        {
            RobotConsole[Leds.Led4].LedEnabled = true;
        }

        void drvTask_FinishedEvent(object sender)
        {
            RobotConsole[BlinkingLeds.BlinkingLed1].LedEnabled = false;
            RobotConsole[BlinkingLeds.BlinkingLed2].LedEnabled = false;
            RobotConsole[BlinkingLeds.BlinkingLed3].LedEnabled = false;
            RobotConsole[Leds.Led4].LedEnabled = false;

            //DIE HÄSSLICHKEIT: (Spieglein spieglein an der Wand wer ist der hässlichste Code im ganzen Land?)
            //Es ist die robot.cs!!!!
            RobotConsole[Switches.Switch2].SwitchEnabled = true;
            RobotConsole[Switches.Switch2].SwitchEnabled = false;

        }



        void drvTask_DoorFoundEvent(object sender, RunAroundObstacles.DoorFoundEventArgs e)
        {
            //disable all blinking LEDS 2-3
            RobotConsole[BlinkingLeds.BlinkingLed1].LedEnabled = false;
            RobotConsole[BlinkingLeds.BlinkingLed2].LedEnabled = false;
            RobotConsole[BlinkingLeds.BlinkingLed3].LedEnabled = false;

            //Enable correct LED
            RobotConsole[(BlinkingLeds)(3-e.FoundDoor)].LedEnabled = true;
        }
    }
}
