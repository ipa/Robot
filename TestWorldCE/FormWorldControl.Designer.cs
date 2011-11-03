namespace TestWorldCE
{
    partial class FormWorldControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.runLineView1 = new RobotView.RunLineView();
            this.trackArc1 = new RobotView.TrackArc();
            this.trackTurnView1 = new RobotView.TrackTurnView();
            this.driveView1 = new RobotView.DriveView();
            this.driveCtrlView1 = new RobotView.DriveCtrlView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(697, 261);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.runLineView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(689, 232);
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.trackArc1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(689, 232);
            this.tabPage2.Text = "tabPage2";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.trackTurnView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(689, 232);
            this.tabPage3.Text = "tabPage3";
            // 
            // runLineView1
            // 
            this.runLineView1.drive = null;
            this.runLineView1.Location = new System.Drawing.Point(15, 16);
            this.runLineView1.Name = "runLineView1";
            this.runLineView1.Size = new System.Drawing.Size(488, 140);
            this.runLineView1.TabIndex = 1;
            // 
            // trackArc1
            // 
            this.trackArc1.drive = null;
            this.trackArc1.Location = new System.Drawing.Point(7, 12);
            this.trackArc1.Name = "trackArc1";
            this.trackArc1.Size = new System.Drawing.Size(369, 204);
            this.trackArc1.TabIndex = 0;
            // 
            // trackTurnView1
            // 
            this.trackTurnView1.drive = null;
            this.trackTurnView1.Location = new System.Drawing.Point(24, 37);
            this.trackTurnView1.Name = "trackTurnView1";
            this.trackTurnView1.Size = new System.Drawing.Size(384, 157);
            this.trackTurnView1.TabIndex = 0;
            // 
            // driveView1
            // 
            this.driveView1.Drive = null;
            this.driveView1.Location = new System.Drawing.Point(19, 422);
            this.driveView1.Name = "driveView1";
            this.driveView1.Size = new System.Drawing.Size(290, 300);
            this.driveView1.TabIndex = 2;
            // 
            // driveCtrlView1
            // 
            this.driveCtrlView1.DriveCtrl = null;
            this.driveCtrlView1.Location = new System.Drawing.Point(18, 3);
            this.driveCtrlView1.Name = "driveCtrlView1";
            this.driveCtrlView1.Size = new System.Drawing.Size(480, 75);
            this.driveCtrlView1.TabIndex = 0;
            // 
            // FormWorldControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(746, 742);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.driveView1);
            this.Controls.Add(this.driveCtrlView1);
            this.Name = "FormWorldControl";
            this.Text = "FormWorldControl";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RobotView.DriveCtrlView driveCtrlView1;
        private RobotView.RunLineView runLineView1;
        private RobotView.DriveView driveView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private RobotView.TrackArc trackArc1;
        private System.Windows.Forms.TabPage tabPage3;
        private RobotView.TrackTurnView trackTurnView1;

    }
}