using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobotDriveProtocol;
using TA.Bluetooth;
using System.IO;

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
                cmd.Parameters.Add(float.Parse(txtTrackLineLength.Text));

                cmd.Parameters.Add(1.0f);
                
                cmd.Parameters.Add(1.0f);
            
            }
            else if (tabControl.SelectedTab == tpgTrackTurn)
            {
                // RunTurn(float angle, float speed, float acceleration)
                cmd.Method = "RunTurn";
                cmd.Parameters.Add(float.Parse(txtTrackTurnAngle.Text));

                cmd.Parameters.Add(1.0f);

                cmd.Parameters.Add(1.0f);
            
            }
            else if (tabControl.SelectedTab == tpgTrackArc)
            {
                //     public void RunArcLeft(float radius, float angle, float speed, float acceleration)
       
                if (rbnTrackArcLeft.Checked)
                {
                    cmd.Method = "RunArcLeft";
                }
                else if (rbnTrackArcRight.Checked)
                {
                    cmd.Method = "RunArcRight";
                }

                cmd.Parameters.Add(float.Parse(txtTrackArcRadius.Text));
                cmd.Parameters.Add(float.Parse(txtTrackArcAngle.Text));
                cmd.Parameters.Add(1.0f);
                cmd.Parameters.Add(1.0f);

            }

            lstCommands.Items.Add(cmd);
        }

        private void tbgTrackArc_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {try
                {
            Guid service = BluetoothServiceList.Robot09;
            List<Command> elCommandos = lstCommands.Items.OfType<Command>().ToList();

            TA.Bluetooth.BluetoothClient bc = BluetoothDevice.Connect(((RobotItem)cbxRobot.SelectedItem).mac, service);

            if (bc != null && bc.IsConnected())
            {
                 
                  

                    // read transmitted data
                    
                    StreamWriter sw = new StreamWriter(bc.GetStream());
                    // request
                    
                    sw.WriteLine(CommandSerializer.Serialize(elCommandos));
                    sw.Flush();
                    // print 
                    bc.Close();
                    MessageBox.Show("Data sent!");
               
            }
            else
            {
                MessageBox.Show("No Device found");
            }
                }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        }

        public class RobotItem
        {
            public RobotItem(string name, string mac)
            {
                this.mac = mac;
                this.name = name;
            }
            public string mac;
            public string name;

            public override string ToString()
            {
                return name;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
             cbxRobot.Items.Add(new RobotItem("HSLU_01", "001BDC002157"));
             cbxRobot.Items.Add(new RobotItem("HSLU_02", "001BDC0FFDEF"));
             cbxRobot.Items.Add(new RobotItem("HSLU_03", "001BDC0021C4"));
             cbxRobot.Items.Add(new RobotItem("HSLU_04", "001BDC0F8F39"));
             cbxRobot.Items.Add(new RobotItem("HSLU_05", "001BDC00202F"));
             cbxRobot.Items.Add(new RobotItem("HSLU_06", "001BDC0003CC"));
             cbxRobot.Items.Add(new RobotItem("HSLU_07", "001BDC002140"));
             cbxRobot.Items.Add(new RobotItem("HSLU_08", "001BDC0FFEDE"));
             cbxRobot.Items.Add(new RobotItem("HSLU_09", "001BDC0FFE1C"));
             cbxRobot.Items.Add(new RobotItem("HSLU_10", "001BDC000023"));
             cbxRobot.Items.Add(new RobotItem("HSLU_11", "001BDC0021F1"));
             cbxRobot.Items.Add(new RobotItem("HSLU_12", "001BDC002145"));
             cbxRobot.Items.Add(new RobotItem("HSLU_13", "001BDC00034C"));
             cbxRobot.Items.Add(new RobotItem("HSLU_14", "001BDC002139"));
             cbxRobot.Items.Add(new RobotItem("HSLU_15", "001BDC0FF453"));
             cbxRobot.Items.Add(new RobotItem("HSLU_16", "001BDC0022D5"));
             cbxRobot.Items.Add(new RobotItem("HSLU_17", "001BDC0022D6"));
             cbxRobot.Items.Add(new RobotItem("HSLU_18", "001BDC00212A"));
             cbxRobot.Items.Add(new RobotItem("HSLU_19", "001BDC0FFDED"));
             cbxRobot.Items.Add(new RobotItem("HSLU_20", "001BDC0FF360"));
             cbxRobot.Items.Add(new RobotItem("HSLU_21", "001BDC0FE81D"));
             cbxRobot.Items.Add(new RobotItem("HSLU_25", ""));
             cbxRobot.Items.Add(new RobotItem("HSLU_30", "001BDC0021D1"));

            
        }
    }
}
