namespace RobotView
{
    partial class CommonRunParameters
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
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblAcceleration = new System.Windows.Forms.Label();
            this.upDownAcceleration = new System.Windows.Forms.NumericUpDown();
            this.upDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.SuspendLayout();
            // 
            // lblSpeed
            // 
            this.lblSpeed.Location = new System.Drawing.Point(3, 7);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(156, 20);
            this.lblSpeed.Text = "Speed (+ mm/s)";
            // 
            // lblAcceleration
            // 
            this.lblAcceleration.Location = new System.Drawing.Point(0, 35);
            this.lblAcceleration.Name = "lblAcceleration";
            this.lblAcceleration.Size = new System.Drawing.Size(169, 20);
            this.lblAcceleration.Text = "Acceleration (+ mm/s^2)";
            // 
            // upDownAcceleration
            // 
            this.upDownAcceleration.Location = new System.Drawing.Point(165, 31);
            this.upDownAcceleration.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.upDownAcceleration.Name = "upDownAcceleration";
            this.upDownAcceleration.Size = new System.Drawing.Size(148, 24);
            this.upDownAcceleration.TabIndex = 2;
            this.upDownAcceleration.ValueChanged += new System.EventHandler(this.upDownAcceleration_ValueChanged);
            // 
            // upDownSpeed
            // 
            this.upDownSpeed.Location = new System.Drawing.Point(165, 3);
            this.upDownSpeed.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.upDownSpeed.Name = "upDownSpeed";
            this.upDownSpeed.Size = new System.Drawing.Size(148, 24);
            this.upDownSpeed.TabIndex = 3;
            this.upDownSpeed.ValueChanged += new System.EventHandler(this.upDownSpeed_ValueChanged);
            // 
            // CommonRunParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.upDownSpeed);
            this.Controls.Add(this.upDownAcceleration);
            this.Controls.Add(this.lblAcceleration);
            this.Controls.Add(this.lblSpeed);
            this.Name = "CommonRunParameters";
            this.Size = new System.Drawing.Size(319, 62);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblAcceleration;
        private System.Windows.Forms.NumericUpDown upDownAcceleration;
        private System.Windows.Forms.NumericUpDown upDownSpeed;
    }
}
