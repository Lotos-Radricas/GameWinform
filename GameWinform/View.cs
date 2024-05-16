using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWinform
{
    internal class View
    {
        private Form1 form1;

        public View(Form1 form1)
        {
            this.form1 = form1;
        }

        // спавн лужи
        public void ShootPotion(string direction)
        {
            Model ShootPotion = new Model();
            ShootPotion.direction = direction;
            ShootPotion.potionLeft = form1.player.Left + (form1.player.Width / 2);
            ShootPotion.potionTop = form1.player.Top + (form1.player.Height / 2);
            ShootPotion.MakePotion(form1);
        }
    }
}
