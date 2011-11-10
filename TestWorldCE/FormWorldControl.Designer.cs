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
            this.runLineView1 = new RobotView.RunLineView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.trackArc1 = new RobotView.TrackArc();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.trackTurnView1 = new RobotView.TrackTurnView();
            this.driveView1 = new RobotView.DriveView();
            this.consoleView1 = new RobotView.ConsoleView();
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
            this.tabControl1.Location = new System.Drawing.Point(12, 117);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(503, 261);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.runLineView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(495, 232);
            this.tabPage1.Text = "Run Line";
            // 
            // runLineView1
            // 
            this.runLineView1.drive = null;
            this.runLineView1.Location = new System.Drawing.Point(12, 3);
            this.runLineView1.Name = "runLineView1";
            this.runLineView1.Size = new System.Drawing.Size(488, 140);
            this.runLineView1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.trackArc1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(495, 232);
            this.tabPage2.Text = "Run Arc";
            // 
            // trackArc1
            // 
            this.trackArc1.drive = null;
            this.trackArc1.Location = new System.Drawing.Point(12, 12);
            this.trackArc1.Name = "trackArc1";
            this.trackArc1.Size = new System.Drawing.Size(369, 204);
            this.trackArc1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.trackTurnView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(495, 232);
            this.tabPage3.Text = "Track Turn";
            // 
            // trackTurnView1
            // 
            this.trackTurnView1.drive = null;
            this.trackTurnView1.Location = new System.Drawing.Point(12, 3);
            this.trackTurnView1.Name = "trackTurnView1";
            this.trackTurnView1.Size = new System.Drawing.Size(384, 157);
            this.trackTurnView1.TabIndex = 0;
            // 
            // driveView1
            // 
            this.driveView1.Drive = null;
            this.driveView1.Location = new System.Drawing.Point(12, 430);
            this.driveView1.Name = "driveView1";
            this.driveView1.Size = new System.Drawing.Size(290, 300);
            this.driveView1.TabIndex = 2;
            // 
            // consoleView1
            // 
            this.consoleView1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.consoleView1.Location = new System.Drawing.Point(12, 35);
            this.consoleView1.Name = "consoleView1";
            this.consoleView1.RobotConsole = null;
            this.consoleView1.Size = new System.Drawing.Size(210, 45);
            this.consoleView1.TabIndex = 5;
            // 
            // FormWorldControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(557, 742);
            this.Controls.Add(this.consoleView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.driveView1);
            this.Name = "FormWorldControl";
            this.Text = " ";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RobotView.RunLineView runLineView1;
        private RobotView.DriveView driveView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private RobotView.TrackArc trackArc1;
        private System.Windows.Forms.TabPage tabPage3;
        private RobotView.TrackTurnView trackTurnView1;
        private RobotView.ConsoleView consoleView1;

    }
}