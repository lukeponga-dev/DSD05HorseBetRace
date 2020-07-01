namespace HorseBetRace
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRace = new System.Windows.Forms.Button();
            this.btnBet = new System.Windows.Forms.Button();
            this.nudHorseNumber = new System.Windows.Forms.NumericUpDown();
            this.nudCash = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBettor = new System.Windows.Forms.Label();
            this.lblMaxBet = new System.Windows.Forms.Label();
            this.lblMinimumBet = new System.Windows.Forms.Label();
            this.rbAl = new System.Windows.Forms.RadioButton();
            this.rbBob = new System.Windows.Forms.RadioButton();
            this.rbJoe = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAl = new System.Windows.Forms.Label();
            this.lblBob = new System.Windows.Forms.Label();
            this.lblJoe = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbHorse4 = new System.Windows.Forms.PictureBox();
            this.pbHorse3 = new System.Windows.Forms.PictureBox();
            this.pbHorse2 = new System.Windows.Forms.PictureBox();
            this.pbHorse1 = new System.Windows.Forms.PictureBox();
            this.pbRaceTrack = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorseNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCash)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHorse4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHorse3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHorse2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHorse1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRaceTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Pink;
            this.panel1.Controls.Add(this.btnRace);
            this.panel1.Controls.Add(this.btnBet);
            this.panel1.Controls.Add(this.nudHorseNumber);
            this.panel1.Controls.Add(this.nudCash);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblBettor);
            this.panel1.Controls.Add(this.lblMaxBet);
            this.panel1.Controls.Add(this.lblMinimumBet);
            this.panel1.Controls.Add(this.rbAl);
            this.panel1.Controls.Add(this.rbBob);
            this.panel1.Controls.Add(this.rbJoe);
            this.panel1.Location = new System.Drawing.Point(-5, 293);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 157);
            this.panel1.TabIndex = 0;
            // 
            // btnRace
            // 
            this.btnRace.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRace.Location = new System.Drawing.Point(301, 109);
            this.btnRace.Name = "btnRace";
            this.btnRace.Size = new System.Drawing.Size(112, 38);
            this.btnRace.TabIndex = 21;
            this.btnRace.Text = "Race";
            this.btnRace.UseVisualStyleBackColor = false;
            this.btnRace.Click += new System.EventHandler(this.btnRace_Click);
            // 
            // btnBet
            // 
            this.btnBet.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBet.Location = new System.Drawing.Point(301, 65);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(112, 38);
            this.btnBet.TabIndex = 20;
            this.btnBet.Text = "Place Bet";
            this.btnBet.UseVisualStyleBackColor = false;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // nudHorseNumber
            // 
            this.nudHorseNumber.Location = new System.Drawing.Point(380, 37);
            this.nudHorseNumber.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudHorseNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHorseNumber.Name = "nudHorseNumber";
            this.nudHorseNumber.Size = new System.Drawing.Size(37, 20);
            this.nudHorseNumber.TabIndex = 19;
            this.nudHorseNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudCash
            // 
            this.nudCash.Location = new System.Drawing.Point(380, 14);
            this.nudCash.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.nudCash.Name = "nudCash";
            this.nudCash.Size = new System.Drawing.Size(37, 20);
            this.nudCash.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Horse number #";
            // 
            // lblBettor
            // 
            this.lblBettor.AutoSize = true;
            this.lblBettor.Location = new System.Drawing.Point(337, 16);
            this.lblBettor.Name = "lblBettor";
            this.lblBettor.Size = new System.Drawing.Size(44, 13);
            this.lblBettor.TabIndex = 16;
            this.lblBettor.Text = "Bettor $";
            // 
            // lblMaxBet
            // 
            this.lblMaxBet.AutoSize = true;
            this.lblMaxBet.BackColor = System.Drawing.Color.Pink;
            this.lblMaxBet.Location = new System.Drawing.Point(107, 14);
            this.lblMaxBet.Name = "lblMaxBet";
            this.lblMaxBet.Size = new System.Drawing.Size(46, 13);
            this.lblMaxBet.TabIndex = 15;
            this.lblMaxBet.Text = "Max Bet";
            this.lblMaxBet.Visible = false;
            // 
            // lblMinimumBet
            // 
            this.lblMinimumBet.AutoSize = true;
            this.lblMinimumBet.Location = new System.Drawing.Point(8, 14);
            this.lblMinimumBet.Name = "lblMinimumBet";
            this.lblMinimumBet.Size = new System.Drawing.Size(35, 13);
            this.lblMinimumBet.TabIndex = 9;
            this.lblMinimumBet.Text = "Bettor";
            // 
            // rbAl
            // 
            this.rbAl.AutoSize = true;
            this.rbAl.BackColor = System.Drawing.Color.Pink;
            this.rbAl.Location = new System.Drawing.Point(11, 85);
            this.rbAl.Margin = new System.Windows.Forms.Padding(2);
            this.rbAl.Name = "rbAl";
            this.rbAl.Size = new System.Drawing.Size(34, 17);
            this.rbAl.TabIndex = 8;
            this.rbAl.TabStop = true;
            this.rbAl.Text = "Al";
            this.rbAl.UseVisualStyleBackColor = false;
            this.rbAl.CheckedChanged += new System.EventHandler(this.rbAl_CheckedChanged);
            // 
            // rbBob
            // 
            this.rbBob.AutoSize = true;
            this.rbBob.BackColor = System.Drawing.Color.Pink;
            this.rbBob.Location = new System.Drawing.Point(11, 62);
            this.rbBob.Margin = new System.Windows.Forms.Padding(2);
            this.rbBob.Name = "rbBob";
            this.rbBob.Size = new System.Drawing.Size(44, 17);
            this.rbBob.TabIndex = 7;
            this.rbBob.TabStop = true;
            this.rbBob.Text = "Bob";
            this.rbBob.UseVisualStyleBackColor = false;
            this.rbBob.CheckedChanged += new System.EventHandler(this.rbBob_CheckedChanged);
            // 
            // rbJoe
            // 
            this.rbJoe.AutoSize = true;
            this.rbJoe.BackColor = System.Drawing.Color.Pink;
            this.rbJoe.Location = new System.Drawing.Point(11, 40);
            this.rbJoe.Margin = new System.Windows.Forms.Padding(2);
            this.rbJoe.Name = "rbJoe";
            this.rbJoe.Size = new System.Drawing.Size(42, 17);
            this.rbJoe.TabIndex = 6;
            this.rbJoe.TabStop = true;
            this.rbJoe.Text = "Joe";
            this.rbJoe.UseVisualStyleBackColor = false;
            this.rbJoe.CheckedChanged += new System.EventHandler(this.rbJoe_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightPink;
            this.panel2.Controls.Add(this.lblAl);
            this.panel2.Controls.Add(this.lblBob);
            this.panel2.Controls.Add(this.lblJoe);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(426, 293);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 105);
            this.panel2.TabIndex = 6;
            // 
            // lblAl
            // 
            this.lblAl.AutoSize = true;
            this.lblAl.Location = new System.Drawing.Point(8, 83);
            this.lblAl.Name = "lblAl";
            this.lblAl.Size = new System.Drawing.Size(109, 13);
            this.lblAl.TabIndex = 24;
            this.lblAl.Text = "Al hasn\'t placed a bet";
            // 
            // lblBob
            // 
            this.lblBob.AutoSize = true;
            this.lblBob.Location = new System.Drawing.Point(8, 60);
            this.lblBob.Name = "lblBob";
            this.lblBob.Size = new System.Drawing.Size(119, 13);
            this.lblBob.TabIndex = 23;
            this.lblBob.Text = "Bob hasn\'t placed a bet";
            // 
            // lblJoe
            // 
            this.lblJoe.AutoSize = true;
            this.lblJoe.Location = new System.Drawing.Point(8, 37);
            this.lblJoe.Name = "lblJoe";
            this.lblJoe.Size = new System.Drawing.Size(117, 13);
            this.lblJoe.TabIndex = 22;
            this.lblJoe.Text = "Joe hasn\'t placed a bet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Bet";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbHorse4
            // 
            this.pbHorse4.BackColor = System.Drawing.Color.Transparent;
            this.pbHorse4.BackgroundImage = global::HorseBetRace.MainResource.Horse4;
            this.pbHorse4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHorse4.Location = new System.Drawing.Point(12, 208);
            this.pbHorse4.Name = "pbHorse4";
            this.pbHorse4.Size = new System.Drawing.Size(79, 38);
            this.pbHorse4.TabIndex = 5;
            this.pbHorse4.TabStop = false;
            // 
            // pbHorse3
            // 
            this.pbHorse3.BackgroundImage = global::HorseBetRace.MainResource.Horse3;
            this.pbHorse3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHorse3.Location = new System.Drawing.Point(12, 144);
            this.pbHorse3.Name = "pbHorse3";
            this.pbHorse3.Size = new System.Drawing.Size(79, 41);
            this.pbHorse3.TabIndex = 4;
            this.pbHorse3.TabStop = false;
            // 
            // pbHorse2
            // 
            this.pbHorse2.BackgroundImage = global::HorseBetRace.MainResource.Horse2;
            this.pbHorse2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHorse2.Location = new System.Drawing.Point(12, 78);
            this.pbHorse2.Name = "pbHorse2";
            this.pbHorse2.Size = new System.Drawing.Size(79, 41);
            this.pbHorse2.TabIndex = 3;
            this.pbHorse2.TabStop = false;
            // 
            // pbHorse1
            // 
            this.pbHorse1.BackgroundImage = global::HorseBetRace.MainResource.Horse1;
            this.pbHorse1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHorse1.Location = new System.Drawing.Point(12, 12);
            this.pbHorse1.Name = "pbHorse1";
            this.pbHorse1.Size = new System.Drawing.Size(79, 41);
            this.pbHorse1.TabIndex = 2;
            this.pbHorse1.TabStop = false;
            // 
            // pbRaceTrack
            // 
            this.pbRaceTrack.BackgroundImage = global::HorseBetRace.MainResource.racetrack;
            this.pbRaceTrack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRaceTrack.Location = new System.Drawing.Point(-5, -1);
            this.pbRaceTrack.Name = "pbRaceTrack";
            this.pbRaceTrack.Size = new System.Drawing.Size(602, 288);
            this.pbRaceTrack.TabIndex = 1;
            this.pbRaceTrack.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 454);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pbHorse4);
            this.Controls.Add(this.pbHorse3);
            this.Controls.Add(this.pbHorse2);
            this.Controls.Add(this.pbHorse1);
            this.Controls.Add(this.pbRaceTrack);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorseNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCash)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHorse4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHorse3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHorse2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHorse1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRaceTrack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbAl;
        private System.Windows.Forms.RadioButton rbBob;
        private System.Windows.Forms.RadioButton rbJoe;
        private System.Windows.Forms.Label lblMaxBet;
        private System.Windows.Forms.Label lblMinimumBet;
        private System.Windows.Forms.PictureBox pbRaceTrack;
        private System.Windows.Forms.PictureBox pbHorse1;
        private System.Windows.Forms.PictureBox pbHorse2;
        private System.Windows.Forms.PictureBox pbHorse3;
        private System.Windows.Forms.PictureBox pbHorse4;
        private System.Windows.Forms.Label lblBettor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudHorseNumber;
        private System.Windows.Forms.NumericUpDown nudCash;
        private System.Windows.Forms.Button btnBet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblJoe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAl;
        private System.Windows.Forms.Label lblBob;
        private System.Windows.Forms.Button btnRace;
        private System.Windows.Forms.Timer timer1;
    }
}

