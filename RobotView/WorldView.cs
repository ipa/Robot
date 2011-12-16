//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: WorldView.cs 757 2011-10-26 09:25:23Z zajost $
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
using System.IO;

namespace RobotView
{

    /// <summary>
    /// Diese Klasse visualisiert einen Ausschnitt der Welt
    /// </summary>
    public partial class WorldView : UserControl
    {

        #region members
        private Bitmap plot;
        private Pen penGrid1;
        private Pen penGrid2;
        private Pen penGrid0;
        private Pen penAngle;
        private Pen penRadar;
        private SolidBrush brushRobot;
        private float BoxToMeters = 0.5f;
        private ViewPort viewPort;
        #endregion


        #region constructor & destructor
        public WorldView()
        {
            penGrid1 = new Pen(Color.Gray, 3);
            penGrid0 = new Pen(Color.Gray, 1);
            penGrid2 = new Pen(Color.Gray, 2);
            penAngle = new Pen(Color.Black, 7);
            penRadar = new Pen(Color.Green, 9);

            brushRobot = new SolidBrush(Color.Gray);

            viewPort = new ViewPort(-1, 4, -2, 2);
            
            InitializeComponent();

            System.Threading.Timer t = new System.Threading.Timer(t_Tick, null, 200, 200);
            

            /*Timer t = new Timer();
            t.Interval = 100;
            t.Tick +=new EventHandler(t_Tick);
            t.Enabled = true;*/

        }

        void t_Tick(object sender)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(Invalidate));
            }
            else
            {
                this.Invalidate();
            }
        }
        #endregion
        
        
        
        
        #region properties
        /// <summary>
        /// Liefert die Farbe für den Roboter
        /// </summary>
        private SolidBrush BrushRobot
        {
            get
            {
                if (World.Robot != null)
                {
                    if (World.Robot.Color != brushRobot.Color)
                    {
                        brushRobot = new SolidBrush(World.Robot.Color);
                    }
                }
                return brushRobot;
            }
        }


        /// <summary>
        /// Liefert bzw. setzt den Ausschnitt, den die WorldView darstellen soll
        /// </summary>
        public ViewPort ViewPort
        {
            get { return viewPort; }
            set
            {
                viewPort = value;
                UpdateView();
            }
        }
        #endregion


        #region methods

        public void SaveImage(string filename)
        {
            UpdateView();
            File.Delete(filename);
            this.pictureBox.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        /// <summary>
        /// Sorgt dafür, dass der Inhalt neu gezeichnet wird, falls die Grösse
        /// der WorldView verändert wird.
        /// </summary>
        /// 
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateView();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateView();
            base.OnPaint(e);
            
            
        }

       
        /// <summary>
        /// Mapt eine Nummer von einem Range in einen anderen
        /// xMin - xMax = Referenzrahmen des jetzigen Werts
        /// yMin - YMax = Refrenzrahmen des zukünftigen Werts
        /// value = jetziger wert
        /// <param name="value">wert</param>
        /// <param name="xMax">Maximum des jetzigen Ranges</param>
        /// <param name="xMin">Minimum des jetzigen Ranges</param>
        /// <param name="yMax">Maximum des zukünftigen Ranges</param>
        /// <param name="yMin">Minimum des zukünftigen Ranges</param>
        /// </summary>      
        private double map(double xMin, double xMax, double yMin, double yMax, double value)
        {
            return ((yMax - yMin) / (xMax - xMin) * (value - xMin)) + yMin;
        }

        /// <summary>
        /// Berechnet aus einer x-Pos [m] im Weltkoordinatensystem 
        /// eine x-Pos [Pixel] im Koordinatensystem der WorldView
        /// </summary>
        /// <param name="x">die x-Position im Weltkoordinatensystem in Meter</param>
        /// <returns>die x-Position im WorldView-Koordinatensystem in Pixel</returns>
        private int XtoScreen(double x)
        {
            return (int)map(this.viewPort.xMin, this.viewPort.xMax, 0, this.Width, x);
        }


        /// <summary>
        /// Berechnet aus einer y-Pos [m] im Weltkoordinatensystem 
        /// eine y-Pos [Pixel] im Koordinatensystem der WorldView
        /// </summary>
        /// <param name="y">die y-Position im Weltkoordinatensystem in Meter</param>
        /// <returns>die y-Position im WorldView-Koordinatensystem in Pixel</returns>
        private int YtoScreen(double y)
        {
            // ToDo (Dreisatzrechnung)
            return (int)map(this.viewPort.yMax, this.viewPort.yMin, 0, this.Height, y);
        }


        /// <summary>
        /// Berechnet aus einer Distanz [m] in x-Richtung die Anzahl
        /// Pixel im Koordinatensystem der WorldView.
        /// </summary>
        /// <param name="width">die Distanz/Strecke in Metern</param>
        /// <returns>die Anzahl Pixel, die dieser Distanz/Strecke entsprechen</returns>
        private int WidthToScreen(float width)
        {
            // ToDo
            return (int)map(this.viewPort.xMin, this.viewPort.xMax, 0, this.Width, width+this.viewPort.xMin);
        }


        /// <summary>
        /// Berechnet aus einer Distanz [m] in y-Richtung die Anzahl
        /// Pixel im Koordinatensystem der WorldView.
        /// </summary>
        /// <param name="height">die Distanz/Strecke in Metern</param>
        /// <returns>die Anzahl Pixel, die dieser Distanz/Strecke entsprechen</returns>
        private int HeightToScreen(float height)
        {
            // ToDo
            return (int)map(this.viewPort.yMin, this.viewPort.yMax, 0, this.Height, height + this.viewPort.yMin);
        }


        /// <summary>
        /// Aktualisiert die View, d.h. es wird in ein Bitmap gezeichnet und
        /// anschliessend das Bitmap in der PictureBox dargestellt.
        /// Folgende Objekte werden gezeichnet:
        /// - Hindernis
        /// - Koordinaten-Netz
        /// - Roboter
        /// - Radar
        /// </summary>
        private void UpdateView()
        {
            // Verhindert Exception falls Fenster auf 0 verkleinert wird.
            if (pictureBox.Width == 0 || pictureBox.Height == 0) return;

            // Verhindert Designer-Absturz falls ViewPort auf 0 gesetzt wird.
            if (viewPort.Width == 0 || viewPort.Height == 0) return;

            // Bitmap erstellen auf das die WorldView gezeichnet werden kann
            if ((plot == null) || (plot.Size != pictureBox.Size))
            {
                plot = new Bitmap(pictureBox.Width, pictureBox.Height);
            }

            using (Graphics g = Graphics.FromImage(plot))
            {

                // Hintergrund löschen
                g.Clear(Color.White);

                // Map
                ObstacleMap obstMap = World.ObstacleMap;
                if (World.ObstacleMap != null)
                {
                    Bitmap bmp = obstMap.Image;
                    RectangleF area = obstMap.Area;
                  

                    int rx1 = XtoScreen(area.Left);
                    int ry1 = YtoScreen(area.Bottom );
                    int rx2 = XtoScreen(area.Right );
                    int ry2 = YtoScreen(area.Top );
                    g.DrawImage(
                        bmp,
                        new Rectangle(rx1, ry1, (rx2 - rx1), (ry2 - ry1)),
                        new Rectangle(0, 0, bmp.Width, bmp.Height),
                        GraphicsUnit.Pixel);
                 }


                #region Koordinaten-Netz zeichnen
                // TODO Grid zeichnen
                // Vertikale Linien die >viewPort.xMin bzw. <viewPort.xMax sind zeichnen...
                for (int i = (int)Math.Ceiling(viewPort.xMin); i <( (int)Math.Floor(this.viewPort.xMax))*2; i++)
                {
                    
                    Pen pen = i == 0 ? penGrid0 : penGrid2;

                    g.DrawLine(pen, XtoScreen(i/2.0f), 0, XtoScreen(i/2.0f), this.Height);
                }

                // Horizontale Linien >viewPort.yMin bzw. <viewPort.yMax sind zeichnen...
                for (int i = (int)Math.Ceiling(viewPort.yMin); i < ((int)Math.Floor(this.viewPort.yMax))*2; i++)
                {
                    Pen pen = i == 0 ? penGrid1 : penGrid2;
                    g.DrawLine(pen, 0, YtoScreen(i/2.0f), this.Width, YtoScreen(i/2.0f));
                }

                #endregion


                Robot robot = World.Robot;


                double phi = (robot.Position.Angle) * (Math.PI / 180.0);
                if (robot != null)
                {
                    #region Roboter zeichnen
                    

                    g.FillEllipse(new SolidBrush(robot.Color),
                                     (int)(this.XtoScreen(robot.Position.X) - (this.WidthToScreen(Constants.Width) / 2.0)),
                                     (int)(this.YtoScreen(robot.Position.Y) - (this.HeightToScreen(Constants.Width) / 2.0)),
                                     this.WidthToScreen(Constants.Width),
                                     this.HeightToScreen(Constants.Width)
                                     );

                    g.DrawLine(new Pen(Color.Black, 1.0f),
                                   (int)this.XtoScreen(robot.Position.X), //+ (int)(this.WidthToScreen(Constants.Width) / 2.0),
                                   (int)this.YtoScreen(robot.Position.Y), //+ (int)(this.HeightToScreen(Constants.Width) / 2.0),
                                   (int)(this.XtoScreen(robot.Position.X) + Math.Cos(phi) * (this.WidthToScreen(Constants.Width) / 2.0)),

                                   (int)(this.YtoScreen(robot.Position.Y) + Math.Sin(phi) * (this.HeightToScreen(Constants.Width) / 2.0))
                                   );

                    #endregion
                }

                // Roboter.Radar
                PositionInfo radarOffset = robot.Radar.AntennaPosition;
                PositionInfo pos = robot.Position;
                PositionInfo radarPos = new PositionInfo(
                pos.X + radarOffset.X * (float)Math.Cos(phi) - radarOffset.Y * (float)Math.Sin(phi),
                pos.Y + radarOffset.X * (float)Math.Sin(phi) + radarOffset.Y * (float)Math.Cos(phi),
                (pos.Angle + radarOffset.Angle) % 360);
                double radarPhi = radarPos.Angle / 180.0 * Math.PI;
                double distance = robot.Radar.Distance;

                // Radarstrahl zeichnen...
                g.DrawLine(penRadar, XtoScreen(radarPos.X), YtoScreen(radarPos.Y),
                XtoScreen(radarPos.X + distance * Math.Cos(radarPhi)),
                YtoScreen(radarPos.Y + distance * Math.Sin(radarPhi)));

                //Pfad zeichnen
                PositionInfo[] path = robot.GetPath();
                Pen penPath = new Pen(Color.Blue,1);
                for (int i = 0; i < path.Length-1; i++)
                {

                    int x1 = XtoScreen(path[i].X);
                    int y1 = YtoScreen(path[i].Y);

                    int x2 = XtoScreen(path[i + 1].X);
                    int y2 = YtoScreen(path[i + 1].Y);

                    g.DrawLine(penPath, x1, y1, x2, y2);


                }


            }

            pictureBox.Image = plot;
            
        }
        #endregion
    }
}
