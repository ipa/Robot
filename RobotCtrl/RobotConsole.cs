//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: RobotConsole.cs 564 2011-03-07 07:31:52Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{

    /// <summary>
    /// Bildet die Konsole des Roboters ab, die aus den LED's und Schaltern besteht.
    /// </summary>
    public class RobotConsole
    {

        #region members
        private Led[] leds;
        private BlinkingLed[] blinkingLeds;
        private Switch[] switches;
        private DigitalIn digitalIn;
        private DigitalOut digitalOut;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert die Roboter-Konsole mit den dazugehörigen LED's und Schalter.
        /// </summary>
        public RobotConsole(RunMode runMode)
        {
            
            if (!Constants.IsWinCE) runMode = RunMode.Virtual;

            if (runMode == RunMode.Virtual)
            {
                digitalIn = new DigitalInSim();
                digitalOut = new DigitalOutSim();

            }
            else
            {
              //  digitalIn = new DigitalInHW(Constants.IOConsoleSWITCH);
                digitalIn = new DigitalInHW(Constants.IOConsoleSWITCH);
                digitalOut = new DigitalOutHW(Constants.IOConsoleLED);
            }
            
            this.leds = new Led[4];
            for (int i = 0; i < this.leds.Length; i++)
            {
                leds[i] = new Led(digitalOut,(Leds)i);
            }

            this.blinkingLeds = new BlinkingLed[4];
            for (int i = 0; i < this.blinkingLeds.Length; i++)
            {
                blinkingLeds[i] = new BlinkingLed(digitalOut, (BlinkingLeds)i);
            }


            this.switches = new Switch[4];
            for (int i = 0; i < this.switches.Length; i++)
            {
                switches[i] = new Switch(digitalIn, (Switches)i);
            }
        }
        #endregion


        #region methods
        /// <summary>
        /// Zugriff auf die Led's per Indexer
        /// </summary>
        /// <param name="led"></param>
        /// <returns></returns>
        public Led this[Leds led]
        {
            get { return this.leds[(int)led]; }
        }


        /// <summary>
        /// Zugriff auf die Schalter per Indexer
        /// </summary>
        /// <param name="swi"></param>
        /// <returns></returns>
        public Switch this[Switches swi]
        {
            get { return this.switches[(int)swi]; }
        }

        /// <summary>
        /// Factory für Blinkingleds...
        /// </summary>
        /// <param name="led"></param>
        /// <returns></returns>
        public BlinkingLed this[BlinkingLeds led]
        {
            get { return this.blinkingLeds[(int)led]; }
        
        }
        #endregion

    }
}
