//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: DriveCtrlView.cs 735 2011-10-13 09:16:14Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotView
{
    public partial class DriveCtrlView : UserControl
    {

        #region constructor & destructor
        public DriveCtrlView()
        {
            InitializeComponent();
        }
        #endregion


        #region properties
        public DriveCtrl DriveCtrl { get; set; }
        #endregion


        #region methods
        private void checkBoxDriveCtrlRight_CheckStateChanged(object sender, EventArgs e)
        {
            if (DriveCtrl != null) DriveCtrl.PowerRight = checkBoxDriveCtrlRight.Checked;
        }

        private void checkBoxDriveCtrlLeft_CheckStateChanged(object sender, EventArgs e)
        {
            if (DriveCtrl != null) DriveCtrl.PowerLeft = checkBoxDriveCtrlLeft.Checked;
        }

        private void buttonResetDriveCtrl_Click(object sender, EventArgs e)
        {
            if (DriveCtrl != null) DriveCtrl.Reset();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Update DriveCtrl
            if (DriveCtrl != null)
            {
                textBoxDriveCtrlStatus.Text = "0x" + DriveCtrl.DriveState.ToString("X2");
                checkBoxDriveCtrlLeft.Checked = DriveCtrl.PowerLeft;
                checkBoxDriveCtrlRight.Checked = DriveCtrl.PowerRight;
            }
        }
        #endregion
    }
}
