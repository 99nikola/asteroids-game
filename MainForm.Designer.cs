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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlGame = new System.Windows.Forms.Panel();
            this.imgAsteroid = new System.Windows.Forms.PictureBox();
            this.tmrGameUpdate = new System.Windows.Forms.Timer(this.components);
            this.imageListAsteroids = new System.Windows.Forms.ImageList(this.components);
            this.pnlGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgAsteroid)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGame
            // 
            this.pnlGame.BackColor = System.Drawing.Color.Black;
            this.pnlGame.Controls.Add(this.imgAsteroid);
            this.pnlGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGame.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pnlGame.Location = new System.Drawing.Point(0, 0);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(800, 450);
            this.pnlGame.TabIndex = 0;
            // 
            // imgAsteroid
            // 
            this.imgAsteroid.BackColor = System.Drawing.Color.Transparent;
            this.imgAsteroid.BackgroundImage = global::Asteroids.Properties.Resources.asteroid1;
            this.imgAsteroid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgAsteroid.Location = new System.Drawing.Point(232, 174);
            this.imgAsteroid.Name = "imgAsteroid";
            this.imgAsteroid.Size = new System.Drawing.Size(128, 128);
            this.imgAsteroid.TabIndex = 0;
            this.imgAsteroid.TabStop = false;
            this.imgAsteroid.Click += new System.EventHandler(this.imgAsteroid_Click);
            // 
            // tmrGameUpdate
            // 
            this.tmrGameUpdate.Enabled = true;
            this.tmrGameUpdate.Interval = 1;
            // 
            // imageListAsteroids
            // 
            this.imageListAsteroids.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListAsteroids.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListAsteroids.ImageStream")));
            this.imageListAsteroids.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListAsteroids.Images.SetKeyName(0, "asteroid.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlGame);
            this.Name = "MainForm";
            this.Text = "Asteroids";
            this.pnlGame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgAsteroid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlGame;
        private System.Windows.Forms.Timer tmrGameUpdate;
        private PictureBox imgAsteroid;
        private ImageList imageListAsteroids;
    }
}