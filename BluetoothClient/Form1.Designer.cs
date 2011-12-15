namespace BluetoothClient
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
            this.lstCommands = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteCommand = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpgTrackLine = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTrackLineLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tpgTrackTurn = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTrackTurnAngle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tpgTrackArc = new System.Windows.Forms.TabPage();
            this.rbnTrackArcRight = new System.Windows.Forms.RadioButton();
            this.rbnTrackArcLeft = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTrackArcRadius = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTrackArcAngle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbxRobot = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.tpgTrackLine.SuspendLayout();
            this.tpgTrackTurn.SuspendLayout();
            this.tpgTrackArc.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCommands
            // 
            this.lstCommands.FormattingEnabled = true;
            this.lstCommands.Location = new System.Drawing.Point(750, 33);
            this.lstCommands.Name = "lstCommands";
            this.lstCommands.Size = new System.Drawing.Size(339, 342);
            this.lstCommands.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(747, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fahrbefehle";
            // 
            // btnDeleteCommand
            // 
            this.btnDeleteCommand.Location = new System.Drawing.Point(750, 381);
            this.btnDeleteCommand.Name = "btnDeleteCommand";
            this.btnDeleteCommand.Size = new System.Drawing.Size(142, 23);
            this.btnDeleteCommand.TabIndex = 2;
            this.btnDeleteCommand.Text = "Delete Command";
            this.btnDeleteCommand.UseVisualStyleBackColor = true;
            this.btnDeleteCommand.Click += new System.EventHandler(this.btnDeleteCommand_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(947, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Send Commands";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpgTrackLine);
            this.tabControl.Controls.Add(this.tpgTrackTurn);
            this.tabControl.Controls.Add(this.tpgTrackArc);
            this.tabControl.Location = new System.Drawing.Point(1, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(709, 363);
            this.tabControl.TabIndex = 4;
            // 
            // tpgTrackLine
            // 
            this.tpgTrackLine.Controls.Add(this.label6);
            this.tpgTrackLine.Controls.Add(this.txtTrackLineLength);
            this.tpgTrackLine.Controls.Add(this.label2);
            this.tpgTrackLine.Location = new System.Drawing.Point(4, 22);
            this.tpgTrackLine.Name = "tpgTrackLine";
            this.tpgTrackLine.Padding = new System.Windows.Forms.Padding(3);
            this.tpgTrackLine.Size = new System.Drawing.Size(701, 337);
            this.tpgTrackLine.TabIndex = 0;
            this.tpgTrackLine.Text = "TrackLine";
            this.tpgTrackLine.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "m";
            // 
            // txtTrackLineLength
            // 
            this.txtTrackLineLength.Location = new System.Drawing.Point(69, 23);
            this.txtTrackLineLength.Name = "txtTrackLineLength";
            this.txtTrackLineLength.Size = new System.Drawing.Size(127, 20);
            this.txtTrackLineLength.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Length";
            // 
            // tpgTrackTurn
            // 
            this.tpgTrackTurn.Controls.Add(this.label8);
            this.tpgTrackTurn.Controls.Add(this.txtTrackTurnAngle);
            this.tpgTrackTurn.Controls.Add(this.label3);
            this.tpgTrackTurn.Location = new System.Drawing.Point(4, 22);
            this.tpgTrackTurn.Name = "tpgTrackTurn";
            this.tpgTrackTurn.Padding = new System.Windows.Forms.Padding(3);
            this.tpgTrackTurn.Size = new System.Drawing.Size(701, 337);
            this.tpgTrackTurn.TabIndex = 1;
            this.tpgTrackTurn.Text = "TrackTurn";
            this.tpgTrackTurn.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "°";
            // 
            // txtTrackTurnAngle
            // 
            this.txtTrackTurnAngle.Location = new System.Drawing.Point(75, 17);
            this.txtTrackTurnAngle.Name = "txtTrackTurnAngle";
            this.txtTrackTurnAngle.Size = new System.Drawing.Size(127, 20);
            this.txtTrackTurnAngle.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Angle";
            // 
            // tpgTrackArc
            // 
            this.tpgTrackArc.Controls.Add(this.rbnTrackArcRight);
            this.tpgTrackArc.Controls.Add(this.rbnTrackArcLeft);
            this.tpgTrackArc.Controls.Add(this.label10);
            this.tpgTrackArc.Controls.Add(this.label9);
            this.tpgTrackArc.Controls.Add(this.label7);
            this.tpgTrackArc.Controls.Add(this.txtTrackArcRadius);
            this.tpgTrackArc.Controls.Add(this.label5);
            this.tpgTrackArc.Controls.Add(this.txtTrackArcAngle);
            this.tpgTrackArc.Controls.Add(this.label4);
            this.tpgTrackArc.Location = new System.Drawing.Point(4, 22);
            this.tpgTrackArc.Name = "tpgTrackArc";
            this.tpgTrackArc.Padding = new System.Windows.Forms.Padding(3);
            this.tpgTrackArc.Size = new System.Drawing.Size(701, 337);
            this.tpgTrackArc.TabIndex = 2;
            this.tpgTrackArc.Text = "TrackArc";
            this.tpgTrackArc.UseVisualStyleBackColor = true;
            this.tpgTrackArc.Click += new System.EventHandler(this.tbgTrackArc_Click);
            // 
            // rbnTrackArcRight
            // 
            this.rbnTrackArcRight.AutoSize = true;
            this.rbnTrackArcRight.Location = new System.Drawing.Point(72, 133);
            this.rbnTrackArcRight.Name = "rbnTrackArcRight";
            this.rbnTrackArcRight.Size = new System.Drawing.Size(50, 17);
            this.rbnTrackArcRight.TabIndex = 12;
            this.rbnTrackArcRight.TabStop = true;
            this.rbnTrackArcRight.Text = "Right";
            this.rbnTrackArcRight.UseVisualStyleBackColor = true;
            // 
            // rbnTrackArcLeft
            // 
            this.rbnTrackArcLeft.AutoSize = true;
            this.rbnTrackArcLeft.Location = new System.Drawing.Point(72, 110);
            this.rbnTrackArcLeft.Name = "rbnTrackArcLeft";
            this.rbnTrackArcLeft.Size = new System.Drawing.Size(43, 17);
            this.rbnTrackArcLeft.TabIndex = 11;
            this.rbnTrackArcLeft.TabStop = true;
            this.rbnTrackArcLeft.Text = "Left";
            this.rbnTrackArcLeft.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Direction";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "°";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "m";
            // 
            // txtTrackArcRadius
            // 
            this.txtTrackArcRadius.Location = new System.Drawing.Point(72, 64);
            this.txtTrackArcRadius.Name = "txtTrackArcRadius";
            this.txtTrackArcRadius.Size = new System.Drawing.Size(127, 20);
            this.txtTrackArcRadius.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Radius";
            // 
            // txtTrackArcAngle
            // 
            this.txtTrackArcAngle.Location = new System.Drawing.Point(72, 22);
            this.txtTrackArcAngle.Name = "txtTrackArcAngle";
            this.txtTrackArcAngle.Size = new System.Drawing.Size(127, 20);
            this.txtTrackArcAngle.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Angle";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(581, 381);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(125, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add Command";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbxRobot
            // 
            this.cbxRobot.FormattingEnabled = true;
            this.cbxRobot.Location = new System.Drawing.Point(574, 446);
            this.cbxRobot.Name = "cbxRobot";
            this.cbxRobot.Size = new System.Drawing.Size(367, 21);
            this.cbxRobot.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 622);
            this.Controls.Add(this.cbxRobot);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDeleteCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstCommands);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tpgTrackLine.ResumeLayout(false);
            this.tpgTrackLine.PerformLayout();
            this.tpgTrackTurn.ResumeLayout(false);
            this.tpgTrackTurn.PerformLayout();
            this.tpgTrackArc.ResumeLayout(false);
            this.tpgTrackArc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCommands;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteCommand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpgTrackLine;
        private System.Windows.Forms.TabPage tpgTrackTurn;
        private System.Windows.Forms.TabPage tpgTrackArc;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtTrackLineLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTrackTurnAngle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTrackArcRadius;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTrackArcAngle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbnTrackArcRight;
        private System.Windows.Forms.RadioButton rbnTrackArcLeft;
        private System.Windows.Forms.ComboBox cbxRobot;
    }
}

