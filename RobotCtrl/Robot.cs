using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RobotCtrl
{
    public class Robot
    {
        public Robot(RunMode runMode)
        {
            this.RunMode = runMode;
            this.Radar = new Radar(runMode);
        }

        public RunMode RunMode
        { get; set; }

        public Color Color
        { get; set; }

        public PositionInfo Position
        { get {return drv.Position; } }

        public Drive drv {get;set;}

        public Radar Radar { get; set; }

    }
}
