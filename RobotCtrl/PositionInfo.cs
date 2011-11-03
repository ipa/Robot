//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: PositionInfo.cs 625 2011-03-22 06:58:34Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public struct PositionInfo
    {
        public float X;
        public float Y;
        public float Angle;

        public PositionInfo(float x, float y, float angle)
        {
            X = x;
            Y = y;
            Angle = angle;
        }
    }
}
