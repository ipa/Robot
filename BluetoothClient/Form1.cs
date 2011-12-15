using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BluetoothClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDeleteCommand_Click(object sender, EventArgs e)
        {
            lstCommands.Items.Remove(lstCommands.SelectedItem);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tpgTrackLine)
            {
                lstCommands.Items.Add("trackline");
            
            }
            else if (tabControl.SelectedTab == tpgTrackTurn)
            {
                lstCommands.Items.Add("trackturn");
            
            }
            else if (tabControl.SelectedTab == tpgTrackArc)
            {
                lstCommands.Items.Add("trackarc");
            }
        }

        private void tbgTrackArc_Click(object sender, EventArgs e)
        {

        }
    }
}
