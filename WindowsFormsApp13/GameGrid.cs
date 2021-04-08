using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using MongoDB.Driver;
using System.Net;

namespace WindowsFormsApp13
{
    public class GameGrid
    {
        private Dictionary<int, string> difficulty;
        private IMongoCollection<Score> collection;
        private int mode;
        public System.Windows.Forms.Timer timecounter = new System.Windows.Forms.Timer();
        public TimeSpan time;
        public DateTime t;
        public List<Tuple<int, int>> index = new List<Tuple<int, int>>();
        public RestartButton button;
        public Color white = Color.White;
        public FlagsCounting box;
        public Form1 app;
        public int nrows, ncols;
        public int nmines = 0;
        public int nflags = 0;
        public int squares_revealed = 0;
        public int undetected_mines;
        public int flags_left;
        public bool lose;
        public Square[,] tabs;
        public bool started;

        public GameGrid(int x, int y, Form1 app, FlagsCounting box)
        {
            this.difficulty = new Dictionary<int, string>(3);
            this.collection = app.collection;
            this.timecounter.Interval = 100;
            this.timecounter.Tick += new EventHandler(TimeUpdate);
            this.box = box;
            this.app = app;
            this.mode = this.app.mode;
            this.nrows = x;
            this.ncols = y;
            this.button = new RestartButton(this, this.nrows);
            this.tabs = new Square[nrows, ncols];
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncols; j++)
                {
                    this.index.Add(Tuple.Create<int, int>(i, j));
                    this.tabs[i, j] = new Square(i, j, this, box);
                }
            }
            this.difficulty.Add(0, "easy");
            this.difficulty.Add(1, "normal");
            this.difficulty.Add(2, "expert");
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < this.nrows; i++)
            {
                string[] line = new string[ncols];
                for (int j = 0; j < this.ncols; j++)
                {
                    line[j] = this.tabs[i, j].ToString();
                }
                string s;
                s = string.Join("", line) + "\n";
                res += s;
            }
            return res;
        }

        public string ToStringForPlayer()
        {
            string res = "";
            for (int i = 0; i < nrows; i++)
            {
                string[] line = new string[ncols];
                for (int j = 0; j < this.ncols; j++)
                {
                    line[j] = this.tabs[i, j].ToStringForPlayer();
                }
                string s;
                s = string.Join("", line) + "\n";
                res += s;
            }
            return res;
        }

        public bool IsInside(Tuple<int, int> x)
        {
            int i, j;
            i = x.Item1;
            j = x.Item2;
            return (0 <= i & i < nrows & 0 <= j & j < ncols);
        }

        public Tuple<int, int>[] neighbors(int i, int j)
        {
            List<Tuple<int, int>> res = new List<Tuple<int, int>>();
            Tuple<int, int>[] neighbors_set = new Tuple<int, int>[8] {Tuple.Create<int, int>(i + 1, j), Tuple.Create<int, int>(i, j + 1), Tuple.Create<int, int>(i - 1, j), Tuple.Create<int, int>(i, j - 1),
                         Tuple.Create<int, int>(i + 1, j + 1), Tuple.Create<int, int>(i - 1, j - 1), Tuple.Create<int, int>(i + 1, j - 1), Tuple.Create<int, int>(i - 1, j + 1)};
            foreach (Tuple<int, int> sq in neighbors_set)
            {
                if (this.IsInside(sq))
                {
                    res.Add(sq);
                }
            }
            return res.ToArray();
        }

        public Square SquareAt(int i, int j)
        {
            return this.tabs[i, j];
        }

        public bool revealed(int i, int j)
        {
            return this.tabs[i, j].revealed;
        }

        public bool flagged(int i, int j)
        {
            return this.tabs[i, j].flagged;
        }

        public bool mined(int i, int j)
        {
            return this.tabs[i, j].mined;
        }

        public int MinesNearby(int i, int j)
        {
            return this.tabs[i, j].mines_nearby;
        }

        public int FlagsNearby(int i, int j)
        {
            int res = 0;
            Tuple<int, int>[] neighbors = this.neighbors(i, j);
            foreach (Tuple<int, int> sq in neighbors)
            {
                int u = sq.Item1;
                int v = sq.Item2;
                if (this.flagged(u, v))
                {
                    res += 1;
                }
            }
            return res;
        }

        public void PlaceMine(int i, int j)
        {
            if (!this.tabs[i, j].mined)
            {
                this.tabs[i, j].mined = true;
                this.nmines += 1;
                Tuple<int, int>[] neighbors = this.neighbors(i, j);
                foreach (Tuple<int, int> sq in neighbors)
                {
                    int u = sq.Item1;
                    int v = sq.Item2;
                    this.tabs[u, v].mines_nearby += 1;
                }
            }
        }

        public void PlaceMineAlter(int i, int j, int a, int b)
        {
            if (!this.tabs[i, j].mined)
            {
                this.tabs[i, j].mined = true;
                this.nmines += 1;
                Tuple<int, int>[] neighbors = this.neighbors(i, j);
                foreach (Tuple<int, int> sq in neighbors)
                {
                    int u = sq.Item1;
                    int v = sq.Item2;
                    if (u!=a | v!=b)
                    {
                        this.tabs[u, v].mines_nearby += 1;
                    }  
                }
            }
        }

        public HashSet<Tuple<int, int>> RevealHelper(int i, int j, HashSet<Tuple<int, int>> a)
        {
            if (this.tabs[i, j].revealed | this.tabs[i, j].flagged)
            {
                return a;
            }
            this.tabs[i, j].revealed = true;
            a.Add(Tuple.Create<int, int>(i, j));
            this.squares_revealed += 1;
            if (this.tabs[i, j].mines_nearby == 0 & !this.tabs[i, j].mined)
            {
                Tuple<int, int>[] neighbors = this.neighbors(i, j);
                foreach (Tuple<int, int> sq in neighbors)
                {
                    int u = sq.Item1;
                    int v = sq.Item2;
                    a = this.RevealHelper(u, v, a);
                }
            }
            if (this.tabs[i, j].mined)
            {
                this.lose = true;
            }
            return a;
        }

        public HashSet<Tuple<int, int>> Reveal(int i, int j)
        {
            return this.RevealHelper(i, j, new HashSet<Tuple<int, int>>());
        }

        public HashSet<Tuple<int, int>> Chording(int i, int j, HashSet<Tuple<int, int>> a)
        {
            if (this.FlagsNearby(i, j) == this.MinesNearby(i, j))
            {
                Tuple<int, int>[] neighbors = this.neighbors(i, j);
                foreach (Tuple<int, int> sq in neighbors)
                {
                    int u = sq.Item1;
                    int v = sq.Item2;
                    if (!this.tabs[u, v].flagged)
                    {
                        a = this.RevealHelper(u, v, a);
                    }
                }
            }
            return a;
        }

        public void RandomGameAlter(int n_mines, int a, int b)
        {
            Random rnd = new Random();
            if (n_mines < 0 | n_mines > this.ncols * this.nrows)
            {
                throw new Exception("invalid number of mines.");
            }
            if (n_mines > 0)
            {
                int m = this.tabs[a, b].mines_nearby;
                HashSet<Tuple<int, int>> check = new HashSet<Tuple<int, int>>();
                Tuple<int, int>[] neighbors = this.neighbors(a, b);
                foreach (Tuple<int, int> neighbor in neighbors)
                {
                    check.Add(neighbor);
                }
                for (int k = 0; k < m; k++)
                {
                    Random rand = new Random();
                    int r = rand.Next(0, neighbors.Length);
                    int x = neighbors[r].Item1;
                    int y = neighbors[r].Item2;
                    while (this.tabs[x,y].mined)
                    {
                        r = rand.Next(0, neighbors.Length);
                        x = neighbors[r].Item1;
                        y = neighbors[r].Item2;
                    }
                    this.PlaceMineAlter(x, y, a, b);
                }
                for (int i = 0; i < n_mines - m; i++)
                {
                    int u = rnd.Next(0, this.nrows);
                    int v = rnd.Next(0, this.ncols);
                    Tuple<int,int> t = Tuple.Create<int, int>(u, v);
                    while (this.tabs[u, v].mined || check.Contains(t) || (u == a && v == b))
                    {
                        u = rnd.Next(0, this.nrows);
                        v = rnd.Next(0, this.ncols);
                        t = Tuple.Create<int, int>(u, v);
                    }
                    this.PlaceMineAlter(u, v, a, b);
                }
                this.undetected_mines = this.nmines;
                this.flags_left = this.nmines;
                this.box.Text = this.flags_left.ToString();
            }
        }

        public void RandomGame(int n_mines)
        {
            Random rnd = new Random();
            if (n_mines < 0 | n_mines > this.ncols * this.nrows)
            {
                throw new Exception("invalid number of mines.");
            }
            if (n_mines > 0)
            {
                for (int i = 0; i < n_mines; i++)
                {
                    int u = rnd.Next(0, this.nrows);
                    int v = rnd.Next(0, this.ncols);
                    while (this.tabs[u, v].mined)
                    {
                        u = rnd.Next(0, this.nrows);
                        v = rnd.Next(0, this.ncols);
                    }
                    this.PlaceMine(u, v);
                }
                this.undetected_mines = this.nmines;
                this.flags_left = this.nmines;
                this.box.Text = this.flags_left.ToString();
            }
        }

        public void Reset()
        {
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncols; j++)
                {
                    this.SquareAt(i, j).Reset();
                }
            }
            this.box.Text = this.nmines.ToString();
            this.nmines = 0;
            this.nflags = 0;
            this.lose = false;
            this.squares_revealed = 0;
            this.started = false;
        }

        public void Draw(int i, int j)
        {
            Square square = this.tabs[i, j];
            if (square.flagged | square.revealed)
            {
                if (square.flagged)
                {
                    square.Image = Properties.Resources.flag;
                }
                else
                {
                    square.BackColor = this.white;
                    if (!square.mined)
                    {
                        int m = square.mines_nearby;
                        if (m != 0)
                        {
                            switch (m)
                            {
                                case 1:
                                    square.ForeColor = Color.Blue;
                                    break;
                                case 2:
                                    square.ForeColor = Color.Green;
                                    break;
                                case 3:
                                    square.ForeColor = Color.Brown;
                                    break;
                                case 4:
                                    square.ForeColor = Color.Red;
                                    break;
                                case 5:
                                    square.ForeColor = Color.Purple;
                                    break;
                                case 6:
                                    square.ForeColor = Color.Violet;
                                    break;
                                case 7:
                                    square.ForeColor = Color.Pink;
                                    break;          
                            }
                            square.Text = m.ToString();
                        }
                    }
                    else
                    {
                        square.Image = Properties.Resources.mine;
                    }
                }
            }
            else
            {
                square.Text = null;
                square.Image = null;
            }
        }

        public void DrawBoard()
        {
            Parallel.ForEach<Tuple<int, int>>(this.index, sq =>
            {
                int i = sq.Item1;
                int j = sq.Item2;
                this.Draw(i, j);
            });
        } 

        public void Start()
        {
            foreach (Tuple<int, int> sq in this.index)
            {
                app.Controls.Add(this.tabs[sq.Item1, sq.Item2]);
            }
        }

        public void Restart()
        {
            this.Reset();
            this.button.Image = Properties.Resources.SmileFace;
            this.DrawBoard();
        }
        public async void GameOver(bool state)
        {
            this.started = false;
            string message;
            string seconds = Math.Round(this.time.TotalSeconds, 0).ToString();
            if (state)
            {
                Score score = new Score() {Username=app.username, Mode=this.difficulty[this.mode], Time=Convert.ToInt32(seconds), Date=DateTime.Now};
                var task = this.SaveScore(score);
                message = "Congratulation, you won after " + seconds + " seconds. Try again?";
                if (this.mode == 2)
                {
                    this.app.control.RewardButton.Visible = true;
                }
                button.Image = Properties.Resources.WinFace;
                DialogResult dialogResult = MessageBox.Show(message, "Game Over", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    await task;
                    this.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    await task;
                    app.Close();
                }
            }
            else
            {
                message = "Too bad, you lost after " + Math.Round(this.time.TotalSeconds,0).ToString() + " seconds . Try again?";
                button.Image = Properties.Resources.LoseFace;
                DialogResult dialogResult = MessageBox.Show(message, "Game Over", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    app.Close();
                }
            } 
        }

        private async Task SaveScore(Score scoreObj)
        {
            await this.collection.InsertOneAsync(scoreObj);
        }

        private void TimeUpdate(object sender, EventArgs e)
        {
            if (started)
            {
                this.time = DateTime.Now - t;
            }
        }

    }
}
