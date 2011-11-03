namespace RobotView
{
    partial class RunLineView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChangeReverse = new System.Windows.Forms.Button();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.commonRunParameters1 = new RobotView.CommonRunParameters();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "RunLineView";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 20);
            this.label2.Text = "Length (mm)";
            // 
            // btnChangeReverse
            // 
            this.btnChangeReverse.Location = new System.Drawing.Point(133, 101);
            this.btnChangeReverse.Name = "btnChangeReverse";
            this.btnChangeReverse.Size = new System.Drawing.Size(72, 20);
            this.btnChangeReverse.TabIndex = 2;
            this.btnChangeReverse.Text = "+/-";
            this.btnChangeReverse.Click += new System.EventHandler(this.btnChangeReverse_Click);
            // 
            // nudLength
            // 
            this.nudLength.Location = new System.Drawing.Point(229, 97);
            this.nudLength.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(100, 24);
            this.nudLength.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(381, 101);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 20);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Hü!";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // commonRunParameters1
            // 
            this.commonRunParameters1.Location = new System.Drawing.Point(0, 23);
            this.commonRunParameters1.Name = "commonRunParameters1";
            this.commonRunParameters1.Size = new System.Drawing.Size(319, 62);
            this.commonRunParameters1.TabIndex = 5;
            // 
            // RunLineView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.commonRunParameters1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.nudLength);
            this.Controls.Add(this.btnChangeReverse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RunLineView";
            this.Size = new System.Drawing.Size(488, 140);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangeReverse;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.Button btnStart;
        private CommonRunParameters commonRunParameters1;
    }
}
