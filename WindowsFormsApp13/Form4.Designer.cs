
namespace WindowsFormsApp13
{
    partial class Form4
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
            this.ScoreBoard = new System.Windows.Forms.DataGridView();
            this.UniversalButton = new System.Windows.Forms.Button();
            this.LocalButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // ScoreBoard
            // 
            this.ScoreBoard.AllowUserToAddRows = false;
            this.ScoreBoard.AllowUserToDeleteRows = false;
            this.ScoreBoard.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ScoreBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScoreBoard.Location = new System.Drawing.Point(12, 12);
            this.ScoreBoard.Name = "ScoreBoard";
            this.ScoreBoard.ReadOnly = true;
            this.ScoreBoard.Size = new System.Drawing.Size(440, 426);
            this.ScoreBoard.TabIndex = 0;
            // 
            // UniversalButton
            // 
            this.UniversalButton.BackColor = System.Drawing.Color.Transparent;
            this.UniversalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UniversalButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UniversalButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.UniversalButton.Location = new System.Drawing.Point(458, 12);
            this.UniversalButton.Name = "UniversalButton";
            this.UniversalButton.Size = new System.Drawing.Size(152, 23);
            this.UniversalButton.TabIndex = 1;
            this.UniversalButton.Text = "Universal";
            this.UniversalButton.UseVisualStyleBackColor = false;
            this.UniversalButton.Click += new System.EventHandler(this.UniversalButton_Click);
            // 
            // LocalButton
            // 
            this.LocalButton.BackColor = System.Drawing.Color.Transparent;
            this.LocalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LocalButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LocalButton.Location = new System.Drawing.Point(458, 41);
            this.LocalButton.Name = "LocalButton";
            this.LocalButton.Size = new System.Drawing.Size(152, 23);
            this.LocalButton.TabIndex = 2;
            this.LocalButton.Text = "Local";
            this.LocalButton.UseVisualStyleBackColor = false;
            this.LocalButton.Click += new System.EventHandler(this.LocalButton_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(615, 450);
            this.Controls.Add(this.LocalButton);
            this.Controls.Add(this.UniversalButton);
            this.Controls.Add(this.ScoreBoard);
            this.Icon = global::WindowsFormsApp13.Properties.Resources.minesweeper_icon;
            this.Name = "Form4";
            this.Text = "Leaderboard";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScoreBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView ScoreBoard;
        private System.Windows.Forms.Button UniversalButton;
        private System.Windows.Forms.Button LocalButton;
    }
}