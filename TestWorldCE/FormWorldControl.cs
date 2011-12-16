using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;
using BTServer;
using Http;
using System.IO;
using System.Reflection;

namespace TestWorldCE
{
    public partial class FormWorldControl : Form
    {

        private const int xMin = 0;
        private const int xMax = 10;
        private const int yMin = 0;
        private const int yMax = 10;
        FormWorldView view;

        public FormWorldControl()
        {
            InitializeComponent();
            RunMode actualMode = Constants.IsWinCE ? RunMode.Real : RunMode.Virtual;
            Drive drv = new Drive(actualMode);
            Robot r = new Robot(actualMode);
            drv.DriveCtrl.Power = true;
            drv.DriveCtrl.PowerLeft = true;
            drv.DriveCtrl.PowerRight = true;
            
            this.runLineView1.drive = drv;
            this.driveView1.Drive = drv;
            this.trackArc1.drive = drv;
            this.trackTurnView1.drive = drv;
            
            r.ConfigurePathRecording(0.05f, 0.1f);

            drv.Position = new PositionInfo(5.0f, 5.0f, 0.0f);

            r.drv = drv;
            r.Color = Color.Red;
            World.Robot = r;

            r.SwitchStateChanged += new EventHandler<SwitchEventArgs>(r_SwitchStateChanged);
            RobotConsole rc = r.RobotConsole;
           
            consoleView1.RobotConsole = rc;

            if (r.RunMode == RunMode.Virtual)
            {
                World.ObstacleMap = new ObstacleMap(RobotView.Resource.ObstacleMap1c, xMin-0.25f, xMax+0.25f, yMin-0.25f, yMax-0.25f); //korrektur wg. doofen bildern
            }

            view = new FormWorldView(xMin, yMin, xMax, yMax);
            view.ViewPort = new RobotView.ViewPort(xMin, xMax, yMin, yMax);
            view.Show();

            this.StartServices();
        }

        private void StartServices()
        {
            BluetoothServer.StartServer();
            HttpServer.StartServer();
        }

        void r_SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            if (e.Swi == Switches.Switch2 && e.SwitchEnabled)
            {
                 String htdocs = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase),"htdocs");
                view.SaveImage(Path.Combine(htdocs,"image.bmp"));
                view.SaveImage(@"\CompactFlash\Ftp\image.bmp");
            }
        }
    }
}