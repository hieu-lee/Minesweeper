using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{    
    public partial class Form1 : Form
    {
        public string username;
        public int mode;
        public int rows;
        public int cols;
        public int mines;
        public Form2 control;
        public IMongoCollection<Score> collection;
        private GameGrid game;

        public Form1(int mode, Form2 control)
        {
            this.username = control.username;
            this.collection = control.collection;
            this.control = control;
            int n, m;
            n = 0;
            m = 0;
            this.mode = mode;
            switch (this.mode)
            {
                case 0:
                    n = 286;
                    m = 339;
                    this.rows = 9;
                    this.cols = 9;
                    this.mines = 10;
                    break;
                case 1:
                    n = 496;
                    m = 549;
                    this.rows = 16;
                    this.cols = 16;
                    this.mines = 40;
                    break;
                case 2:
                    n = 916;
                    m = 549;
                    this.rows = 30;
                    this.cols = 16;
                    this.mines = 99;
                    break;
            }
            InitializeComponent();
            this.BackColor = Color.Maroon;
            this.Size = new Size(n, m);
            this.MaximumSize = this.Size;
            this.Icon = Properties.Resources.minesweeper_icon;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FlagsCounting box = new FlagsCounting();
            game = new GameGrid(this.rows, this.cols, this, box)
            {
                nflags = mines
            };
            this.Controls.Add(game.button);
            this.Controls.Add(box);
            game.Start();
        }
    }
}

