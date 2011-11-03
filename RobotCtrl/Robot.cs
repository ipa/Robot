using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RobotCtrl
{
    public class Robot
    {

        public Color Color
        {
            get;
            set;
        }

        public PositionInfo Position
        { get {return drv.Position; } }

        public Drive drv {get;set;}

    }
}
