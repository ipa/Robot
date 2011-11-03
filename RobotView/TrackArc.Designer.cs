namespace RobotView
{
    partial class TrackArc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.commonRunParameters1 = new RobotView.CommonRunParameters();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtLeft = new System.Windows.Forms.RadioButton();
            this.rbtRight = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.nudRadius = new System.Windows.Forms.NumericUpDown();
            this.nudAngle = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // commonRunParameters1
            // 
            this.commonRunParameters1.Location = new System.Drawing.Point(3, 37);
            this.commonRunParameters1.Name = "commonRunParameters1";
            this.commonRunParameters1.Size = new System.Drawing.Size(319, 62);
            this.commonRunParameters1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "RunArc";
            // 
            // rbtLeft
            // 
            this.rbtLeft.Location = new System.Drawing.Point(173, 3);
            this.rbtLeft.Name = "rbtLeft";
            this.rbtLeft.Size = new System.Drawing.Size(100, 20);
            this.rbtLeft.TabIndex = 2;
            this.rbtLeft.Text = "left";
            // 
            // rbtRight
            // 
            this.rbtRight.Location = new System.Drawing.Point(279, 3);
            this.rbtRight.Name = "rbtRight";
            this.rbtRight.Size = new System.Drawing.Size(100, 20);
            this.rbtRight.TabIndex = 3;
            this.rbtRight.Text = "right";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Radius";
            // 
            // nudRadius
            // 
            this.nudRadius.Location = new System.Drawing.Point(163, 109);
            this.nudRadius.Name = "nudRadius";
            this.nudRadius.Size = new System.Drawing.Size(100, 24);
            this.nudRadius.TabIndex = 5;
            // 
            // nudAngle
            // 
            this.nudAngle.Location = new System.Drawing.Point(163, 139);
            this.nudAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudAngle.Name = "nudAngle";
            this.nudAngle.Size = new System.Drawing.Size(100, 24);
            this.nudAngle.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Angle [°]";
            // 
            // btnHue
            // 
            this.btnHue.Location = new System.Drawing.Point(279, 181);
            this.btnHue.Name = "btnHue";
            this.btnHue.Size = new System.Drawing.Size(72, 20);
            this.btnHue.TabIndex = 9;
            this.btnHue.Text = "Hü!";
            this.btnHue.Click += new System.EventHandler(this.btnHue_Click);
            // 
            // TrackArc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnHue);
            this.Controls.Add(this.nudAngle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudRadius);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbtRight);
            this.Controls.Add(this.rbtLeft);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commonRunParameters1);
            this.Name = "TrackArc";
            this.Size = new System.Drawing.Size(369, 204);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonRunParameters commonRunParameters1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtLeft;
        private System.Windows.Forms.RadioButton rbtRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudRadius;
        private System.Windows.Forms.NumericUpDown nudAngle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHue;
    }
}
