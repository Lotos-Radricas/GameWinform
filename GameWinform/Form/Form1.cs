using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWinform
{
    public partial class Form1 : Form
    {
        public Form2 form2;

        public bool goLeft, goRight, goUp, goDown, gameOver;
        public bool drag = false;
        Point startPoint = new Point(0, 0);
        public string facing = "Up";
        public int playerHealth = 100;
        public int speed = 10;
        public int ammo = 5;
        public int snakeSpeed = 4;
        Controler controler;


        Random randNum = new Random();
        int score;

        List<PictureBox> snakesList = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            StartScreenMenu();
            RestartGame();
            controler = new Controler(this);
        }

        public void StartScreenMenu() //Начальное окно
        {
            var form2 = new Form2(this);
            form2.Show();
            form2.TopMost = true;
            this.Enabled = false;
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (playerHealth > 1)
            {
                healthBar.Value = playerHealth;
            }
            else
            {
                gameOver = true;
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();
            }

            txtPotion.Text = "Potion: " + ammo;
            txtScore.Text = "kills: " + score;
                
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if (goUp == true && player.Top > 45)
            {
                player.Top -= speed;
            }
            if (goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }



            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;

                    }
                }


                if (x is PictureBox && (string)x.Tag == "snake")
                {

                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 1;
                    }


                    if (x.Left > player.Left)
                    {
                        x.Left -= snakeSpeed;
                        ((PictureBox)x).Image = Properties.Resources.sleft;
                    }
                    if (x.Left < player.Left)
                    {
                        x.Left += snakeSpeed;
                        ((PictureBox)x).Image = Properties.Resources.sright;
                    }
                    if (x.Top > player.Top)
                    {
                        x.Top -= snakeSpeed;
                        ((PictureBox)x).Image = Properties.Resources.sup;
                    }
                    if (x.Top < player.Top)
                    {
                        x.Top += snakeSpeed;
                        ((PictureBox)x).Image = Properties.Resources.sdown;
                    }

                }



                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "potion" && x is PictureBox && (string)x.Tag == "snake")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            snakesList.Remove(((PictureBox)x));
                            MakeMonster();
                        }
                    }
                }
            }
        }


        // дял контроллера 
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            controler.KeyD(sender, e);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            controler.KeyU(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }


        // спавн лужи
        public void ShootPotion(string direction)
        {
            Potion ShootPotion = new Potion();
            ShootPotion.direction = direction;
            ShootPotion.potionLeft = player.Left + (player.Width / 2);
            ShootPotion.potionTop = player.Top + (player.Height / 2);
            ShootPotion.MakePotion(this);
        }

        // спавн змей
        private void MakeMonster()
        {
            PictureBox monster = new PictureBox();
            monster.BackColor = Color.Transparent;
            monster.Tag = "snake";
            monster.Image = Properties.Resources.sdown;
            monster.Left = randNum.Next(0, 900);
            monster.Top = randNum.Next(0, 800);
            monster.SizeMode = PictureBoxSizeMode.AutoSize;
            monster.BringToFront();
            snakesList.Add(monster);
            this.Controls.Add(monster);
            player.BringToFront();
        }

        // спавн зелий
        public void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.potion_img;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = randNum.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = randNum.Next(60, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }

        // рестарт
        public void RestartGame()
        {
            player.Image = Properties.Resources.up;

            foreach (PictureBox i in snakesList)
            {
                this.Controls.Remove(i);
            }

            snakesList.Clear();

            for (int i = 0; i < 3; i++)
            {
                MakeMonster();
            }

            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            gameOver = false;

            playerHealth = 100;
            score = 0;
            ammo = 10;

            GameTimer.Start();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        // панель
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        // выход
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
