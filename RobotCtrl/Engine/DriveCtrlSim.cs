//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: DriveCtrlSim.cs 735 2011-10-13 09:16:14Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class DriveCtrlSim : DriveCtrl
    {

        #region members
        private int status;
        #endregion


        #region constructor & destructor
        public DriveCtrlSim()
        {
            Reset();
        }
        #endregion


        #region properties
        public override int DriveState
        {
            get { return this.status; }
            protected set { this.status = value; }
        }
        #endregion


        #region methods
        public override void Reset()
        {
            this.status = 0;
        }
        #endregion

    }
}
