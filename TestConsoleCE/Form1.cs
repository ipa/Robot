using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace TestConsoleCE
{
    public partial class Form1 : Form
    {

        private RobotConsole rc;

        #region constructor
        public Form1()
        {
            InitializeComponent();

            rc = new RobotConsole(RunMode.Real);
            consoleView1.RobotConsole = rc;
            

            rc[Switches.Switch1].SwitchStateChanged += SwitchStateChanged;
            rc[Switches.Switch2].SwitchStateChanged += SwitchStateChanged;
            rc[Switches.Switch3].SwitchStateChanged += SwitchStateChanged;
            rc[Switches.Switch4].SwitchStateChanged += SwitchStateChanged;

            
        }
        #endregion

        #region methods
        void SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            rc[(Leds)(int)e.Swi].LedEnabled = e.SwitchEnabled;
            
        }
        #endregion

        public RobotConsole RobotConsole
        {
            get { return rc; }
            set { rc = value; }
        }

        private void consoleView1_Click(object sender, EventArgs e)
        {

        }
    }
}