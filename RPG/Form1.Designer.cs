
namespace RPG
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
       
           
        
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Start = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Options = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.jumptimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Fuel = new System.Windows.Forms.Timer(this.components);
            this.Heart = new System.Windows.Forms.Timer(this.components);
            this.Fallingdamage = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.Green;
            this.Start.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Start.ForeColor = System.Drawing.Color.Black;
            this.Start.Location = new System.Drawing.Point(925, 400);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(110, 50);
            this.Start.TabIndex = 1;
            this.Start.Text = "START";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Red;
            this.Exit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Exit.Location = new System.Drawing.Point(925, 520);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(110, 50);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "EXIT";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Options
            // 
            this.Options.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Options.Location = new System.Drawing.Point(925, 460);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(110, 50);
            this.Options.TabIndex = 3;
            this.Options.Text = "OPTIONS";
            this.Options.UseVisualStyleBackColor = false;
            this.Options.Click += new System.EventHandler(this.Options_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 25;
            this.timer2.Tick += new System.EventHandler(this.Boomerang_Tick);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 70;
            this.timer3.Tick += new System.EventHandler(this.Moonwalk_Tick);
            // 
            // jumptimer
            // 
            this.jumptimer.Enabled = true;
            this.jumptimer.Interval = 10;
            this.jumptimer.Tick += new System.EventHandler(this.AirTime_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(472, 141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1100, 220);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Fuel
            // 
            this.Fuel.Enabled = true;
            this.Fuel.Interval = 10;
            this.Fuel.Tick += new System.EventHandler(this.Fuel_Tick);
            // 
            // Heart
            // 
            this.Heart.Enabled = true;
            this.Heart.Interval = 70;
            this.Heart.Tick += new System.EventHandler(this.Heart_Tick);
            // 
            // Fallingdamage
            // 
            this.Fallingdamage.Enabled = true;
            this.Fallingdamage.Interval = 10;
            this.Fallingdamage.Tick += new System.EventHandler(this.Fallingdamage_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 850);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Options);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Options;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer jumptimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer Fuel;
        private System.Windows.Forms.Timer Heart;
        private System.Windows.Forms.Timer Fallingdamage;
    }
}

