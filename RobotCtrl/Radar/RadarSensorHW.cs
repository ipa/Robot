//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: RadarSensorHW.cs 489 2011-02-07 13:21:01Z chj-nb $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class RadarSensorHW : RadarSensor
    {

        #region members
        private int ioAddress;
        #endregion


        #region constructor & destructor
        public RadarSensorHW(int IOAddress)
		{
            ioAddress = IOAddress;
        }
        #endregion


        #region properties
        public override float Distance { get { return IOPort.Read(ioAddress) / 100.0f; } }
        #endregion

    }
}
