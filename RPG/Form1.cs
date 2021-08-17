using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            beatit.SoundLocation = "beat.wav";
            beatit.PlayLooping();
           
        }
        System.Media.SoundPlayer beatit = new System.Media.SoundPlayer();

        
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        static bool begin = false;
        PictureBox picture = new PictureBox();
        static bool clickenabled = false;
        private void Start_Click(object sender, EventArgs e)
        {
            clickenabled = true;
            Controls.Clear();
            int y = 0;
            StreamReader levelLoader = new StreamReader("level0.txt");

            Controls.Add(picture);

            picture.MouseClick += new MouseEventHandler(Form1_MouseClick);
            picture.Width = 50;
            picture.Height = 20;

            Button map = new Button();
            Controls.Add(map);
            map.MouseClick += new MouseEventHandler(Form1_MouseClick);
            map.Enabled = false;
            map.Visible = false;
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
                    }
                    if (w && n != 1)
                    {

                        placeHolder.Size = new Size(n * scale, scale);
                        placeHolder.Tag = "wall.map";
                        placeHolder.BackgroundImage = Image.FromFile("wall.png");
                        placeHolder.Name = name.ToString();
                        Controls.Add(placeHolder);

                        placeHolder.MouseClick += new MouseEventHandler(Form1_MouseClick);

                        name++;

                    }
                    else if (line[i] == 'c')
                    {

                        player.Size = new Size(50, 100);
                        player.Tag = "player.map";
                        player.Image = Image.FromFile(@"player\right\0.png");
                        Controls.Add(player);

                        player.MouseClick += new MouseEventHandler(Form1_MouseClick);
                        player.Top = y * 60;
                        player.Left = i * 60;
                        player.BackColor = Color.Transparent;
                    }
                    placeHolder.Top = y * scale + 40;
                    placeHolder.Left = oi * scale;

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
                        placeHolder.MouseClick += new MouseEventHandler(Form1_MouseClick);
                        placeHolder.Name = name.ToString();

                        name++;

                    }
                    placeHolder.Top = (int)((oi + 0.66667) * scale);
                    placeHolder.Left = y * scale;
                }
                y++;
            }

            Console.ReadLine();
            int[] vari = new int[2];
            vari[0] = (int)(this.Width / 2 - player.Width / 2) - player.Left;
            vari[1] = (int)(this.Height * 2 / 3 - player.Height / 2) - player.Top;

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
            begin = true;
        }

        static int name = 0;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static bool upb = true;
        static bool downb = true;
        static bool rightb = true;
        static bool leftb = true;
        private void Options_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            Button back = new Button();
            back.Click += back_Click;
            back.Left = 880;
            back.Top = 400;
            back.Visible = true;
            back.Size = new Size(200, 50);
            back.UseVisualStyleBackColor = true;
            back.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            back.Text = "Back To The Menu";
            Controls.Add(back);
        }

        private void back_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            Controls.Add(Start);
            Controls.Add(pictureBox1);
            Controls.Add(Options);
            Controls.Add(Exit);
        }
        static bool p = false;
        static PictureBox hat = new PictureBox();
        private void bumerang()
        {
            
            hat.Tag = "bullet.map.wall";
            hat.Size = new Size(26, 13);
            hat.Location = player.Location;
            hat.Visible = true;
            hat.Enabled = false;
            Controls.Add(hat);
        }

        private void TITLE_Click(object sender, EventArgs e)
        {

        }
        static int anim = 0;
        static bool up = false;
        static bool left = false;
        static bool down = false;
        static bool right = false;
        static string dir = "";
        static bool bullet = false;
        static bool l = true;
        static string locked = dir;
        static string locked2 = locked;

        static bool jump = false;

        private void timer1_Tick(object sender, EventArgs e)
            {
            if (upb && up && !down)
            {
                foreach (Control x in Controls)
                {
                    if (x.Tag != null)
                    {
                        if (x.Tag.ToString().Contains("map"))
                        {
                            x.Top += speed;
                        }
                    }
                }
            }
            if (downb && down && !up)
            {
                foreach (Control x in Controls)
                {
                    if (x.Tag != null)
                    {
                        if (x.Tag.ToString().Contains("map"))
                        {
                            x.Top -= speed;
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
                        }
                    }
                }
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
                        }
                    }
                }

            }
            upb = true;
            downb = true;
            rightb = true;
            leftb = true;

            foreach (Control x in this.Controls)
            {
                if (x.Tag != null)
                {
                    if (x is PictureBox && x.Tag.ToString().Contains("wall"))
                    {
                        if ((x.Top < (player.Top + player.Height) && (x.Top + x.Height) > player.Top) && (x.Left + x.Width) == player.Left)
                        {
                            leftb = false;
                        }
                        if ((x.Top < (player.Top + player.Height) && (x.Top + x.Height) > player.Top) && x.Left == (player.Left + player.Width))
                        {
                            rightb = false;
                        }
                        if (x.Bounds.IntersectsWith(player.Bounds))
                        {
                            foreach (Control y in Controls)
                            {
                                if (y.Tag != null)
                                {
                                    if (y is PictureBox && y.Tag.ToString().Contains("wall"))
                                    {
                                        if (left)
                                        {
                                            y.Left += -speed;
                                        }
                                        if (right)
                                        {
                                            y.Left -= -speed;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
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
            else if (e.KeyCode == Keys.D)
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
            else if (e.KeyCode == Keys.Space && OnPlatform())
            {
                jump = true;
                once = true;
                airSpeed = 21;
            }
            else if (e.KeyCode == Keys.B)
            {
                debug = true;
            }
        }
        bool once = false;

        static bool debug = false;

        bool OnPlatform()
        {
            bool plat = false;
            foreach (Control x in Controls)
            {
                if (x.Tag != null)
                {
                    if (x.Tag.ToString().Contains("wall") && x.Left < player.Right && x.Right > player.Left && player.Bottom == x.Top)
                    {
                        plat = true;
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
                    if (x.Tag.ToString().Contains("wall") && x.Left < player.Right && x.Right > player.Left && player.Top == x.Bottom)
                    {
                        hit = true;
                    }
                }
            }
            return hit;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                up = false;
            }
            else if (e.KeyCode == Keys.A)
            {
                left = false;
                if (!jump && !right)
                {
                    player.Image = Image.FromFile(@"player\left\0.png");
                }
            }
            else if (e.KeyCode == Keys.S)
            {
                down = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                right = false;
                if (!jump && !left)
                {
                    player.Image = Image.FromFile(@"player\right\0.png");
                }
            }
        }
        static int counter = 0;
        static int speedboom = 30;
        static int hatspin = 0;
        public bool ELSE;
        public int move = 0;
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
                            foreach (Control y in Controls)
                            {
                                if (y.Tag != null)
                                {
                                    if (y.Tag.ToString().Contains("wall"))
                                    {
                                        if ((y.Top < hat.Bottom + (int)((x.Bottom - hat.Top) / dirx * diry) && y.Bottom > hat.Top + (int)((x.Bottom - hat.Top) / dirx * diry)) && (y.Right >= hat.Left + (int)((x.Bottom - hat.Top) / diry * dirx)) && y.Right <= hat.Left)
                                        {
                                            //hat.Top += (int)((y.Right - hat.Left) / dirx * diry);
                                            hat.Left = y.Right;
                                            dirx = dirx * -1;
                                            ELSE = false;
                                        }
                                        else if ((y.Top < hat.Bottom + (int)((x.Bottom - hat.Top) / dirx * diry) && y.Bottom > hat.Top + (int)((x.Bottom - hat.Top) / dirx * diry)) && (y.Left <= hat.Right + (int)((x.Bottom - hat.Top) / diry * dirx)) && y.Left >= hat.Right)
                                        {
                                            //hat.Top += (int)((y.Right - hat.Left) / dirx * diry);
                                            hat.Left = y.Left - hat.Width;
                                            dirx = dirx * -1;
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
                            diry = diry * -1;
                            move++;
                        }
                        if ((x.Left < hat.Right + (int)(dirx * speedboom) && x.Right > hat.Left + (int)(dirx * speedboom)) && (x.Top <= hat.Bottom + (int)(diry * speedboom)) && x.Top >= hat.Bottom)
                        {
                            foreach (Control y in Controls)
                            {
                                if (y.Tag != null)
                                {
                                    if (y.Tag.ToString().Contains("wall"))
                                    {
                                        if ((y.Top < hat.Bottom + (int)((x.Top - hat.Bottom) / dirx * diry) && y.Bottom > hat.Top + (int)((x.Top - hat.Bottom) / dirx * diry)) && (y.Right >= hat.Left + (int)((x.Top - hat.Bottom) / diry * dirx)) && y.Right <= hat.Left)
                                        {
                                            //hat.Top += (int)((y.Right - hat.Left) / dirx * diry);
                                            hat.Left = y.Right;
                                            dirx = dirx * -1;
                                            ELSE = false;
                                        }
                                        else if ((y.Top < hat.Bottom + (int)((x.Top - hat.Bottom) / dirx * diry) && y.Bottom > hat.Top + (int)((x.Top - hat.Bottom) / dirx * diry)) && (y.Left <= hat.Right + (int)((x.Top - hat.Bottom) / diry * dirx)) && y.Left >= hat.Right)
                                        {
                                            //hat.Top += (int)((y.Left - hat.Right) / dirx * diry);
                                            hat.Left = y.Left - hat.Width;
                                            dirx = dirx * -1;
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
                            diry = diry * -1;
                            move++;
                        }
                        if ((x.Top < hat.Bottom + (int)(diry * speedboom) && x.Bottom > hat.Top + (int)(diry * speedboom)) && (x.Right >= hat.Left + (int)(dirx * speedboom)) && x.Right <= hat.Left)
                        {
                            foreach (Control y in Controls)
                            {
                                if (y.Tag != null)
                                {
                                    if (y.Tag.ToString().Contains("wall"))
                                    {
                                        if ((y.Left < hat.Right + (int)((x.Right - hat.Left) / diry * dirx) && y.Right > hat.Left + (int)((x.Right - hat.Left) / diry * dirx)) && (y.Bottom >= hat.Top + (int)((x.Right - hat.Left) / dirx * diry)/**/) && y.Bottom <= hat.Top)
                                        {
                                            //hat.Left += (int)((y.Bottom - hat.Top) / diry * dirx);
                                            hat.Top = y.Bottom;
                                            diry = diry * -1;
                                            ELSE = false;
                                        }
                                        else if ((y.Left < hat.Right + (int)((x.Right - hat.Left) / diry * dirx) && y.Right > hat.Left + (int)((x.Right - hat.Left) / diry * dirx)) && (y.Top <= hat.Bottom + (int)((x.Right - hat.Left) / dirx * diry)/**/) && y.Top >= hat.Bottom)
                                        {
                                            //hat.Left += (int)((y.Top - hat.Bottom) / diry * dirx);
                                            hat.Top = y.Top - hat.Height;
                                            diry = diry * -1;
                                            ELSE = false;
                                        }
                                    }
                                }
                            }
                            if (ELSE)
                            {
                                hat.Top += (int)((x.Right - hat.Left) / dirx * diry)/**/;
                            }
                            hat.Left = x.Right;
                            dirx = dirx * -1;
                            move++;
                        }
                        if ((x.Top < hat.Bottom + (int)(diry * speedboom) && x.Bottom > hat.Top + (int)(diry * speedboom)) && (x.Left <= hat.Right + (int)(dirx * speedboom)) && x.Left >= hat.Right)
                        {
                            
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
                                            diry = diry * -1;
                                            ELSE = false;
                                        }
                                        else if ((y.Left < hat.Right + (int)((x.Left - hat.Right) / diry * dirx) && y.Right > hat.Left + (int)((x.Left - hat.Right) / diry * dirx)) && (y.Top <= hat.Bottom + (int)((x.Left - hat.Right) / dirx * diry)/**/) && y.Top >= hat.Bottom)
                                        {
                                            hat.Top = y.Top - hat.Height;
                                            diry = diry * -1;
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
                            dirx = dirx * -1;
                            move++;
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
                if (move == 0 || p)
                {
                    hat.Top += (int)(diry * speedboom);
                    hat.Left += (int)(dirx * speedboom);
                }
                else
                {
                    move = 0;
                }
                if (l)
                {
                    bumerang();
                    l = false;
                }
                if (p)
                {
                    if (hat.Top == (player.Top + 15) || hat.Left == (player.Left + (player.Width / 2)))
                    {
                        if (hat.Left == (player.Left + (player.Width / 2)))
                        {
                            diry = 1;
                            if (hat.Top > (player.Top + 15))
                            {
                                diry = -1;
                            }
                        }
                        else
                        {
                            dirx = 1;
                            if (hat.Left > (player.Left + (player.Width / 2)))
                            {
                                dirx = -1;
                            }
                        }
                    }
                    else
                    {
                        float t = (float)Math.Abs(hat.Top - (player.Top + 15)) / (float)(Math.Abs(hat.Top - (player.Top + 15)) + (float)Math.Abs(hat.Left - (player.Left + (player.Width / 2))));
                        int a = 1;
                        if (hat.Top > (player.Top + 15))
                        {
                            a = -1;
                        }
                        diry = t * a;
                        a = 1;
                        if (hat.Left > (player.Left + (player.Width / 2)))
                        {
                            a = -1;
                        }
                        dirx = (1 - t) * a;
                    }


                    if (hat.Bounds.IntersectsWith(player.Bounds))
                    {
                        counter++;
                        if (counter == 5)
                        {
                            p = false;
                            l = true;
                            counter = 0;
                        }
                    }
                }
                if (l)
                {
                    bullet = false;
                    hat.Visible = false;
                    Controls.Remove(hat);
                }

                if (!p)
                {
                    counter++;
                }
                if (counter == 100)
                {
                    clickenabled = true;
                    p = true;
                    counter = 0;
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
        static int airSpeed = 21;

        int n = -1;
        private void AirTime_Tick(object sender, EventArgs e)
        {
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
                airSpeed--;
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
                        }
                    }
                }
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

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (clickenabled)
            {
                clickenabled = false;
                bullet = true;
                if (MousePosition.Y == player.Top + (int)player.Height / 2 || MousePosition.X == player.Left + (int)player.Width / 2)
                {
                    if (MousePosition.X == player.Left + (int)player.Width / 2)
                    {
                        diry = 1;
                        if (MousePosition.Y > player.Top + (int)player.Height / 2)
                        {
                            diry = -1;
                        }
                    }
                    else
                    {
                        dirx = 1;
                        if (MousePosition.X > player.Left + (int)player.Width / 2)
                        {
                            dirx = -1;
                        }
                    }
                }
                else
                {
                    float t = (float)Math.Abs(MousePosition.Y - (player.Top + (int)player.Height / 2)) / (float)(Math.Abs(MousePosition.Y - (player.Top + (int)player.Width / 2)) + (float)Math.Abs(MousePosition.X - (player.Left + (int)player.Width / 2)));
                    int a = 1;
                    if (MousePosition.Y < player.Top + (int)player.Height / 2)
                    {
                        a = -1;
                    }
                    diry = t * a;
                    a = 1;
                    if (MousePosition.X < player.Left + (int)player.Width / 2)
                    {
                        a = -1;
                    }
                    dirx = (1 - t) * a;
                }
            }
        }
    }
}
