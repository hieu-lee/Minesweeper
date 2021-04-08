using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp13
{
    public class RestartButton : Button
    {
        GameGrid game;
        public RestartButton(GameGrid game, int x)
        {
            int n = Convert.ToInt16(Math.Floor(Convert.ToDecimal(x / 2)));
            this.Location = new Point(n * 30, 0);
            this.Size = new Size(30, 30);
            this.game = game;
            this.Image = Properties.Resources.SmileFace;
            this.MouseClick += new MouseEventHandler(RestartClick);
        }

        private void RestartClick(object sender, EventArgs e)
        {
            this.game.Restart();
        }
    }
}
