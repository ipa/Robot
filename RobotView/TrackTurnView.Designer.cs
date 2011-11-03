namespace RobotView
{
    partial class TrackTurnView
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
            this.label2 = new System.Windows.Forms.Label();
            this.nudDegrees = new System.Windows.Forms.NumericUpDown();
            this.btnHue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // commonRunParameters1
            // 
            this.commonRunParameters1.Location = new System.Drawing.Point(3, 23);
            this.commonRunParameters1.Name = "commonRunParameters1";
            this.commonRunParameters1.Size = new System.Drawing.Size(319, 62);
            this.commonRunParameters1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.Text = "TrackTurnView";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Degrees [°]";
            // 
            // nudDegrees
            // 
            this.nudDegrees.Location = new System.Drawing.Point(168, 95);
            this.nudDegrees.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudDegrees.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudDegrees.Name = "nudDegrees";
            this.nudDegrees.Size = new System.Drawing.Size(100, 24);
            this.nudDegrees.TabIndex = 3;
            // 
            // btnHue
            // 
            this.btnHue.Location = new System.Drawing.Point(294, 99);
            this.btnHue.Name = "btnHue";
            this.btnHue.Size = new System.Drawing.Size(72, 20);
            this.btnHue.TabIndex = 4;
            this.btnHue.Text = "Hü!";
            this.btnHue.Click += new System.EventHandler(this.btnHue_Click);
            // 
            // TrackTurnView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnHue);
            this.Controls.Add(this.nudDegrees);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commonRunParameters1);
            this.Name = "TrackTurnView";
            this.Size = new System.Drawing.Size(384, 157);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonRunParameters commonRunParameters1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDegrees;
        private System.Windows.Forms.Button btnHue;
    }
}
