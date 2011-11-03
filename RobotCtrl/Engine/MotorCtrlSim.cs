//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: MotorCtrlSim.cs 735 2011-10-13 09:16:14Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotCtrl
{
    public class MotorCtrlSim : MotorCtrl
    {

        #region members
        private float acceleration;     // Beschleunigung [m/s^2]
        private float nominalSpeed;     // eingestellte Geschwindigkeit [m/s]
        private float currentSpeed;     // aktuelle Geschwindigkeit [m/s]

        private Thread thread;
        private int ticks;
        private int status;
        private bool disposed;
        private bool run;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert den Simulator und startet einen Hintergrund-Thread,
        /// der die Simulation des Motors durchführt.
        /// </summary>
        public MotorCtrlSim()
        {
            Reset();

            this.disposed = false;
            this.run = true;

            this.thread = new Thread(Run);
            this.thread.IsBackground = true;
            this.thread.Priority = ThreadPriority.AboveNormal;
            this.thread.Start();
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt die gewünschte Geschwindigkeit [m/s] (Sollwert)
        /// </summary>
        public override float Speed
        {
            get { return this.nominalSpeed; }
            set { this.nominalSpeed = value; }
        }


        /// <summary>
        /// Liefert die aktuelle Geschwindigkeit [m/s] (Istwert)
        /// </summary>
        public override float CurrentSpeed
        {
            get { return this.currentSpeed; }
        }


        /// <summary>
        /// Liefert bzw. setzt die Beschleunigung [m/s^2]
        /// </summary>
        public override float Acceleration
        {
            get { return this.acceleration; }
            set { this.acceleration = value; }
        }


        /// <summary>
        /// Liefert das Statusbyte des Motorencontrollers
        /// </summary>
        public override int Status
        {
            get { return status; }
        }


        /// <summary>
        /// Liefert die gefahrenen Ticks
        /// </summary>
        public override int Ticks
        {
            get { return this.ticks; }
        }
        #endregion


        #region methods
        /// <summary>
        /// TODO_joc (Speed etc. erst nach Go übernehmen => Verhalten wie IC implementieren)
        /// </summary>
        public override void Go()
        {
            this.status = 0x00;
        }

        /// <summary>
        /// Hält den Motor sofort an.
        /// </summary>
        public override void Stop()
        {
            this.status = 0x80;
            this.currentSpeed = 0;
        }

        /// <summary>
        /// Setzt den Motorencontroller zurück
        /// </summary>
        public override void Reset()
        {
            this.ticks = 0;
            this.nominalSpeed = 0;
            this.acceleration = 0.25f;
            this.status = 0x80;
        }


        /// <summary>
        /// Setzt den Ticks-Zähler auf Null zurück
        /// </summary>
        public override void ResetTicks()
        {
            this.ticks = 0;
        }


        /// <summary>
        /// Setzt die Werte für den PID-Regler
        /// </summary>
        /// <param name="proportional"></param>
        /// <param name="integral"></param>
        /// <param name="derivative"></param>
        /// <param name="integralLimit"></param>
        /// <param name="derivativeInterval"></param>
        public override void SetPID(int proportional, int integral, int derivative, int integralLimit, int derivativeInterval)
        {
            // Wird in der Simulation nicht beachtet.
        }


        /// <summary>
        /// Dieser Thread simuliert den Motor
        /// </summary>
        private void Run()
        {
            int idt;
            float dt;
            run = true;
            int time = Environment.TickCount;
            while (run)
            {
                idt = Environment.TickCount - time; // = Zeitdiff. in Millisekunden
                time += idt;
                dt = idt / 1000f; // = Zeitdiff. in Sekunden
                
                if (!Stopped)
                {
                    // TODO Ticks hier berechnen...
                    ticks +=(int)((dt * currentSpeed / Constants.MeterPerTick));

                    if (nominalSpeed >= currentSpeed)
                    {
                        // aktuell zu langsam => beschleunigen
                        currentSpeed = Math.Min(nominalSpeed, currentSpeed + dt * acceleration);
                    }
                    else
                    {
                        // aktuell zu schnell => bremsen
                        currentSpeed = Math.Max(nominalSpeed, currentSpeed - dt * acceleration);
                    }
                }
                Thread.Sleep(1);
            }
        }
        #endregion

        public override void Dispose()
        {
            base.Dispose();

            if (!this.disposed)
            {

                this.run = false;
                thread.Join();
                this.disposed = true;
            }
            

        }

    }
}
