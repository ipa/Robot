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

        public  BluetoothDevice DiscoverDev(Guid service)
        {
            // search for reachable devices
            BluetoothDiscovery discovery = new BluetoothDiscovery();

            // Search for maximum 12 devices
            // Exclude paired devices
            // Exclude remebered devices
            // Include unknown devices
            BluetoothDeviceCollection bdc =
                discovery.DiscoverDevices(12,true,true,true);
            
            lstBluetooth.Items.Clear();
            foreach (BluetoothDevice device in bdc)
            {
                if (device.HasService(service))
                {
                 //   MessageBox.Show(device.Name + ";" + device.DeviceAddress);
                    lstBluetooth.Items.Add("+ " + device.DeviceAddress);
                    return device;
                }
                else
                {
                    lstBluetooth.Items.Add("- " + device.DeviceAddress);
                }
            }
            MessageBox.Show("Required service does not exist on target");
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {try
                {
            Guid service = BluetoothServiceList.Robot09;
            List<Command> elCommandos = lstCommands.Items.OfType<Command>().ToList();
            BluetoothDevice device = DiscoverDev(service);

            if (device != null)
            {
                
                    // connect to desired service
                    TA.Bluetooth.BluetoothClient bc = device.Connect(service);

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
    }
}
