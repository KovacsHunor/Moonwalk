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
            

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        static bool begin = false;
        PictureBox picture = new PictureBox();
        private void Start_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            int y = 0;
            StreamReader levelLoader = new StreamReader("level0.txt");

            Controls.Add(picture);
            picture.Width = 50;
            picture.Height = 20;

            Button map = new Button();
            Controls.Add(map);
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


                        name++;

                    }
                    else if (line[i] == 'c')
                    {

                        player.Size = new Size(50, 100);
                        player.Tag = "player.map";
                        player.Image = Image.FromFile(@"player\right\0.png");
                        Controls.Add(player);
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

                        placeHolder.Size = new Size(scale, (n - 1) * scale);
                        placeHolder.Tag = "wall.map";
                        placeHolder.Image = Image.FromFile("wall.png");

                        Controls.Add(placeHolder);
                        placeHolder.Name = name.ToString();

                        name++;

                    }
                    placeHolder.Top = Convert.ToInt32((oi + 0.5f) * scale);
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
            InitializeComponent();
        }
        static bool x = true;
        static bool p = false;
        static int dis = 0;
        static Label hat = new Label();
        private void bumerang()
        {
            hat.Text = "♪";
            hat.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            hat.Tag = "bullet.map.wall";
            hat.Size = new Size(150, 150);
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
        static int wallminus = 0;
        private void timer1_Tick(object sender, EventArgs e)
            {
            if (airSpeed < 0)
            {

            }
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



                        if ((x.Left < (player.Left + player.Width) && (x.Left + x.Width) > player.Left) && (x.Top < (player.Top + player.Height) + airSpeed) && x.Top >= (player.Top + player.Height))
                        {
                            wallminus = x.Top - player.Bottom;
                        }

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
            else if (e.KeyCode == Keys.B)
            {
                bullet = true;
            }
            else if (e.KeyCode == Keys.Space && OnPlatform())
            {
                jump = true;
                once = true;
                airSpeed = 21;
            }
        }
        bool once = false;
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
        static int a = 0;
        static int counter = 0;
        private void Boomerang_Tick(object sender, EventArgs e)
        {
            if (bullet)
            {
                if (l)
                {
                    bumerang();
                    l = false;
                    locked = dir;
                    if (up && left)
                    {
                        locked = "up";
                        locked2 = "left";
                    }
                    if (down && left)
                    {
                        locked = "down";
                        locked2 = "left";
                    }
                    if (down && right)
                    {
                        locked = "down";
                        locked2 = "right";
                    }
                    if (up && right)
                    {
                        locked = "up";
                        locked2 = "right";
                    }
                }
                if (x)
                {
                    if (dis < 30)
                    {
                        dis++;
                        if (locked == "up" && locked2 == "right")
                        {
                            hat.Top -= 10;
                            hat.Left += 10;
                        }
                        else if (locked == "up" && locked2 == "left")
                        {
                            hat.Top -= 10;
                            hat.Left -= 10;
                        }
                        else if (locked == "down" && locked2 == "left")
                        {
                            hat.Top += 10;
                            hat.Left -= 10;
                        }
                        else if (locked == "down" && locked2 == "right")
                        {
                            hat.Top += 10;
                            hat.Left += 10;
                        }
                        else if (locked == "up")
                        {
                            hat.Top -= 15;
                        }
                        else if (locked == "down")
                        {
                            hat.Top += 15;
                        }

                        else if (locked == "left")
                        {
                            hat.Left -= 15;
                        }

                        else if (locked == "right")
                        {
                            hat.Left += 15;
                        }

                    }

                    if (dis == 30)
                    {

                        a += 10;
                        if (a == 300)
                        {
                            x = false;
                            p = true;
                            dis = 0;
                            a = 0;
                        }


                    }
                }
                if (p)
                {
                    float t = 0;


                    if (hat.Top == player.Top || hat.Left == player.Left)
                    {
                        if (hat.Left == player.Left)
                        {
                            int b = 1;
                            if (hat.Top > player.Top)
                            {
                                b = -1;
                            }
                            hat.Top += 15 * b;
                        }
                        else
                        {
                            int b = 1;
                            if (hat.Left > player.Left)
                            {
                                b = -1;
                            }
                            hat.Left += 15 * b;
                        }
                    }
                    else
                    {
                        t = (float)Math.Abs(hat.Top - player.Top) / (float)(Math.Abs(hat.Top - player.Top) + (float)Math.Abs(hat.Left - player.Left));
                        int a = 1;
                        if (hat.Top > player.Top)
                        {
                            a = -1;
                        }
                        hat.Top += (int)(t * 15) * a;
                        a = 1;
                        if (hat.Left > player.Left)
                        {
                            a = -1;
                        }
                        hat.Left += (15 - ((int)(t * 15))) * a;
                    }


                    if (hat.Bounds.IntersectsWith(player.Bounds))
                    {
                        counter++;
                        if (counter == 10)
                        {
                            p = false;
                            x = true;
                            l = true;
                            locked = dir;
                            locked2 = locked;
                            counter = 0;
                        }
                       

                    }


                }
                if (l)
                {
                    bullet = false;
                    hat.Visible = false;
                    Controls.Remove(hat);
                    dis = 0;
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
    }
}
