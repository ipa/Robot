//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: ViewPort.cs 757 2011-10-26 09:25:23Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotView
{
    /// <summary>
    /// ViewPort stellt einen Ausschnitt (Rechteck) dar.
    /// </summary>
    public struct ViewPort
    {
        #region members
        public double xMin;
        public double xMax;
        public double yMin;
        public double yMax;
        #endregion


        #region constructor & destructor
        public ViewPort(double xMin, double xMax, double yMin, double yMax)
        {
            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert die Breite des Rechtecks.
        /// </summary>
        public double Width { get { return xMax - xMin; } }


        /// <summary>
        /// Liefert die Höhe des Rechtecks.
        /// </summary>
        public double Height { get { return yMax - yMin; } }
        #endregion
    }
}
