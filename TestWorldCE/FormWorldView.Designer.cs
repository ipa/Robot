namespace TestWorldCE
{
    partial class FormWorldView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;
        private RobotView.WorldView worldView1;
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
             
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            
            this.worldView1 = new RobotView.WorldView();
            this.SuspendLayout();
            // 
            // worldView1
            // 
            this.worldView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldView1.Location = new System.Drawing.Point(0, 0);
            this.worldView1.Name = "worldView1";
            this.worldView1.Size = new System.Drawing.Size(695, 541);
            this.worldView1.TabIndex = 0;
            // 
            // FormWorldView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(695, 541);
            this.Controls.Add(this.worldView1);
            this.Menu = this.mainMenu1;
            this.Name = "FormWorldView";
            this.Text = "FormWorldView";
            this.ResumeLayout(false);

        }

        #endregion

       
    }
}