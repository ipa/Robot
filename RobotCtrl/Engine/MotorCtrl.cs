//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: MotorCtrl.cs 735 2011-10-13 09:16:14Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public abstract class MotorCtrl : IDisposable
    {

        #region constructor & destructor
        /// <summary>
        /// Dispose Methode wird in der abstrakten Klasse nicht gebraucht, kann aber überschrieben werden.
        /// </summary>
        public virtual void Dispose() { }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt die gewünschte Geschwindigkeit [m/s] (Sollwert)
        /// </summary>
        public abstract float Speed { get; set; }


        /// <summary>
        /// Liefert die aktuelle Geschwindigkeit [m/s] (Istwert)
        /// </summary>
        public abstract float CurrentSpeed { get; }


        /// <summary>
        /// Liefert bzw. setzt die Beschleunigung [m/s^2]
        /// </summary>
        public abstract float Acceleration { get; set; }


        /// <summary>
        /// Liefert das Statusbyte des Motorencontrollers
        /// Bit7: 0 => Motor läuft, 1 => Motor gestoppt.
        /// </summary>
        public abstract int Status { get; }


        /// <summary>
        /// Liefert die gefahrenen Ticks (28'672 pro Radumdrehung)
        /// </summary>
        public abstract int Ticks { get; }


        /// <summary>
        /// Liefert den gefahrenden Weg [m].
        /// </summary>
        public virtual float Distance
        {
            get { return (Ticks * Constants.MeterPerTick); }
        }


        /// <summary>
        /// Liefert den Status, ob der Motor läuft oder gestoppt ist.
        /// Bit7=1 => Motor off!
        /// </summary>
        public virtual bool Stopped
        {
            get { return (Status & 0x80) == 0x80; }
        }
        #endregion


        #region methods
        /// <summary>
        /// Übernimmt die Einstellungen wie Geschwindigkeit oder Beschleunigung
        /// und führt sie aus.
        /// </summary>
        public abstract void Go();


        /// <summary>
        /// Stoppt den Motor.
        /// </summary>
        public abstract void Stop();


        /// <summary>
        /// Setzt den Motorencontroller zurück
        /// </summary>
        public abstract void Reset();


        /// <summary>
        /// Setzt den Ticks-Zähler auf Null zurück
        /// </summary>
        public abstract void ResetTicks();


        /// <summary>
        /// Setzt die Werte für den PID-Regler
        /// </summary>
        /// <param name="proportional"></param>
        /// <param name="integral"></param>
        /// <param name="derivative"></param>
        /// <param name="integralLimit"></param>
        /// <param name="derivativeInterval"></param>
        public abstract void SetPID(int proportional, int integral, int derivative, int integralLimit, int derivativeInterval);
        #endregion

    }
}
