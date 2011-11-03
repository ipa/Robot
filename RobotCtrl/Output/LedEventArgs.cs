//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: LedEventArgs.cs 513 2011-02-17 15:17:16Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    /// <summary>
    /// EventArgs-Klasse um über Änderungen der LED's zu informieren.
    /// </summary>
    public class LedEventArgs : EventArgs
    {

        #region constructor & destructor
        /// <summary>
        /// Initialisiert die LedEventArgs-Klasse
        /// </summary>
        /// <param name="led">die betroffene LED</param>
        /// <param name="ledEnabled">der Zustand dieser LED</param>
        public LedEventArgs(Leds led, bool ledEnabled)
        {
            Led = led;
            LedEnabled = ledEnabled;
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt den Zustand (ein-/ausgeschaltet) der LED
        /// </summary>
        public bool LedEnabled { get; set; }


        /// <summary>
        /// Liefert bzw. setzt die betroffene LED
        /// </summary>
        public Leds Led { get; set; }
        #endregion

    }
}
