using System;
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
    public partial class Form4 : Form
    {
        public List<Score> LocalScores { get; set; }
        public List<Score> UniversalScores { get; set; }

        private DataTable tableLocal = new DataTable();
        private DataTable tableUniversal = new DataTable();

        private int mode = 0;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            tableLocal.Columns.Add("Date", typeof(string));
            tableLocal.Columns.Add("Username", typeof(string));
            tableLocal.Columns.Add("Mode", typeof(string));
            tableLocal.Columns.Add("Seconds", typeof(int));
            for (int i = 0; i < LocalScores.Count; i++)
            {
                Score s = LocalScores[i];
                tableLocal.Rows.Add(s.Date.ToString(), s.Username, s.Mode, s.Time);
            }

            tableUniversal.Columns.Add("Date", typeof(string));
            tableUniversal.Columns.Add("Username", typeof(string));
            tableUniversal.Columns.Add("Mode", typeof(string));
            tableUniversal.Columns.Add("Seconds", typeof(int));
            for (int i = 0; i < UniversalScores.Count; i++)
            {
                Score s = UniversalScores[i];
                tableUniversal.Rows.Add(s.Date.ToString(), s.Username, s.Mode, s.Time);
            }

            ScoreBoard.DataSource = tableLocal;
        }

        private void UniversalButton_Click(object sender, EventArgs e)
        {
            if (mode == 0) 
            {
                mode = 1;
                ScoreBoard.DataSource = tableUniversal;
            }
        }

        private void LocalButton_Click(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                mode = 0;
                ScoreBoard.DataSource = tableLocal;
            }
        }
    }
}
