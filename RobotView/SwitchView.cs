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
    public partial class SwitchView : UserControl
    {

        private bool state;

        private Switch switcher;

        public SwitchView()
        {
            InitializeComponent();
            State = false;
        }

        public bool State
        {
            get { return state; }
            set
            {
                state = value;
                pictureBox1.Image = value ? Resource.SwitchOn : Resource.SwitchOff;
            }
        }

        public Switch Switch
        {
            get { return switcher; }
            set
            {
                if (switcher != null) switcher.SwitchStateChanged -= SwitchStateChanged;
                switcher = value;
                if (switcher != null) switcher.SwitchStateChanged += SwitchStateChanged;
            }
        }

        private void SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler<SwitchEventArgs>(SwitchStateChanged), new object[]{sender,e});
            }
            else
            {
                State = e.SwitchEnabled;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (switcher != null) switcher.SwitchEnabled = !switcher.SwitchEnabled;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (Switch != null)
            {
                Switch.SwitchEnabled = !Switch.SwitchEnabled;
            }
        }
    }
}
