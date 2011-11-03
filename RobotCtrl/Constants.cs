//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: Constants.cs 607 2011-03-20 13:40:50Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public enum RunMode { Virtual, Real };

    public static class Constants
    {

        public static bool IsWinCE { get { return Environment.OSVersion.Platform == PlatformID.WinCE; } }


        public const float maxSpeed = 2.0f; //[m/s]

        // Roboter-Kennzahlen
        public const float WheelDiameter = 0.076f;
        public const float AxleLength = 0.263f;
        public const float HalfAxleLength = AxleLength / 2.0f;
        public const float LengthPerDegree = (float)(AxleLength * Math.PI) / 360.0f;
        public const int TicksPerRevolution = 28672;
        public const float WheelCircumference = (float)(Math.PI * WheelDiameter);
        public const float MeterPerTick = WheelCircumference / TicksPerRevolution;
        public const float Width = 0.28f;
        public const float HalfWidth = Width / 2;

        // IO-Adressen
        public const int IOConsoleLED = 0xF303;
        public const int IOConsoleSWITCH = 0xF303;
        public const int IORadarSensor = 0xF310;
        public const int IODriveCtrl = 0xF330;
        public const int IOMotorCtrlRight = 0xF320;
        public const int IOMotorCtrlLeft = 0xF328;

    }
}
