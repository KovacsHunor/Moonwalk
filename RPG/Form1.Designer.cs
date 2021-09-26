using System;
using System.Windows.Forms;
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
            this.Start = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Label();
            this.Options = new System.Windows.Forms.Label();
            this.Main = new System.Windows.Forms.Timer(this.components);
            this.Boomerang = new System.Windows.Forms.Timer(this.components);
            this.Moonwalk = new System.Windows.Forms.Timer(this.components);
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
            this.Start.BackColor = System.Drawing.Color.White;
            this.Start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Start.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Start.Location = new System.Drawing.Point(0, 0);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(150, 50);
            this.Start.Text = "START";
            this.Start.Click += new System.EventHandler(this.Start_Click);
            this.Start.MouseEnter += new System.EventHandler(this.Start_MouseEnter);
            this.Start.MouseLeave += new EventHandler(Start_MouseLeave);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.White;
            this.Exit.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Exit.Location = new System.Drawing.Point(0, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(150, 50);
            this.Exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Exit.Text = "EXIT";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.MouseEnter += new System.EventHandler(this.Exit_MouseEnter);
            this.Exit.MouseLeave += new EventHandler(Exit_MouseLeave);
            // 
            // Options
            // 
            this.Options.BackColor = System.Drawing.Color.White;
            this.Options.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Options.Location = new System.Drawing.Point(0, 0);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(150, 50);
            this.Options.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Options.Text = "OPTIONS";
            this.Options.Click += new System.EventHandler(this.Options_Click);
            this.Options.MouseEnter += new System.EventHandler(this.Options_MouseEnter);
            this.Options.MouseLeave += new EventHandler(Options_MouseLeave);
            // 
            // Main
            // 
            this.Main.Enabled = true;
            this.Main.Interval = 10;
            this.Main.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Boomerang
            // 
            this.Boomerang.Enabled = true;
            this.Boomerang.Interval = 25;
            this.Boomerang.Tick += new System.EventHandler(this.Boomerang_Tick);
            // 
            // Moonwalk
            // 
            this.Moonwalk.Enabled = true;
            this.Moonwalk.Interval = 70;
            this.Moonwalk.Tick += new System.EventHandler(this.Moonwalk_Tick);
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
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1257, 293);
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
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1800, 851);
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
        private System.Windows.Forms.Label Start;
        private System.Windows.Forms.Label Exit;
        private System.Windows.Forms.Label Options;
        private System.Windows.Forms.Timer Main;
        private System.Windows.Forms.Timer Moonwalk;
        private System.Windows.Forms.Timer jumptimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer Fuel;
        private System.Windows.Forms.Timer Heart;
        private System.Windows.Forms.Timer Fallingdamage;
        private Timer Boomerang;
    }
}

