using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp13
{
    public class FlagsCounting : TextBox
    {
        public FlagsCounting()
        {
            this.ReadOnly = true;
            this.Location = new System.Drawing.Point(4, 6);
            this.Width = 20;
            this.Height = 30;
            this.BackColor = Color.White;
            this.TextAlign = HorizontalAlignment.Center;
        }
    }
}
