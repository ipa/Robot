using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobotDriveProtocol;

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
            Command cmd = new Command();

            if (tabControl.SelectedTab == tpgTrackLine)
            {

                //RunLine(float length, float speed, float acceleration)
                
                cmd.Method = "RunLine";
                cmd.Parameters(new CommandParam()
                {
                    Parameter = float.Parse(txtTrackLineLength.Text),
                    Type = typeof(float)
                });
                cmd.Parameters(new CommandParam()
                {
                    Parameter = 1.0f,
                    Type = typeof(float)
                });
                cmd.Parameters(new CommandParam()
                {
                    Parameter = 1.0f,
                    Type = typeof(float)
                });
            
            }
            else if (tabControl.SelectedTab == tpgTrackTurn)
            {
                lstCommands.Items.Add("trackturn");
            
            }
            else if (tabControl.SelectedTab == tpgTrackArc)
            {
                lstCommands.Items.Add("trackarc");
            }

            lstCommands.Items.Add(cmd);
        }

        private void tbgTrackArc_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Command> elCommandos = lstCommands.Items.OfType<Command>().ToList();
            
        }
    }
}
