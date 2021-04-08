using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class Form2 : Form
    {
        public string username;
        private int bg = 0;
        private MongoClient client;
        private IMongoDatabase database;
        public IMongoCollection<Score> collection;

        public Form2()
        {
            username = "";
            var mongostring = "mongodb+srv://hieule:plh0801@cluster0.n2h9d.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
            client = new MongoClient(mongostring);
            database = client.GetDatabase("minesweeper");
            collection = database.GetCollection<Score>("score");
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, EventArgs e) 
        {
            if (UsernameBox.Text == "")
            {
                MessageBox.Show("Please type in your nickname", "Nickname missing");
            }
            else
            {
                username = UsernameBox.Text.Replace(" ", "");
                if (username == "")
                {
                    MessageBox.Show("Please type in your nickname", "Nickname missing");
                }
                else
                {
                    UsernameBox.ReadOnly = true;
                    if (ExpertMode.Checked)
                    {
                        Form1 NewGame = new Form1(2, this);
                        this.Hide();
                        NewGame.Closed += (s, args) => this.Show();
                        NewGame.Show();
                    }
                    if (NormalMode.Checked)
                    {
                        Form1 NewGame = new Form1(1, this);
                        this.Hide();
                        NewGame.Closed += (s, args) => this.Show();
                        NewGame.Show();
                    }
                    if (EasyMode.Checked)
                    {
                        Form1 NewGame = new Form1(0, this);
                        this.Hide();
                        NewGame.Closed += (s, args) => this.Show();
                        NewGame.Show();
                    }
                }
            }
        }

        private void EasyMode_Click(object sender, EventArgs e)
        {
            if (bg!=0)
            {
                bg = 0;
                this.BackgroundImage = Properties.Resources.megumin1;
            }
            NormalMode.Checked = false;
            ExpertMode.Checked = false;
        }

        private void NormalMode_Click(object sender, EventArgs e)
        {
            if (bg != 1)
            {
                bg = 1;
                this.BackgroundImage = Properties.Resources.megumin2;
            }
            EasyMode.Checked = false;
            ExpertMode.Checked = false;
        }

        private void ExpertMode_Click(object sender, EventArgs e)
        {
            if (bg != 2)
            {
                bg = 2;
                this.BackgroundImage = Properties.Resources.megumin3;
            }
            EasyMode.Checked = false;
            NormalMode.Checked = false;
        }

        private void RewardButton_Click(object sender, EventArgs e)
        {
            Form3 Reward = new Form3();
            this.Hide();
            Reward.Closed += (s, args) => this.Show();
            Reward.Show();
        }

        private async void ShowScore_Click(object sender, EventArgs e)
        {
            if (username == "")
            {
                username = UsernameBox.Text.Replace(" ", "");
            }
            var task = collection.Find(s => s.Username == username).ToListAsync();
            var task2 = collection.Find(s => true).ToListAsync();
            List<Score> ScoreBoard;
            List<Score> ScoreBoardUniversal;
            ScoreBoard = await task;
            ScoreBoard.Sort((a, b) => b.CompareTo(a));
            ScoreBoardUniversal = await task2;
            ScoreBoardUniversal.Sort((a,b) => b.CompareTo(a));
            Form4 Leaderboard = new Form4() { LocalScores = ScoreBoard, UniversalScores = ScoreBoardUniversal};
            this.Hide();
            Leaderboard.Closed += (s, args) => this.Show();
            Leaderboard.Show();
        }
    }
}
