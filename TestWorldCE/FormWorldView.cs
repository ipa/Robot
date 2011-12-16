using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RobotView;
using RobotCtrl;

namespace TestWorldCE
{
    public partial class FormWorldView : Form
    {
        public FormWorldView(int xMin, int yMin, int xMax, int yMax)
        {
            InitializeComponent();
            ViewPort p = new ViewPort(xMin, xMax, yMin, yMax);
            this.ViewPort = p;
    
            
            
        }

        public void SaveImage(string filename)
        {
            this.worldView1.Invoke(
            new Action<string>(this.worldView1.SaveImage)
        ,new object[]{filename});
        }


        public ViewPort ViewPort
        {
            get { return this.worldView1.ViewPort; }
            set { this.worldView1.ViewPort = value; }
        }
    }
}