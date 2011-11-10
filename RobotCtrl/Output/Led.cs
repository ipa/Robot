//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: Led.cs 513 2011-02-17 15:17:16Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotCtrl
{

    public enum Leds
    {
        Led1 = 0,
        Led2,
        Led3,
        Led4
    }


    /// <summary>
    /// Diese Klasse bildet eine LED des Roboters ab.
    /// </summary>
    public class Led
    {

        #region members
        protected Leds led;
        protected DigitalOut digitalOut;
        
        bool oldState;
        #endregion


        #region eventhandler
        public event EventHandler<LedEventArgs> LedStateChanged;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert die gewünschte LED und verknüpft sie mit einem digitalOut-Objekt.
        /// </summary>
        /// <param name="digitalOut"></param>
        /// <param name="led"></param>
        public Led(DigitalOut digitalOut, Leds led)
        {
            this.digitalOut = digitalOut;
            this.led = led;
            this.digitalOut.DigitalOutChanged += new EventHandler(digitalOut_DigitalOutChanged);
        }

        void digitalOut_DigitalOutChanged(object sender, EventArgs e)
        {

            bool newState = LedEnabled;

            if (oldState != newState)
            {
                OnLedStateChanged(new LedEventArgs(this.led, newState));
                oldState = newState;
            }
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt den Zustand der LED (ein-/ausgeschaltet)
        /// </summary>
        public virtual bool LedEnabled
        {
            get { return digitalOut[(int)this.led]; }
            set
            {
                digitalOut[(int)this.led] = value;
            }
        }
        #endregion


        #region methods
        /// <summary>
        /// Diese Methode informiert alle registrierten Eventhandler über den Zustandswechsel 
        /// (ein-/ausgeschaltet) der LED.
        /// </summary>
        public void OnLedStateChanged(LedEventArgs e )
        {
            if (LedStateChanged != null)
            {
                LedStateChanged(this,e);
            }
        }
        #endregion

    }
}
