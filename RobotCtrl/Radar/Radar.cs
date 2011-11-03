//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: Radar.cs 643 2011-03-28 19:15:54Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class Radar
    {

        #region members
        private RadarSensor sensor;
        private PositionInfo antennaPosition;
        #endregion


        #region constructor & destructor
        public Radar(RunMode mode)
        {
            if (!Constants.IsWinCE) mode = RunMode.Virtual;
            if (mode == RunMode.Virtual)
            {
                sensor = new RadarSensorSim();
            }
            else
            {
                sensor = new RadarSensorHW(Constants.IORadarSensor);
            }
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert die gemessene Distanz zum nächsten Objekt [m]
        /// </summary>
        public float Distance { get { return sensor.Distance; } }


        /// <summary>
        /// Liefert bzw. setzt die Position des Ultraschall Distanzsensors am Roboter
        /// </summary>
        public PositionInfo AntennaPosition { get { return antennaPosition; } set { antennaPosition = value; } }
        #endregion

    }
}
