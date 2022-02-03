namespace Asteroids
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.pnlYouWon = new System.Windows.Forms.Panel();
            this.lblYouWon = new System.Windows.Forms.Label();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.pnlNextLevel = new System.Windows.Forms.Panel();
            this.lblLevelPassed = new System.Windows.Forms.Label();
            this.btnNextLevel = new System.Windows.Forms.Button();
            this.pnlGameStatus = new System.Windows.Forms.Panel();
            this.btnTryAgain = new System.Windows.Forms.Button();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.lblScoreLabel = new System.Windows.Forms.Label();
            this.tmrGameUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLevelLabel = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblShipLevelLabel = new System.Windows.Forms.Label();
            this.lblShipLevel = new System.Windows.Forms.Label();
            this.pnlGame.SuspendLayout();
            this.pnlYouWon.SuspendLayout();
            this.pnlNextLevel.SuspendLayout();
            this.pnlGameStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGame
            // 
            this.pnlGame.AllowDrop = true;
            this.pnlGame.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlGame.BackColor = System.Drawing.Color.Black;
            this.pnlGame.Controls.Add(this.pnlYouWon);
            this.pnlGame.Controls.Add(this.pnlNextLevel);
            this.pnlGame.Controls.Add(this.pnlGameStatus);
            this.pnlGame.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pnlGame.Location = new System.Drawing.Point(0, 57);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(1179, 695);
            this.pnlGame.TabIndex = 0;
            // 
            // pnlYouWon
            // 
            this.pnlYouWon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnlYouWon.Controls.Add(this.lblYouWon);
            this.pnlYouWon.Controls.Add(this.btnPlayAgain);
            this.pnlYouWon.Location = new System.Drawing.Point(424, 200);
            this.pnlYouWon.Name = "pnlYouWon";
            this.pnlYouWon.Size = new System.Drawing.Size(212, 167);
            this.pnlYouWon.TabIndex = 4;
            this.pnlYouWon.Visible = false;
            // 
            // lblYouWon
            // 
            this.lblYouWon.AutoSize = true;
            this.lblYouWon.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblYouWon.Location = new System.Drawing.Point(36, 21);
            this.lblYouWon.Name = "lblYouWon";
            this.lblYouWon.Size = new System.Drawing.Size(137, 41);
            this.lblYouWon.TabIndex = 1;
            this.lblYouWon.Text = "You Won";
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPlayAgain.ForeColor = System.Drawing.Color.Black;
            this.btnPlayAgain.Location = new System.Drawing.Point(24, 82);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(167, 59);
            this.btnPlayAgain.TabIndex = 0;
            this.btnPlayAgain.Text = "Play Again";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            // 
            // pnlNextLevel
            // 
            this.pnlNextLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnlNextLevel.Controls.Add(this.lblLevelPassed);
            this.pnlNextLevel.Controls.Add(this.btnNextLevel);
            this.pnlNextLevel.Location = new System.Drawing.Point(430, 197);
            this.pnlNextLevel.Name = "pnlNextLevel";
            this.pnlNextLevel.Size = new System.Drawing.Size(231, 167);
            this.pnlNextLevel.TabIndex = 3;
            this.pnlNextLevel.Visible = false;
            // 
            // lblLevelPassed
            // 
            this.lblLevelPassed.AutoSize = true;
            this.lblLevelPassed.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLevelPassed.Location = new System.Drawing.Point(22, 26);
            this.lblLevelPassed.Name = "lblLevelPassed";
            this.lblLevelPassed.Size = new System.Drawing.Size(193, 41);
            this.lblLevelPassed.TabIndex = 1;
            this.lblLevelPassed.Text = "Level Passed!";
            // 
            // btnNextLevel
            // 
            this.btnNextLevel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNextLevel.ForeColor = System.Drawing.Color.Black;
            this.btnNextLevel.Location = new System.Drawing.Point(32, 82);
            this.btnNextLevel.Name = "btnNextLevel";
            this.btnNextLevel.Size = new System.Drawing.Size(167, 59);
            this.btnNextLevel.TabIndex = 0;
            this.btnNextLevel.Text = "Next Level";
            this.btnNextLevel.UseVisualStyleBackColor = true;
            // 
            // pnlGameStatus
            // 
            this.pnlGameStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnlGameStatus.Controls.Add(this.btnTryAgain);
            this.pnlGameStatus.Controls.Add(this.lblGameOver);
            this.pnlGameStatus.Location = new System.Drawing.Point(411, 208);
            this.pnlGameStatus.Name = "pnlGameStatus";
            this.pnlGameStatus.Size = new System.Drawing.Size(250, 167);
            this.pnlGameStatus.TabIndex = 2;
            this.pnlGameStatus.Visible = false;
            // 
            // btnTryAgain
            // 
            this.btnTryAgain.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTryAgain.ForeColor = System.Drawing.Color.Black;
            this.btnTryAgain.Location = new System.Drawing.Point(13, 82);
            this.btnTryAgain.Name = "btnTryAgain";
            this.btnTryAgain.Size = new System.Drawing.Size(221, 67);
            this.btnTryAgain.TabIndex = 1;
            this.btnTryAgain.Text = "Try Again";
            this.btnTryAgain.UseVisualStyleBackColor = true;
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGameOver.Location = new System.Drawing.Point(13, 16);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(220, 54);
            this.lblGameOver.TabIndex = 0;
            this.lblGameOver.Text = "Game Over";
            // 
            // lblScoreLabel
            // 
            this.lblScoreLabel.AutoSize = true;
            this.lblScoreLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblScoreLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScoreLabel.Location = new System.Drawing.Point(12, 9);
            this.lblScoreLabel.Name = "lblScoreLabel";
            this.lblScoreLabel.Size = new System.Drawing.Size(99, 41);
            this.lblScoreLabel.TabIndex = 1;
            this.lblScoreLabel.Text = "Score:";
            // 
            // tmrGameUpdate
            // 
            this.tmrGameUpdate.Enabled = true;
            this.tmrGameUpdate.Interval = 1;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScore.Location = new System.Drawing.Point(104, 4);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(42, 50);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "0";
            // 
            // lblLevelLabel
            // 
            this.lblLevelLabel.AutoSize = true;
            this.lblLevelLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLevelLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLevelLabel.Location = new System.Drawing.Point(904, 9);
            this.lblLevelLabel.Name = "lblLevelLabel";
            this.lblLevelLabel.Size = new System.Drawing.Size(92, 41);
            this.lblLevelLabel.TabIndex = 3;
            this.lblLevelLabel.Text = "Level:";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLevel.Location = new System.Drawing.Point(993, 4);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(42, 50);
            this.lblLevel.TabIndex = 4;
            this.lblLevel.Text = "1";
            // 
            // lblShipLevelLabel
            // 
            this.lblShipLevelLabel.AutoSize = true;
            this.lblShipLevelLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShipLevelLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblShipLevelLabel.Location = new System.Drawing.Point(424, 11);
            this.lblShipLevelLabel.Name = "lblShipLevelLabel";
            this.lblShipLevelLabel.Size = new System.Drawing.Size(158, 41);
            this.lblShipLevelLabel.TabIndex = 5;
            this.lblShipLevelLabel.Text = "Ship Level:";
            // 
            // lblShipLevel
            // 
            this.lblShipLevel.AutoSize = true;
            this.lblShipLevel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblShipLevel.Location = new System.Drawing.Point(573, 4);
            this.lblShipLevel.Name = "lblShipLevel";
            this.lblShipLevel.Size = new System.Drawing.Size(42, 50);
            this.lblShipLevel.TabIndex = 6;
            this.lblShipLevel.Text = "1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.lblShipLevel);
            this.Controls.Add(this.lblShipLevelLabel);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblLevelLabel);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblScoreLabel);
            this.Controls.Add(this.pnlGame);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asteroids";
            this.pnlGame.ResumeLayout(false);
            this.pnlYouWon.ResumeLayout(false);
            this.pnlYouWon.PerformLayout();
            this.pnlNextLevel.ResumeLayout(false);
            this.pnlNextLevel.PerformLayout();
            this.pnlGameStatus.ResumeLayout(false);
            this.pnlGameStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlGame;
        private System.Windows.Forms.Timer tmrGameUpdate;
        private Label lblScoreLabel;
        private Label lblScore;
        private Label lblGameOver;
        private Button btnTryAgain;
        private Panel pnlGameStatus;
        private Label lblLevelLabel;
        private Label lblLevel;
        private Panel pnlNextLevel;
        private Label lblLevelPassed;
        private Button btnNextLevel;
        private Panel pnlYouWon;
        private Label lblYouWon;
        private Button btnPlayAgain;
        private Label lblShipLevelLabel;
        private Label lblShipLevel;
    }
}