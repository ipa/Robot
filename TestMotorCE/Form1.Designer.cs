namespace TestMotorCE
{
    partial class Form1
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
            this.rightMotor = new RobotView.MotorCtrlView();
            this.leftMotor = new RobotView.MotorCtrlView();
            this.driveCtrlView1 = new RobotView.DriveCtrlView();
            this.SuspendLayout();
            // 
            // rightMotor
            // 
            this.rightMotor.Location = new System.Drawing.Point(506, 84);
            this.rightMotor.MotorCtrl = null;
            this.rightMotor.Name = "rightMotor";
            this.rightMotor.Size = new System.Drawing.Size(480, 330);
            this.rightMotor.TabIndex = 2;
            // 
            // leftMotor
            // 
            this.leftMotor.Location = new System.Drawing.Point(3, 84);
            this.leftMotor.MotorCtrl = null;
            this.leftMotor.Name = "leftMotor";
            this.leftMotor.Size = new System.Drawing.Size(480, 330);
            this.leftMotor.TabIndex = 1;
            // 
            // driveCtrlView1
            // 
            this.driveCtrlView1.DriveCtrl = null;
            this.driveCtrlView1.Location = new System.Drawing.Point(3, 3);
            this.driveCtrlView1.Name = "driveCtrlView1";
            this.driveCtrlView1.Size = new System.Drawing.Size(480, 75);
            this.driveCtrlView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Controls.Add(this.rightMotor);
            this.Controls.Add(this.leftMotor);
            this.Controls.Add(this.driveCtrlView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private RobotView.DriveCtrlView driveCtrlView1;
        private RobotView.MotorCtrlView leftMotor;
        private RobotView.MotorCtrlView rightMotor;
    }
}

