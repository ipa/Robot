//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: DriveInfo.cs 489 2011-02-07 13:21:01Z chj-nb $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public struct DriveInfo
    {

        #region members
        public PositionInfo Position;
        public float Runtime;
        public float SpeedL;
        public float SpeedR;
        public float DistanceL;
        public float DistanceR;
        public int DriveStatus;
        public int MotorStatusL;
        public int MotorStatusR;
        #endregion


        public DriveInfo(PositionInfo position,
            float runtime,
            float speedL, float speedR,
            float distanceL, float distanceR,
            int driveStatus,
            int motorStatusL, int motorStatusR
            )
        {
            Position = position;
            Runtime = runtime;
            SpeedL = speedL;
            SpeedR = speedR;
            DistanceL = distanceL;
            DistanceR = distanceR;
            DriveStatus = driveStatus;
            MotorStatusL = motorStatusL;
            MotorStatusR = motorStatusR;
        }

    }
}
