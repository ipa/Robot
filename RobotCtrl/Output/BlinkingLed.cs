using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotCtrl
{
    public enum BlinkingLeds //wird in der robotconsole gebraucht
    {
        BlinkingLed1 = 0,
        BlinkingLed2,
        BlinkingLed3,
        BlinkingLed4
    }

    public class BlinkingLed : Led
    {
        private Timer blinkingTimer;

        public BlinkingLed(DigitalOut digitalOut, BlinkingLeds led)
            : base(digitalOut, (Leds)led)
        {
            this.Frequency = 2; //default = 1 hz
        }


        public BlinkingLed(DigitalOut digitalOut, BlinkingLeds led, float Frequency)
            : base(digitalOut, (Leds)led)
        {
            
            this.Frequency = Frequency;
        }

        public float Frequency
        { get; set; }

        public override bool LedEnabled
        {
            get
            {
                return blinkingTimer != null;
            }
            set
            {
                if (value)
                {
                    if (blinkingTimer != null) blinkingTimer.Change(0, (int)(1000.0f / Frequency));
                    else blinkingTimer = new Timer(blinkingTimerCallBack, null, 0, (int)(1000.0f / Frequency));
                }
                else
                {
                    if (blinkingTimer != null) blinkingTimer.Dispose(); blinkingTimer = null;
                    base.LedEnabled = false;
                }
            }
        }

        private void blinkingTimerCallBack(object state)
        {
            base.LedEnabled = !base.LedEnabled;
        
        }
        
    }
}
