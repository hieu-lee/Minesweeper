using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp13
{
    public class Square : Button
    {
        public FlagsCounting box;
        public GameGrid game;
        public int row_pos;
        public int col_pos;
        public bool revealed;
        public bool flagged;
        public bool mined;
        public int mines_nearby;

        private void SquareClick(object sender, MouseEventArgs e)
        {
            int i = this.row_pos;
            int j = this.col_pos;
            if (e.Button == MouseButtons.Left)
            {
                if (!game.started)
                {
                    game.started = true;
                    Random rnd = new Random();
                    int n = rnd.Next(1, 4);
                    this.mines_nearby = n;
                    game.RandomGameAlter(game.app.mines, i, j);
                    game.t = DateTime.Now;
                    game.timecounter.Start();
                }
                HashSet<Tuple<int, int>> res = this.game.Reveal(i, j);
                if (this.revealed)
                {
                    if (!this.mined)
                    {
                        res = this.game.Chording(i, j, res);
                    }
                }
                Parallel.ForEach<Tuple<int, int>>(res, sq =>
                {
                    int u = sq.Item1;
                    int v = sq.Item2;
                    this.game.Draw(u, v);
                });
                if (this.game.lose)
                {
                    this.game.GameOver(false);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (!game.started)
                {
                    game.started = true;
                    game.RandomGame(game.app.mines);
                    game.t = DateTime.Now;
                    game.timecounter.Start();
                }
                if (!this.revealed)
                {
                    if (this.flagged)
                    {
                        this.flagged = false;
                        this.game.nflags -= 1;
                        this.game.flags_left += 1;
                        if (this.mined)
                        {
                            this.game.undetected_mines += 1;
                        }
                    }
                    else if (this.game.flags_left > 0)
                    {
                        this.flagged = true;
                        this.game.nflags += 1;
                        this.game.flags_left -= 1;
                        if (this.mined)
                        {
                            this.game.undetected_mines -= 1;
                        }
                    }
                    this.game.Draw(i, j);
                    this.box.Text = this.game.flags_left.ToString();
                    if (this.game.undetected_mines == 0)
                    {
                        this.game.GameOver(true);
                    }
                }

            }
            
        }

        
        public Square(int i, int j, GameGrid game, FlagsCounting box)
        {
            this.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.FlatAppearance.BorderColor = Color.Black;
            this.FlatStyle = FlatStyle.Flat;
            this.box = box;
            this.Location = new Point(i * 30, (j + 1) * 30);
            this.Size = new Size(30, 30);
            this.BackColor = Color.FromArgb(180, 180, 180);
            this.game = game;
            this.row_pos = i;
            this.col_pos = j;
            this.mined = false;
            this.flagged = false;
            this.revealed = false;
            this.mines_nearby = 0;
            this.MouseDown += new MouseEventHandler(SquareClick);
        }
        public void Reset()
        {
            this.BackColor = Color.FromArgb(180, 180, 180);
            this.revealed = false;
            this.flagged = false;
            this.mined = false;
            this.mines_nearby = 0;
        }

        public override string ToString()
        {
            if (this.mined)
            {
                return "*";
            }
            else if (this.mines_nearby == 0)
            {
                return ".";
            }
            return this.mines_nearby.ToString();
        }

        public string ToStringForPlayer()
        {
            if (!this.revealed)
            {
                if (this.flagged)
                {
                    return "F";
                }
                return "#";
            }
            if (this.mined)
            {
                return "*";
            }
            if (this.mines_nearby == 0)
            {
                return ".";
            }
            return this.mines_nearby.ToString();
        }
    }
}
