using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;

namespace RPG
{
    public partial class Form1 : Form
    {
        
        static int speed = 10;
        static int scale = 60;
        static PictureBox player = new PictureBox();
        public Form1()
        {
            for (int i = 0; i < 6; i++)
            {
                opmod[i] = new Label();
                opmod[i].Size = new Size(150, 50);
                opmod[i].Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - opmod[i].Width / 2, 400 + 50 * i);
                opmod[i].MouseEnter += new EventHandler(opmod_MouseEnter);
                opmod[i].MouseLeave += new EventHandler(opmod_MouseLeave);
                opmod[i].Font = new Font("Consolas", 16F, FontStyle.Bold, GraphicsUnit.Point);
                opmod[i].TextAlign = ContentAlignment.MiddleCenter;
            }
            opmod[0].Text = "A";
            opmod[1].Text = "D";
            opmod[2].Text = "Space";
            opmod[3].Text = "W";
            opmod[4].Text = "Left";
            opmod[5].Text = "Right";
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();

            pictureBox1.Size = new Size(1095, 251);
            pictureBox1.Image = Image.FromFile("moonwalk.png");
            pictureBox1.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2 - pictureBox1.Width / 2), 100);
            Options.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Options.Width / 2, 500);
            Exit.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Exit.Width / 2, 550);
            Start.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Start.Width / 2, 450);
            beatit.SoundLocation = "beat.wav";
        }

        

        System.Media.SoundPlayer beatit = new System.Media.SoundPlayer();

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        static bool begin = false;
        PictureBox picture = new PictureBox();
        static bool clickenabled = false;
        PictureBox heart1 = new PictureBox();
        PictureBox heart2 = new PictureBox();
        PictureBox heart3 = new PictureBox();
        PictureBox heart4 = new PictureBox();
        Point Spawnpoint;

        private void Start_Click(object sender, EventArgs e)
        {

            health = 4;
            healthlist.Add(false);
            label.Visible = true;
            clickenabled = true;
            Controls.Clear();
            Controls.Add(heart1);
            heart1.BackColor = Color.LightGray;
            Controls.Add(heart2);
            heart2.BackColor = Color.LightGray;
            Controls.Add(heart3);
            heart3.BackColor = Color.LightGray;
            Controls.Add(heart4);
            heart4.BackColor = Color.LightGray;
            heart1.Location = new Point(1920 - (20 + 260), 20);
            heart2.Location = new Point(1920 - (20 + 190), 20);
            heart3.Location = new Point(1920 - (20 + 120), 20);
            heart4.Location = new Point(1920 - (20 + 50), 20);
            heart1.Size = new Size(50, 50);
            heart2.Size = new Size(50, 50);
            heart3.Size = new Size(50, 50);
            heart4.Size = new Size(50, 50);

            heart1.Image = Image.FromFile(@"heart\0.png");
            heart2.Image = Image.FromFile(@"heart\0.png");
            heart3.Image = Image.FromFile(@"heart\0.png");
            heart4.Image = Image.FromFile(@"heart\0.png");

            heart1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            heart1.MouseUp += new MouseEventHandler(Form1_MouseUp);
            heart2.MouseDown += new MouseEventHandler(Form1_MouseDown);
            heart2.MouseUp += new MouseEventHandler(Form1_MouseUp);
            heart3.MouseDown += new MouseEventHandler(Form1_MouseDown);
            heart3.MouseUp += new MouseEventHandler(Form1_MouseUp);
            heart4.MouseDown += new MouseEventHandler(Form1_MouseDown);
            heart4.MouseUp += new MouseEventHandler(Form1_MouseUp);

            heart1.Tag = "1.full";
            heart2.Tag = "2.full";
            heart3.Tag = "3.full";
            heart4.Tag = "4.full";

            backlabel.Location = new Point(1920 - (20 + 260), 80);
            backlabel.Size = new Size(260, 10);
            backlabel.BackColor = Color.FromArgb(104, 104, 104);
            backlabel.MouseDown += new MouseEventHandler(Form1_MouseDown);
            backlabel.MouseUp += new MouseEventHandler(Form1_MouseUp);

            label.Location = new Point(1920 - (20 + 260), 80);
            label.Size = new Size(260, 10);
            label.BackColor = Color.FromArgb(0, 173, 255);
            label.MouseDown += new MouseEventHandler(Form1_MouseDown);
            label.MouseUp += new MouseEventHandler(Form1_MouseUp);
            Controls.Add(label);
            Controls.Add(backlabel);
            whitebackground.Location = new Point(1920 - (20 + 275), 5);
            whitebackground.Size = new Size(290, 100);
            whitebackground.BackColor = Color.LightGray;
            Controls.Add(whitebackground);
            int y = 0;
            StreamReader levelLoader = new StreamReader("level0.txt");

            Controls.Add(picture);

            picture.MouseDown += new MouseEventHandler(Form1_MouseDown);
            picture.MouseUp += new MouseEventHandler(Form1_MouseUp);
            picture.Width = 50;
            picture.Height = 20;

            Button map = new Button();
            Controls.Add(map);
            map.MouseDown += new MouseEventHandler(Form1_MouseDown);
            map.MouseUp += new MouseEventHandler(Form1_MouseUp);
            map.Enabled = false;
            map.Visible = false;

            #region maploader

                while (!levelLoader.EndOfStream)
                {

                    string line = levelLoader.ReadLine();
                    for (int i = 0; i < line.Length; i++)
                    {

                        PictureBox placeHolder = new PictureBox();
                        int n = 0;
                        bool w = false;
                        int oi = i;
                        while (line[i] == 'w')
                        {
                            w = true;
                            n++;
                            i++;

                            if (i == line.Length)
                            {
                                i--;
                                break;
                            }
                            else if (line[i] != 'w')
                            {
                                i--;
                                break;
                            }
                        }
                        if (w && n != 1)
                        {

                            placeHolder.Size = new Size(n * scale, scale);
                            placeHolder.Tag = "wall.map";
                            placeHolder.BackgroundImage = Image.FromFile("wall.png");
                            placeHolder.Name = name.ToString();
                            Controls.Add(placeHolder);

                            placeHolder.MouseDown += new MouseEventHandler(Form1_MouseDown);
                            placeHolder.MouseUp += new MouseEventHandler(Form1_MouseUp);

                            name++;

                        }
                        else if (line[i] == 'c')
                        {

                            player.Size = new Size(50, 100);
                            player.Tag = "player.map";
                            player.Image = Image.FromFile(@"player\right\0.png");
                            Controls.Add(player);

                            player.MouseDown += new MouseEventHandler(Form1_MouseDown);
                            player.MouseUp += new MouseEventHandler(Form1_MouseUp);
                            player.Location = new Point(i * 60, y * 60);

                            player.BackColor = Color.Transparent;
                        }
                        else if (line[i] == 's')
                        {
                            Spawnpoint = new Point(i * scale, y * scale + 40);
                            placeHolder.Size = new Size(scale, scale);
                            placeHolder.Tag = "spawn.wall.map";
                            placeHolder.BackgroundImage = Image.FromFile("wall.png");
                            Controls.Add(placeHolder);

                            placeHolder.MouseDown += new MouseEventHandler(Form1_MouseDown);
                            placeHolder.MouseUp += new MouseEventHandler(Form1_MouseUp);
                        }
                        else if (line[i] == 'h')
                        {

                            placeHolder.Size = new Size(scale, scale);
                            placeHolder.Tag = "health.wall.map";
                            placeHolder.BackgroundImage = Image.FromFile("wall.png");
                            Controls.Add(placeHolder);

                            placeHolder.MouseDown += new MouseEventHandler(Form1_MouseDown);
                            placeHolder.MouseUp += new MouseEventHandler(Form1_MouseUp);
                        }
                        else if (line[i] == 'b')
                        {
                            placeHolder.Size = new Size(60, 60);
                            placeHolder.Tag = "button.wall.map" + (y + 1) + "." + (i + 1);
                            placeHolder.MouseDown += new MouseEventHandler(Form1_MouseDown);
                            placeHolder.MouseUp += new MouseEventHandler(Form1_MouseUp);
                            placeHolder.BackColor = Color.Green;
                            placeHolder.Visible = true;
                            Controls.Add(placeHolder);
                        }
                        else if (line[i] == 'x')
                        {
                            placeHolder.Size = new Size(60, 60);
                            placeHolder.Tag = "danger.wall.map" + (y + 1) + "." + (i + 1);
                            placeHolder.MouseDown += new MouseEventHandler(Form1_MouseDown);
                            placeHolder.MouseUp += new MouseEventHandler(Form1_MouseUp);
                            placeHolder.BackColor = Color.Red;
                            placeHolder.Visible = true;
                            Controls.Add(placeHolder);
                        }
                        else if (line[i] == 'd')
                        {
                            placeHolder.Size = new Size(60, 120);
                            placeHolder.Tag = "door.wall.map" + (y + 1) + "." + (i + 1);
                            placeHolder.MouseDown += new MouseEventHandler(Form1_MouseDown);
                            placeHolder.MouseUp += new MouseEventHandler(Form1_MouseUp);
                            placeHolder.BackColor = Color.Brown;
                            placeHolder.Visible = true;
                            Controls.Add(placeHolder);
                        }
                        if (n > 1)
                        {
                            placeHolder.Top = y * scale + 40;
                            placeHolder.Left = oi * scale;
                        }
                        else
                        {
                            placeHolder.Top = y * scale + 40;
                            placeHolder.Left = i * scale;
                        }

                    }
                    y++;
                }

                levelLoader = new StreamReader("level0.txt");
                int max = 0;
                while (!levelLoader.EndOfStream)
                {
                    string a = levelLoader.ReadLine();
                    if (a.Length > max)
                    {
                        max = a.Length;
                    }
                }
                levelLoader.Close();
                y = 0;
                for (int i = 0; i < max; i++)
                {
                    levelLoader = new StreamReader("level0.txt");
                    string line = "";
                    while (!levelLoader.EndOfStream)
                    {
                        string a = levelLoader.ReadLine();
                        if (i < a.Length)
                        {
                            line = a[i] + line;
                        }
                        else
                        {
                            line = " " + line;
                        }
                    }
                    levelLoader.Close();
                    string mirror = "";
                    for (int j = 0; j < line.Length; j++)
                    {
                        mirror = mirror + line[line.Length - 1 - j];
                    }
                    for (int j = 0; j < line.Length; j++)
                    {

                        PictureBox placeHolder = new PictureBox();
                        int n = 0;
                        bool w = false;
                        int oi = j;
                        while (mirror[j] == 'w')
                        {
                            w = true;
                            n++;
                            j++;
                            if (j == mirror.Length)
                            {
                                j--;
                                break;
                            }
                        }
                        if (w && n != 1)
                        {

                            placeHolder.Size = new Size(scale, n * scale);
                            placeHolder.Tag = "wall.map";
                            placeHolder.BackgroundImage = Image.FromFile("wall.png");

                            Controls.Add(placeHolder);
                            placeHolder.MouseDown += new MouseEventHandler(Form1_MouseDown);
                            placeHolder.MouseUp += new MouseEventHandler(Form1_MouseUp);
                            placeHolder.Name = name.ToString();

                            name++;

                        }
                        placeHolder.Top = oi * scale + 40;
                        placeHolder.Left = y * scale;
                    }
                    y++;
                }

                Console.ReadLine();
                int[] vari = new int[2];
                vari[0] = Width / 2 - player.Width / 2 - player.Left;
                vari[1] = Height * 2 / 3 - player.Height / 2 - player.Top;

                foreach (Control x in Controls)
                {
                    if (x.Tag != null)
                    {
                        if (x.Tag.ToString().Contains("map"))
                        {
                            x.Left += vari[0];
                            x.Top += vari[1];
                        }
                        if (x.Tag.ToString().Contains("player"))
                        {
                            x.Tag = "player";
                        }
                    }
                }

                air.Size = new Size(50, 1);
                air.Location = new Point(player.Left, player.Bottom);
                air.BackColor = Color.FromArgb(0, 173, 255);
                air.Tag = "wall";
                begin = true;
            #endregion
        }

        static int name = 0;
        
        bool rightb = true;
        bool leftb = true;
        PictureBox Background2 = new PictureBox();
        Button back = new Button();
        private void Options_Click(object sender, EventArgs e)
        {
            Background.MouseDown += Form1_MouseDown;
            Background2.MouseDown += Form1_MouseDown;
            back.MouseDown += Form1_MouseDown;

            for (int i = 0; i < 6; i++)
            {
                Controls.Add(opmod[i]);
                opmod[i].MouseDown += Form1_MouseDown;
                opmod[i].Click += opmod_Click;
                opmod[i].KeyDown += opmod_KeyDown;
            }

            Background2.Image = Image.FromFile("white.png");
            Controls.Add(Background2);
            Controls.Add(back);
            Background2.Size = new Size(ActiveForm.Width, ActiveForm.Height);
            Background2.BringToFront();
            back.Click += back_Click;
            
            back.Size = new Size(77, 77);
            back.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            back.Location = new Point(75, 75);
            back.Image = Image.FromFile("backarrow.png");
            back.TabStop = false;
            back.FlatStyle = FlatStyle.Flat;
            back.FlatAppearance.BorderSize = 0;
            back.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            
            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(1, 1, 77, 77);
            back.Region = new Region(p);

           
            back.BringToFront();

            for (int i = 0; i < 6; i++)
            {
                opmod[i].BringToFront();
            }
        }

        private void opmod_KeyDown(object sender, KeyEventArgs e)
        {

        }

        Label[] opmod = new Label[6];
        int opchange = 0;
        bool opbool = false;
        private void opmod_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                if (opmod[i] == sender)
                {
                    opchange = i;
                }
                opmod[i].Enabled = false;
            }
            opbool = true;
            back.Enabled = false;
            
        }

        private void back_Click(object sender, EventArgs e)
        {
            Controls.Remove(Background2);
            Controls.Remove(back);
            for (int i = 0; i < 6; i++)
            {
                Controls.Remove(opmod[i]);
            }
        }
        static PictureBox hat = new PictureBox();
        private void boomerang()
        {
            
            hat.Tag = "bullet.map";
            hat.Size = new Size(26, 13);
            hat.Location = new Point(player.Left + (player.Width / 2 - hat.Width / 2), player.Top + 4);
            hat.Visible = true;
            hat.Enabled = false;
            Controls.Add(hat);
        }

        
        static int anim = 0;
        static bool left = false;
        static bool right = false;
        static string dir = "";
        static bool bullet = false;
        static bool l = true;

        static bool jump = false;

        PictureBox air = new PictureBox();

        bool f = true;
        int healthprev = 4;
        int health = 4;
        List<bool> healthlist = new List<bool>();
        bool skip = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            dangercooldown++;
            
            
           
            foreach (Control x in Controls)
            {
                if (x.Tag != null)
                {
                    if (x.Tag.ToString().Contains("wall") && x.Left < player.Right && x.Right > player.Left && player.Bottom == x.Top)
                    {
                        if (x.Tag.ToString().Contains("danger") && dangercooldown > 200 && health != 0)
                        {
                            health--;
                            dangercooldown = 0;
                        }
                        if (x.Tag.ToString().Contains("health") && healthlist[0] == false)
                        {
                            health++;
                            healthlist[0] = true;
                        }
                    }
                    
                }
            }
            
           
            if (leftb && left && !right)
            {

                foreach (Control x in Controls)
                {
                    if (x.Tag != null)
                    {
                        if (x.Tag.ToString().Contains("map"))
                        {
                            x.Left += speed;
                            if (!skip)
                            {
                                skip = true;
                            }
                        }
                    }
                }
                skip = false;
            }
            if (rightb && right && !left)
            {
                foreach (Control x in Controls)
                {
                    if (x.Tag != null)
                    {
                        if (x.Tag.ToString().Contains("map"))
                        {
                            x.Left -= speed;
                            if (!skip)
                            {
                                skip = true;
                            }
                        }
                    }
                }
                skip = false;

            }
            rightb = true;
            leftb = true;
            
            foreach (Control x in Controls)
            {
                if (x.Tag != null)
                {
                    if (debug)
                    {

                    }
                    if (x.Tag.ToString().Contains("wall"))
                    {
                        if (x.Top == -70)
                        {

                        }
                        if (x.Top < player.Bottom && x.Bottom > player.Top && x.Right == player.Left)
                        {
                            leftb = false;
                        }
                        if ((x.Top < player.Bottom && x.Bottom > player.Top) && x.Left == player.Right)
                        {
                            rightb = false;
                        }
                        if (x.Bounds.IntersectsWith(player.Bounds))
                        {
                            foreach (Control y in Controls)
                            {
                                if (y.Tag != null)
                                {
                                    if (y is PictureBox && y.Tag.ToString().Contains("wall.map"))
                                    {
                                        if (left)
                                        {
                                            y.Left -= speed;
                                            if (!skip)
                                            {
                                                skip = true;
                                            }
                                            
                                        }
                                        if (right)
                                        {
                                            y.Left += speed; 
                                            if (!skip)
                                            {
                                                skip = true;
                                            }
                                        }

                                    }
                                }
                            }
                        }

                    }
                }
            }
            skip = false;
        }

        bool s = true;
        bool keydown = false;
        bool isplaying = false;
        Label Resume = new Label();
        Label Restart = new Label();
        PictureBox Background = new PictureBox();
        private void Resume_Click(object sender, EventArgs e)
        {
            Boomerang.Start();
            Heart.Start();
            Controls.Remove(Resume);
            Controls.Remove(Restart);
            Controls.Remove(pictureBox1);
            Controls.Remove(Exit);
            Controls.Remove(Options);
            Controls.Remove(Background);
            Moonwalk.Start();
            jumptimer.Start();
            Fuel.Start();
            Heart.Start();
            Fallingdamage.Start();
            Boomerang.Start();
            isesc = false;
        }
        private void Restart_Click(object sender, EventArgs e)
        {
            health = 0;
            Boomerang.Start();
            Heart.Start();
            Controls.Remove(Resume);
            Controls.Remove(Restart);
            Controls.Remove(pictureBox1);
            Controls.Remove(Exit);
            Controls.Remove(Options);
            Controls.Remove(Background);
            Moonwalk.Start();
            jumptimer.Start();
            Fuel.Start();
            Heart.Start();
            Fallingdamage.Start();
            Boomerang.Start();
            isesc = false;
        }
        bool isesc = false;
        
        #region Menuevents
        private void Start_MouseEnter(object sender, EventArgs e)
        {
            Start.BackColor = Color.LightGray;
        }
        private void Start_MouseLeave(object sender, EventArgs e)
        {
            Start.BackColor = Color.White;
        }
        private void Options_MouseEnter(object sender, EventArgs e)
        {
            Options.BackColor = Color.LightGray;
        }
        private void Options_MouseLeave(object sender, EventArgs e)
        {
            Options.BackColor = Color.White;
        }
        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            Exit.BackColor = Color.LightGray;
        }
        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.BackColor = Color.White;
        }
        private void Restart_MouseEnter(object sender, EventArgs e)
        {
            Restart.BackColor = Color.LightGray;
        }
        private void Restart_MouseLeave(object sender, EventArgs e)
        {
            Restart.BackColor = Color.White;
        }
        private void Resume_MouseEnter(object sender, EventArgs e)
        {
            Resume.BackColor = Color.LightGray;
        }
        private void Resume_MouseLeave(object sender, EventArgs e)
        {
            Resume.BackColor = Color.White;
        }
        private void opmod_MouseEnter(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                if (opmod[i] == sender)
                {
                    opmod[i].BackColor = Color.LightGray;
                }
            }
        }
        private void opmod_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                if (opmod[i] == sender)
                {
                    opmod[i].BackColor = Color.White;
                }
            }
        }
        #endregion
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (opbool)
            {
                StreamWriter str = new StreamWriter("keyset.txt");
                for (int i = 0; i < 6; i++)
                {
                    if (opchange == i)
                    {
                      //  str.WriteLine(e.KeyCode.ToString());
                        opmod[i].Text = e.KeyCode.ToString(); 
                    }
                    else
                    {
                       // str.WriteLine(opmod[i].Text);
                    }
                }
                str.Close();
                opbool = false;
                for (int i = 0; i < 6; i++)
                {
                    opmod[i].Enabled = true;
                }
                back.Enabled = true;
            }
            else if (e.KeyCode.ToString() == opmod[3].Text && fuelvalue > 0)
            {
                airwalk = true;
                k = 0;
            }
            else if (e.KeyCode.ToString() == opmod[0].Text)
            {
                left = true;
                dir = "left";
                if (jump && !right)
                {
                    int n = anim - 1;
                    if (n < 0)
                    {
                        n = 15;
                    }
                    player.Image = Image.FromFile(@"player\left\" + n + ".png");
                    player.BackColor = Color.Transparent;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (!isesc)
                {
                    Moonwalk.Stop();
                    jumptimer.Stop();
                    Fuel.Stop();
                    Heart.Stop();
                    Fallingdamage.Stop();
                    Boomerang.Stop();


                    Resume.Font = new Font("Consolas",  16F, FontStyle.Bold, GraphicsUnit.Point);
                    Resume.TextAlign = ContentAlignment.MiddleCenter;
                    Restart.Font = new Font("Consolas", 16F, FontStyle.Bold, GraphicsUnit.Point);
                    Restart.TextAlign = ContentAlignment.MiddleCenter;
                    Options.Font = new Font("Consolas", 16F, FontStyle.Bold, GraphicsUnit.Point);
                    Options.TextAlign = ContentAlignment.MiddleCenter;
                    Options.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Options.Width / 2, 450);

                    Background.Size = new Size(ActiveForm.Width, ActiveForm.Height);
                    Background.Image = Image.FromFile("white.png");

                    

                    Resume.Size = new Size(150, 50);
                    Resume.Text = "Resume";
                    Resume.Click += new EventHandler(Resume_Click);
                    Resume.BackColor = Color.White;
                    Resume.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Resume.Width / 2, 400);
                    Resume.MouseEnter += new EventHandler(Resume_MouseEnter);
                    Resume.MouseLeave += new EventHandler(Resume_MouseLeave);

                    Restart.Size = new Size(150, 50);
                    Restart.Text = "Restart";
                    Restart.Click += new EventHandler(Restart_Click);
                    Restart.BackColor = Color.White;
                    Restart.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Restart.Width / 2, 500);
                    Restart.MouseEnter += new EventHandler(Restart_MouseEnter);
                    Restart.MouseLeave += new EventHandler(Restart_MouseLeave);

                    Exit.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Exit.Width / 2, 550);

                    Controls.Add(Resume);
                    Controls.Add(Restart);
                    Controls.Add(Options);
                    Controls.Add(pictureBox1);
                    Controls.Add(Exit);
                    Controls.Add(Background);
                    Background.BringToFront();
                    Resume.BringToFront();
                    Exit.BringToFront();
                    pictureBox1.BringToFront();
                    Restart.BringToFront();
                    Options.BringToFront();
                    isesc = true;
                }
                else
                {
                    Boomerang.Start();
                    Heart.Start();
                    Controls.Remove(Resume);
                    Controls.Remove(pictureBox1);
                    Controls.Remove(Exit);
                    Controls.Remove(Restart);
                    Controls.Remove(Options);
                    Controls.Remove(Background);
                    Moonwalk.Start();
                    jumptimer.Start();
                    Fuel.Start();
                    Heart.Start();
                    Fallingdamage.Start();
                    Boomerang.Start();
                    isesc = false;
                }

            }
            else if (e.KeyCode == Keys.M)
            {
                if (isplaying == true)
                {
                    beatit.Stop();
                    isplaying = false;
                }
                else
                {
                    beatit.PlayLooping();
                    isplaying = true;
                }
            }
            else if (e.KeyCode.ToString() == opmod[1].Text)
            {
                right = true;
                dir = "right";
                if (jump && !left)
                {
                    int n = anim - 1;
                    if (n < 0)
                    {
                        n = 15;
                    }
                    player.Image = Image.FromFile(@"player\right\" + n + ".png");
                    player.BackColor = Color.Transparent;
                }
            }
            else if (e.KeyCode.ToString() == opmod[2].Text && OnPlatform() && !airwalk && !keydown)
            {
                jump = true;
                once = true;
                if (s && OnPlatform(0))
                {
                    airSpeed = 21;
                    Controls.Remove(air);
                    s = false;
                }
                keydown = !keydown;
            }

            else if (e.KeyCode == Keys.B)
            {

                if (debug)
                {
                    debug = false;
                }
                else
                {
                    debug = true;
                }
            }
        }

        

        bool once = false;
        static bool airwalk = false;
        static bool debug = false;

        bool OnPlatform()
        {
            bool plat = false;

            Controls.Add(picture);
            foreach (Control x in Controls)
            {
                if (x.Tag != null)
                {
                    if (x.Tag.ToString().Contains("wall") && x.Left < player.Right && x.Right > player.Left && player.Bottom == x.Top)
                    {
                        if (x.Tag.ToString().Contains("map"))
                        {
                            s = true;
                        }
                        plat = true;
                        Controls.Remove(picture);
                    }
                }
            }
            return plat;
        }
        int dangercooldown = 200;
        bool OnGround()
        {
            bool ground = false;

            
            foreach (Control x in Controls)
            {
                if (x.Tag != null)
                {
                    if (x.Tag.ToString().Contains("wall") && x.Tag.ToString().Contains("map") && x.Left < player.Right && x.Right > player.Left && player.Bottom == x.Top)
                    {
                        ground = true;
                    }
                }
            }
            return ground;
        }
        bool OnPlatform(int i)
        {
            bool plat = true;
            
            Controls.Add(picture);
            foreach (Control x in Controls)
            {
                if (x.Tag != null)
                {
                    if (x.Tag.ToString().Contains("wall") && x.Left < player.Right && x.Right > player.Left && player.Bottom == x.Top)
                    {
                        if (!x.Tag.ToString().Contains("map"))
                        {
                            plat = true;
                            Controls.Remove(picture);
                        }
                        
                    }
                }
            }
            return plat;
        }
        bool HeadHit()
        {
            bool hit = false;
            foreach (Control x in Controls)
            {
                if (x.Tag != null)
                {
                    if (x.Left < player.Right && x.Right > player.Left && player.Top == x.Bottom)
                    {
                        if (x.Tag.ToString().Contains("wall"))
                        {
                            hit = true;
                        }
                    }
                }
            }
            return hit;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == opmod[3].Text)
            {
                if (debug)
                {

                }
                airwalk = false;
                k = 0;
            }
            if (e.KeyCode.ToString() == opmod[0].Text)
            {
                left = false;
                if (!jump && !right)
                {
                    player.Image = Image.FromFile(@"player\left\0.png");
                }
            }
            else if (e.KeyCode.ToString() == opmod[1].Text)
            {
                right = false;
                if (!jump && !left)
                {
                    player.Image = Image.FromFile(@"player\right\0.png");
                }
            }
            else if (e.KeyCode.ToString() == opmod[2].Text && keydown)
            {
                keydown = !keydown;
            }
            else if (e.KeyCode == Keys.B)
            {
                
                

            }
        }
        static int counter = 0;
        static int speedboom = 30;
        static int hatspin = 0;
        public bool ELSE;
        public bool move = true;
       
        private void Boomerang_Tick(object sender, EventArgs e)
        {
            foreach (Control x in Controls)
            {
                ELSE = true;
                if (x.Tag != null)
                {
                    if (x.Tag.ToString().Contains("wall"))
                    {
                        if ((x.Left < hat.Right + (int)(dirx * speedboom) && x.Right > hat.Left + (int)(dirx * speedboom)) && (x.Bottom >= hat.Top + (int)(diry * speedboom)) && x.Bottom <= hat.Top)
                        {
                            counter++;
                            if (x.Tag.ToString().Contains("button"))
                            {
                                StreamReader sr = new StreamReader("button-door.txt");
                                while (!sr.EndOfStream)
                                {
                                    string[] line = sr.ReadLine().Split();
                                    if (x.Tag.ToString().Contains(line[0] + "." + line[1]))
                                    {
                                        foreach (Control y in Controls)
                                        {
                                            if (y.Tag != null)
                                            {
                                                if (y.Tag.ToString().Contains("door"))
                                                {
                                                    if (y.Tag.ToString().Contains(line[2] + "." + line[3]))
                                                    {
                                                        y.Visible = false;
                                                        y.Tag = y.Tag.ToString().Replace(".wall", "");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                sr.Close();
                            }
                           
                            foreach (Control y in Controls)
                            {
                                if (y.Tag != null)
                                {
                                    if (y.Tag.ToString().Contains("wall"))
                                    {
                                        if ((y.Top < hat.Bottom + (int)((x.Bottom - hat.Top) / dirx * diry) && y.Bottom > hat.Top + (int)((x.Bottom - hat.Top) / dirx * diry)) && (y.Right >= hat.Left + (int)((x.Bottom - hat.Top) / diry * dirx)) && y.Right <= hat.Left)
                                        {
                                            hat.Left = y.Right;
                                            counter++;
                                            dirx = dirx * -1;
                                            ELSE = false;
                                        }
                                        else if ((y.Top < hat.Bottom + (int)((x.Bottom - hat.Top) / dirx * diry) && y.Bottom > hat.Top + (int)((x.Bottom - hat.Top) / dirx * diry)) && (y.Left <= hat.Right + (int)((x.Bottom - hat.Top) / diry * dirx)) && y.Left >= hat.Right)
                                        {
                                            hat.Left = y.Left - hat.Width;
                                            dirx = dirx * -1;
                                            counter++;
                                            ELSE = false;
                                        }
                                    }
                                }
                            }
                            if (ELSE)
                            {
                                hat.Left += (int)((x.Bottom - hat.Top) / diry * dirx);
                            }
                            hat.Top = x.Bottom;
                            diry *= -1;
                            move = false;
                        }
                        if ((x.Left < hat.Right + (int)(dirx * speedboom) && x.Right > hat.Left + (int)(dirx * speedboom)) && (x.Top <= hat.Bottom + (int)(diry * speedboom)) && x.Top >= hat.Bottom)
                        {
                            counter++;
                            if (x.Tag.ToString().Contains("button"))
                            {
                                StreamReader sr = new StreamReader("button-door.txt");
                                while (!sr.EndOfStream)
                                {
                                    string[] line = sr.ReadLine().Split();
                                    if (x.Tag.ToString().Contains(line[0] + "." + line[1]))
                                    {
                                        foreach (Control y in Controls)
                                        {
                                            if (y.Tag != null)
                                            {
                                                if (y.Tag.ToString().Contains("door"))
                                                {
                                                    if (y.Tag.ToString().Contains(line[2] + "." + line[3]))
                                                    {
                                                        y.Visible = false;
                                                        y.Tag = y.Tag.ToString().Replace(".wall", "");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                sr.Close();
                            }
                            foreach (Control y in Controls)
                            {
                                if (y.Tag != null)
                                {
                                    if (y.Tag.ToString().Contains("wall"))
                                    {
                                        if ((y.Top < hat.Bottom + (int)((x.Top - hat.Bottom) / dirx * diry) && y.Bottom > hat.Top + (int)((x.Top - hat.Bottom) / dirx * diry)) && (y.Right >= hat.Left + (int)((x.Top - hat.Bottom) / diry * dirx)) && y.Right <= hat.Left)
                                        {
                                            hat.Left = y.Right;
                                            counter++;
                                            dirx = dirx * -1;
                                            ELSE = false;
                                        }
                                        else if ((y.Top < hat.Bottom + (int)((x.Top - hat.Bottom) / dirx * diry) && y.Bottom > hat.Top + (int)((x.Top - hat.Bottom) / dirx * diry)) && (y.Left <= hat.Right + (int)((x.Top - hat.Bottom) / diry * dirx)) && y.Left >= hat.Right)
                                        {
                                            hat.Left = y.Left - hat.Width;
                                            dirx = dirx * -1;
                                            counter++;
                                            ELSE = false;
                                        }
                                    }
                                }
                            }
                            if (ELSE)
                            {
                                hat.Left += (int)((x.Top - hat.Bottom) / diry * dirx);
                            }
                            hat.Top = x.Top - hat.Height;
                            diry *= -1;
                            move = false;
                        }
                        if ((x.Top < hat.Bottom + (int)(diry * speedboom) && x.Bottom > hat.Top + (int)(diry * speedboom)) && (x.Right >= hat.Left + (int)(dirx * speedboom)) && x.Right <= hat.Left)
                        {
                            counter++;
                            if (x.Tag.ToString().Contains("button"))
                            {
                                StreamReader sr = new StreamReader("button-door.txt");
                                while (!sr.EndOfStream)
                                {
                                    string[] line = sr.ReadLine().Split();
                                    if (x.Tag.ToString().Contains(line[0] + "." + line[1]))
                                    {
                                        foreach (Control y in Controls)
                                        {
                                            if (y.Tag != null)
                                            {
                                                if (y.Tag.ToString().Contains("door"))
                                                {
                                                    if (y.Tag.ToString().Contains(line[2] + "." + line[3]))
                                                    {
                                                        y.Visible = false;
                                                        y.Tag = y.Tag.ToString().Replace(".wall", "");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                sr.Close();
                            }
                            foreach (Control y in Controls)
                            {
                                if (y.Tag != null)
                                {
                                    if (y.Tag.ToString().Contains("wall"))
                                    {
                                        if ((y.Left < hat.Right + (int)((x.Right - hat.Left) / diry * dirx) && y.Right > hat.Left + (int)((x.Right - hat.Left) / diry * dirx)) && (y.Bottom >= hat.Top + (int)((x.Right - hat.Left) / dirx * diry)/**/) && y.Bottom <= hat.Top)
                                        {
                                            hat.Top = y.Bottom;
                                            diry *= -1;
                                            counter++;
                                            ELSE = false;
                                        }
                                        else if ((y.Left < hat.Right + (int)((x.Right - hat.Left) / diry * dirx) && y.Right > hat.Left + (int)((x.Right - hat.Left) / diry * dirx)) && (y.Top <= hat.Bottom + (int)((x.Right - hat.Left) / dirx * diry)/**/) && y.Top >= hat.Bottom)
                                        {
                                            hat.Top = y.Top - hat.Height;
                                            diry *= -1;
                                            counter++;
                                            ELSE = false;
                                        }
                                    }
                                }
                            }
                            if (ELSE)
                            {
                                hat.Top += (int)((x.Right - hat.Left) / dirx * diry);
                            }
                            hat.Left = x.Right;
                            dirx *= -1;
                            move = false;
                        }
                        if ((x.Top < hat.Bottom + (int)(diry * speedboom) && x.Bottom > hat.Top + (int)(diry * speedboom)) && (x.Left <= hat.Right + (int)(dirx * speedboom)) && x.Left >= hat.Right)
                        {
                            counter++;
                            if (x.Tag.ToString().Contains("button"))
                            {
                                StreamReader sr = new StreamReader("button-door.txt");
                                while (!sr.EndOfStream)
                                {
                                    string[] line = sr.ReadLine().Split();
                                    if (x.Tag.ToString().Contains(line[0] + "." + line[1]))
                                    {
                                        foreach (Control y in Controls)
                                        {
                                            if (y.Tag != null)
                                            {
                                                if (y.Tag.ToString().Contains("door"))
                                                {
                                                    if (y.Tag.ToString().Contains(line[2] + "." + line[3]))
                                                    {
                                                        y.Visible = false;
                                                        y.Tag = y.Tag.ToString().Replace(".wall", "");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                sr.Close();
                            }
                            foreach (Control y in Controls)
                            {
                                if (y.Tag != null)
                                {
                                    if (y.Tag.ToString().Contains("wall"))
                                    {
                                        if (debug)
                                        {

                                        }
                                        if ((y.Left < hat.Right + (int)((x.Left - hat.Right) / diry * dirx) && y.Right > hat.Left + (int)((x.Left - hat.Right) / diry * dirx)) && (y.Bottom >= hat.Top + (int)((x.Left - hat.Right) / dirx * diry)/**/) && y.Bottom <= hat.Top)
                                        {
                                            hat.Top = y.Bottom;
                                            diry *= -1;
                                            counter++;
                                            ELSE = false;
                                        }
                                        else if ((y.Left < hat.Right + (int)((x.Left - hat.Right) / diry * dirx) && y.Right > hat.Left + (int)((x.Left - hat.Right) / diry * dirx)) && (y.Top <= hat.Bottom + (int)((x.Left - hat.Right) / dirx * diry)/**/) && y.Top >= hat.Bottom)
                                        {
                                            hat.Top = y.Top - hat.Height;
                                            diry *= -1;
                                            counter++;
                                            ELSE = false;
                                        }
                                    }
                                }
                            }
                            if (ELSE)
                            {
                                hat.Top += (int)((x.Left - hat.Right) / dirx * diry);
                            }
                            hat.Left = x.Left - hat.Width;
                            dirx *= -1;
                            move = false;
                        }
                    }
                }
            }
            if (bullet)
            {
                hatspin++;
                if (hatspin % 6 == 0)
                {
                    if (hatspin == 6)
                    {
                        hat.Image = Image.FromFile(@"hat\0.png");
                    }
                    else if(hatspin == 12)
                    {
                        hat.Image = Image.FromFile(@"hat\1.png");
                        hatspin = 0;
                    }
                }                


                if (move || counter == 20)
                {
                    hat.Top += (int)(diry * speedboom);
                    hat.Left += (int)(dirx * speedboom);
                }
                else
                {
                    move = true;
                }
                if (l)
                {
                    boomerang();
                    l = false;
                }
                if (counter == 20)
                {
                    l = true;
                    counter = 0;
                    bullet = false;
                    hat.Visible = false;
                    Controls.Remove(hat);
                    clickenabled = true;
                }
               

                
                
            }
        }

        private void Moonwalk_Tick(object sender, EventArgs e)
        {            
            if (!jump)
            {
                if (leftb && left && !right)
                {
                    player.Image = Image.FromFile(@"player\left\" + anim.ToString() + ".png");
                    anim++;
                    if (anim == 15)
                    {
                        anim = 0;
                    }

                }
                if (rightb && right && !left)
                {
                    player.Image = Image.FromFile(@"player\right\" + anim.ToString() + ".png");
                    anim++;
                    if (anim == 15)
                    {
                        anim = 0;
                    }
                }
            }
        }
        int airSpeed = 21;
        int n = -1;
        int k = 0;


        private void AirTime_Tick(object sender, EventArgs e)
        { 
            if (!airwalk && !f || fuelvalue < 1)
            {
                k++;
                fuelvalue--;
                if (k == 10)
                {
                    airwalk = false;
                    Controls.Remove(air);
                    f = true;
                    k = 0;
                }
            }
            if (airwalk && !f  && fuelvalue > 0)
            {
                jump = false;
            }
            if (HeadHit())
            {
                airSpeed = 0;
            }
            if (OnPlatform())
            {                
                picture.Visible = false;
                n = -1;
            }
            else
            {
                if (begin == true && jump == false)
                {
                    jump = true;
                    airSpeed = 0;
                }
                if (airwalk && f && jump && fuelvalue > 0)
                {
                    if (debug)
                    {

                    }
                    Controls.Add(air);
                    f = false;
                    jump = false;
                }
                foreach (Control x in this.Controls)
                {
                    if (x.Tag != null)
                    {
                        if (x is PictureBox && x.Tag.ToString().Contains("wall") && (x.Left < (picture.Left + picture.Width) && (x.Left + x.Width) > picture.Left) && (x.Top < (picture.Top + picture.Height) + airSpeed) && x.Top > (picture.Top + picture.Height))
                        {
                            picture.Visible = false;
                        }
                    }
                }
            }
            if (jump)
            {
                if (airSpeed > -25)
                {

                    airSpeed--;
                }
                foreach (Control x in Controls)
                {
                    if (x.Tag != null)
                    {
                        if (x.Tag.ToString().Contains("wall"))
                        {
                            if ((x.Left < player.Right && x.Right > player.Left) && (x.Bottom > player.Top - airSpeed) && x.Bottom < player.Top)
                            {
                                airSpeed = player.Top - x.Bottom;
                            }
                            if ((x.Left < player.Right && x.Right > player.Left) && (x.Top < player.Bottom - airSpeed) && x.Top > player.Bottom)
                            {
                                airSpeed = -(x.Top - player.Bottom);
                            }

                        }
                    }
                }
                foreach (Control x in Controls)
                {
                    if (x.Tag != null)
                    {
                        if (x.Tag.ToString().Contains("map"))
                        {
                            x.Top += airSpeed;
                            if (!skip)
                            {
                                skip = true;
                            }
                            
                        }
                    }
                }
                skip = false;
                if (n < 10 && !OnPlatform())
                {
                    bool vis = true;
                    foreach (Control x in Controls)
                    {
                        if (x.Tag != null)
                        {
                            if (x.Tag.ToString().Contains("map") && x.Top - 20 <= player.Bottom && x.Top > player.Bottom && (x.Left < player.Right && x.Right > player.Left))
                            {
                                vis = false;
                            }
                        }
                    }
                    n++;
                    if (((airSpeed > 0 && vis) || (n == 0 && airSpeed == 20)) && once)
                    {
                        picture.Visible = true;
                    }
                    else
                    {
                        picture.Visible = false;
                    }
                    picture.Top = player.Top + player.Height;
                    picture.Left = player.Left;
                    picture.Image = Image.FromFile(@"player\jump\" + n + ".png");
                }
                else
                {
                    picture.Visible = false;
                    n = -1;
                    once = false;
                }
                if (airSpeed == 0)
                {
                    picture.Visible = false;
                }
                if (OnPlatform())
                {
                    if ((dir == "right" || dir == "left") && !left && !right)
                    {
                        player.Image = Image.FromFile(@"player\" + dir + @"\0.png");
                    }
                    jump = false;
                    airSpeed = 21;
                }
            }
        }
        static float dirx;
        static float diry;


        Label whitebackground = new Label();
        Label backlabel = new Label();
        Label label = new Label();
        int fuelvalue = 100;

        private void Fuel_Tick(object sender, EventArgs e)
        {
            label.Width = (int)(fuelvalue * 2.6);
            if (airwalk)
            {
                fuelvalue -= 2;

            }
            else if (fuelvalue < 100 && OnGround())
            {
                fuelvalue += 4;
            }
            if (fuelvalue > 100)
            {
                fuelvalue = 100;
            }
            else if (fuelvalue < 0)
            {
                fuelvalue = 0;
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (opbool)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (opchange == i)
                    {
                        opmod[i].Text = e.Button.ToString();
                    }
                }
                opbool = false;
                for (int i = 0; i < 6; i++)
                {
                    opmod[i].Enabled = true;
                }
                back.Enabled = true;

            }
            else if (e.Button.ToString() == opmod[5].Text)
            {
                counter = 20;
            }
            else if (e.Button.ToString() == opmod[4].Text)
            {
                if (clickenabled)
                {
                    clickenabled = false;
                    bullet = true;
                    if (MousePosition.Y == player.Top + 4 || MousePosition.X == player.Left + player.Width / 2)
                    {
                        if (MousePosition.X == player.Left + player.Width / 2)
                        {
                            diry = 1;
                            if (MousePosition.Y > player.Top + 4)
                            {
                                diry = -1;
                            }
                        }
                        else
                        {
                            dirx = 1;
                            if (MousePosition.X > player.Left + player.Width / 2)
                            {
                                dirx = -1;
                            }
                        }
                    }
                    else
                    {
                        float t = (float)Math.Abs(MousePosition.Y - (player.Top + 4)) / (float)(Math.Abs(MousePosition.Y - (player.Top + player.Width / 2)) + (float)Math.Abs(MousePosition.X - (player.Left + player.Width / 2)));
                        int a = 1;
                        if (MousePosition.Y < player.Top + 4)
                        {
                            a = -1;
                        }
                        diry = t * a;
                        a = 1;
                        if (MousePosition.X < player.Left + player.Width / 2)
                        {
                            a = -1;
                        }
                        dirx = (1 - t) * a;
                    }
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        int h2 = 0;
        int h3 = 0;
        int h4 = 0;

        bool a2 = false;
        bool a3 = false;
        bool a4 = false;
        int fall = 0;
        private void Fallingdamage_Tick(object sender, EventArgs e)
        {
            if (!OnPlatform())
            {
                fall++;
            }
            else
            {
                fall = 0;
            }
            if (fall == 100)
            {
                health--;
                fall = 0;
                airwalk = false;
                k = 0;
            }
        }
        private void Heart_Tick(object sender, EventArgs e)
        {
            if (health == 4)
            {
                heart4.Tag = "4.full";
                healthprev = 4;
                heart4.Image = Image.FromFile(@"heart\" + 0 + ".png");
                h4 = 0;
            }
            if (health == 3)
            {
                if (healthprev == 4)
                {
                    a4 = true;

                }
                else
                {
                    heart3.Tag = "3.full";
                    heart3.Image = Image.FromFile(@"heart\" + 0 + ".png");
                    healthprev = 3;
                    h3 = 0;
                }
                if (a4)
                {
                    healthprev = 3;
                    heart4.Tag = "4.damaged";
                    if (h4 < 20)
                    {
                        h4++;
                        heart4.Image = Image.FromFile(@"heart\" + h4 + ".png");
                    }
                    else
                    {
                        a4 = false;
                    }
                }


            }
            if (health == 2)
            {
                if (healthprev == 3)
                {
                    a3 = true;

                }
                else
                {
                    heart2.Tag = "2.full";
                    heart2.Image = Image.FromFile(@"heart\" + 0 + ".png");
                    healthprev = 2;
                    h2 = 0;
                }
                if (a3)
                {
                    healthprev = 2;
                    heart3.Tag = "3.damaged";
                    if (h3 < 20)
                    {
                        h3++;
                        heart3.Image = Image.FromFile(@"heart\" + h3 + ".png");
                    }
                    else
                    {
                        a3 = false;
                    }
                }
            }
            if (health == 1)
            {
                if (healthprev == 2)
                {
                    a2 = true;

                }
                else
                {
                    heart1.Tag = "1.full";
                    heart1.Image = Image.FromFile(@"heart\" + 0 + ".png");
                    healthprev = 1;
                }
                if (a2)
                {
                    healthprev = 1;
                    heart2.Tag = "2.damaged";
                    if (h2 < 20)
                    {
                        h2++;
                        heart2.Image = Image.FromFile(@"heart\" + h2 + ".png");
                    }
                    else
                    {
                        a2 = false;

                    }
                }
            }
            if (health == 0)
            {
                heart1.Tag = "1.damaged";
                heart1.Image = Image.FromFile(@"heart\" + 20 + ".png");

                int a = 0;
                int b = 0;
                foreach (Control x in Controls)
                {
                    if (x.Tag != null)
                    {
                        if (x.Tag.ToString().Contains("spawn"))
                        {
                            a = Spawnpoint.X - x.Left - 325;
                            b = Spawnpoint.Y - x.Top;
                        }
                    }
                }
                foreach (Control x in Controls)
                {
                    if (x.Tag != null)
                    {
                        if (x.Tag.ToString().Contains("door.map"))
                        {
                           x.Visible = true;
                           x.Tag = x.Tag.ToString().Replace("door", "door.wall");
                        }
                        if (x.Tag.ToString().Contains("map"))
                        {
                            x.Left += a;
                            x.Top += b;
                        }
                    }
                }
                healthprev = 0;
                health = 4;
                heart1.Image = Image.FromFile(@"heart\" + 0 + ".png");
                heart1.Tag = "1.full";
                heart2.Image = Image.FromFile(@"heart\" + 0 + ".png");
                heart2.Tag = "2.full";
                heart3.Image = Image.FromFile(@"heart\" + 0 + ".png");
                heart3.Tag = "3.full";
                heart4.Image = Image.FromFile(@"heart\" + 0 + ".png");
                heart4.Tag = "4.full";

            }
           
        }

        
    }
}
