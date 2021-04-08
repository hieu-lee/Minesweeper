namespace WindowsFormsApp13
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EasyMode = new System.Windows.Forms.CheckBox();
            this.NormalMode = new System.Windows.Forms.CheckBox();
            this.ExpertMode = new System.Windows.Forms.CheckBox();
            this.PlayButton = new System.Windows.Forms.Button();
            this.RewardButton = new System.Windows.Forms.Button();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.ShowScore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EasyMode
            // 
            this.EasyMode.AutoSize = true;
            this.EasyMode.BackColor = System.Drawing.Color.Transparent;
            this.EasyMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyMode.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.EasyMode.Location = new System.Drawing.Point(133, 377);
            this.EasyMode.Name = "EasyMode";
            this.EasyMode.Size = new System.Drawing.Size(49, 19);
            this.EasyMode.TabIndex = 0;
            this.EasyMode.Text = "Easy";
            this.EasyMode.UseVisualStyleBackColor = false;
            this.EasyMode.Click += new System.EventHandler(this.EasyMode_Click);
            // 
            // NormalMode
            // 
            this.NormalMode.AutoSize = true;
            this.NormalMode.BackColor = System.Drawing.Color.Transparent;
            this.NormalMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NormalMode.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.NormalMode.Location = new System.Drawing.Point(133, 396);
            this.NormalMode.Name = "NormalMode";
            this.NormalMode.Size = new System.Drawing.Size(66, 19);
            this.NormalMode.TabIndex = 1;
            this.NormalMode.Text = "Normal";
            this.NormalMode.UseVisualStyleBackColor = false;
            this.NormalMode.Click += new System.EventHandler(this.NormalMode_Click);
            // 
            // ExpertMode
            // 
            this.ExpertMode.AutoSize = true;
            this.ExpertMode.BackColor = System.Drawing.Color.Transparent;
            this.ExpertMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpertMode.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ExpertMode.Location = new System.Drawing.Point(133, 419);
            this.ExpertMode.Name = "ExpertMode";
            this.ExpertMode.Size = new System.Drawing.Size(59, 19);
            this.ExpertMode.TabIndex = 2;
            this.ExpertMode.Text = "Expert";
            this.ExpertMode.UseVisualStyleBackColor = false;
            this.ExpertMode.Click += new System.EventHandler(this.ExpertMode_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.DarkRed;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.PlayButton.Location = new System.Drawing.Point(198, 390);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 30);
            this.PlayButton.TabIndex = 3;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // RewardButton
            // 
            this.RewardButton.BackColor = System.Drawing.Color.DarkRed;
            this.RewardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RewardButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RewardButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.RewardButton.Location = new System.Drawing.Point(282, 390);
            this.RewardButton.Name = "RewardButton";
            this.RewardButton.Size = new System.Drawing.Size(75, 30);
            this.RewardButton.TabIndex = 4;
            this.RewardButton.Text = "Reward";
            this.RewardButton.UseVisualStyleBackColor = false;
            this.RewardButton.Visible = false;
            this.RewardButton.Click += new System.EventHandler(this.RewardButton_Click);
            // 
            // UsernameBox
            // 
            this.UsernameBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UsernameBox.Location = new System.Drawing.Point(191, 351);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(159, 23);
            this.UsernameBox.TabIndex = 5;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.Color.DarkRed;
            this.UsernameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.UsernameLabel.Location = new System.Drawing.Point(128, 354);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(61, 15);
            this.UsernameLabel.TabIndex = 6;
            this.UsernameLabel.Text = "Nickname";
            // 
            // ShowScore
            // 
            this.ShowScore.BackColor = System.Drawing.Color.DarkRed;
            this.ShowScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowScore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowScore.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ShowScore.Location = new System.Drawing.Point(356, 351);
            this.ShowScore.Name = "ShowScore";
            this.ShowScore.Size = new System.Drawing.Size(91, 23);
            this.ShowScore.TabIndex = 7;
            this.ShowScore.Text = "Leaderboard";
            this.ShowScore.UseVisualStyleBackColor = false;
            this.ShowScore.Click += new System.EventHandler(this.ShowScore_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp13.Properties.Resources.megumin1;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.ShowScore);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.RewardButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.ExpertMode);
            this.Controls.Add(this.NormalMode);
            this.Controls.Add(this.EasyMode);
            this.Icon = global::WindowsFormsApp13.Properties.Resources.minesweeper_icon;
            this.MaximumSize = this.Size;
            this.Name = "Form2";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox EasyMode;
        private System.Windows.Forms.CheckBox NormalMode;
        private System.Windows.Forms.CheckBox ExpertMode;
        private System.Windows.Forms.Button PlayButton;
        public System.Windows.Forms.Button RewardButton;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button ShowScore;
    }
}