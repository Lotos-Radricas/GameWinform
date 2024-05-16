using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWinform
{
    internal class Controler
    {
        private Form1 form1;
        public Controler(Form1 form1)
        {
            this.form1 = form1;
        }

        public void KeyD(object sender, KeyEventArgs e)
        {

            if (form1.gameOver == true)
            {
                return;
            }

            if (e.KeyCode == Keys.A)
            {
                form1.goLeft = true;
                form1.facing = "A";
                form1.player.Image = Properties.Resources.left;
            }

            if (e.KeyCode == Keys.D)
            {
                form1.goRight = true;
                form1.facing = "D";
                form1.player.Image = Properties.Resources.right;
            }

            if (e.KeyCode == Keys.W)
            {
                form1.goUp = true;
                form1.facing = "W";
                form1.player.Image = Properties.Resources.up;
            }

            if (e.KeyCode == Keys.S)
            {
                form1.goDown = true;
                form1.facing = "S";
                form1.player.Image = Properties.Resources.down;
            }



        }

        public void KeyU(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                form1.goLeft = false;
            }

            if (e.KeyCode == Keys.D)
            {
                form1.goRight = false;
            }

            if (e.KeyCode == Keys.W)
            {
                form1.goUp = false;
            }

            if (e.KeyCode == Keys.S)
            {
                form1.goDown = false;
            }

            if (e.KeyCode == Keys.Space && form1.ammo > 0 && form1.gameOver == false)
            {
                form1.ammo--;
                form1.ShootPotion(form1.facing);


                if (form1.ammo < 1)
                {
                    form1.DropAmmo();
                }
            }

            if (e.KeyCode == Keys.Enter && form1.gameOver == true)
            {
                form1.RestartGame();
            }

        }
    }
}