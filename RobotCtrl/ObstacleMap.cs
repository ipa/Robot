//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: ObstacleMap.cs 652 2011-03-30 13:01:56Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RobotCtrl
{
    /// <summary>
    /// Diese Klasse bildet die Hinderniskarte ab.
    /// </summary>
    public class ObstacleMap
    {
        #region members
        private const double maxLength = 2.55;
        private bool[,] obstaclePixel;
        private Bitmap image;
        private int imageWidth;
        private int imageHeight;
        private RectangleF area;
        private object SyncRoot = new object();
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Erstellt eine neue Hinderniskarte und bildet diese auf 
        /// ein Koordinatensystem am (Mapping).
        /// </summary>
        /// 
        /// <param name="image">das Bild mit dem Hindernis</param>
        /// <param name="area">dazugehörige Fläche im Koordinatensystem,
        /// ausgehend von der linken unteren Ecke!</param>
        public ObstacleMap(Bitmap image, RectangleF area)
        {
            SetImage(image);


            this.area = area;
        }


        /// <summary>
        /// Erstellt eine neue Hinderniskarte und bildet diese auf 
        /// ein Koordinatensystem ab (Mapping).
        /// </summary>
        /// 
        /// <param name="image">das Bild mit dem Hindernis</param>
        /// <param name="xMin">kleinste x-Pos im Koordinatensystem</param>
        /// <param name="xMax">grösste x-Pos im Koordinatensystem</param>
        /// <param name="yMin">kleinste y-Pos im Koordinatensystem</param>
        /// <param name="yMax">grösste y-Pos im Koordinatensystem</param>
        public ObstacleMap(Bitmap image, float xMin, float xMax, float yMin, float yMax)
            : this(image, new RectangleF(xMin, yMin, xMax - xMin, yMax - yMin)) { }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt das Bild mit dem Hindernis.
        /// </summary>
        public Bitmap Image
        {
            get { lock (SyncRoot) { return image; } }
            set { lock (SyncRoot) { SetImage(value); } }
        }


        public RectangleF Area
        {
            get { return area; }
            set { area = value; }
        }
        #endregion


        #region methods
        /// <summary>
        /// Liefert die Information, wie weit das nächste Hindernist entfernt ist.
        /// </summary>
        /// <param name="position">die aktuelle (eigene) Position inkl. Blickrichtung</param>
        /// <returns>Die Distanz zum nächsten Hindernis in Blickrichtung</returns>
        public double GetFreeSpace(PositionInfo position)
        {
            lock (SyncRoot)
            {
                // Hindernis-Suche mit Bresenham-Algorithmus
                int x1 = xToIndex(position.X);
                int y1 = yToIndex(position.Y);
                int x2 = xToIndex(position.X + maxLength * Math.Cos(position.Angle / 180 * Math.PI));
                int y2 = yToIndex(position.Y + maxLength * Math.Sin(position.Angle / 180 * Math.PI));

                int dx = x2 - x1;
                int dy = y2 - y1;
                int absDx = Math.Abs(dx);
                int absDy = Math.Abs(dy);
                int incX = Math.Sign(dx);
                int incY = Math.Sign(dy);
                int x = x1, y = y1, err = 0;
                if (absDx >= absDy)
                {
                    err = -absDx / 2;
                    for (x = x1; x != x2; x = x + incX)
                    {
                        if ((x >= 0) && (x < imageWidth) &&
                            (y >= 0) && (y < imageHeight) &&
                            obstaclePixel[y, x])
                            break;
                        else
                        {
                            err += absDy;
                            if (err >= 0)
                            {
                                y += incY;
                                err -= absDx;
                            }
                        }
                    }
                }
                else
                {
                    err = -absDy / 2;
                    for (y = y1; y != y2; y = y + incY)
                    {
                        if ((x >= 0) && (x < imageWidth) &&
                            (y >= 0) && (y < imageHeight) &&
                            obstaclePixel[y, x])
                            break;
                        else
                        {
                            err += absDx;
                            if (err >= 0)
                            {
                                x += incX;
                                err -= absDy;
                            }
                        }
                    }
                }
                double xSpace = (x - x1) * area.Width / imageWidth;
                double ySpace = (y - y1) * area.Height / imageHeight;
                return Math.Sqrt(xSpace * xSpace + ySpace * ySpace);
            }
        }


        int xToIndex(double x)
        {
            int index = (int)((x - area.X) * imageWidth / area.Width);
            return index;
        }


        int yToIndex(double y)
        {
            int index = imageHeight - (int)((y - area.Y) * imageHeight / area.Height);
            return index;
        }


        /// <summary>
        /// Setzt ein Bild und berechnet anschliessend die Hindernispixel.
        /// </summary>
        /// <param name="image">Das Bild mit dem Hindernis</param>
        void SetImage(Bitmap image)
        {
            if (this.image != null) this.image.Dispose();
            this.image = image;
            imageWidth = image.Width;
            imageHeight = image.Height;

            CreateObstaclePixel();
        }


        /// <summary>
        /// Erstellt ein Boolean-Array mit den Hindernispixel.
        /// Das Array ist 2-Dimensional und gleich gross wie das Hindernisbild.
        /// Anschliessend wird Pixel für Pixel analysiert und dessen Helligkeit
        /// bestimmt. Der Schwellwert liegt bei 128. Ist die Helligkeit der
        /// drei Farben RGB im Durchschnitt kleiner als 128, so handelt es
        /// sich um ein Hindernis. Ansonsten ist es kein Hindernis.
        /// </summary>
        private void CreateObstaclePixel()
        {
            obstaclePixel = new bool[image.Height, image.Width];
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color c = image.GetPixel(x, y);
                    obstaclePixel[y, x] = (c.R + c.G + c.B) / 3 < 128;
                }
            }
        }
        #endregion
    }
}
