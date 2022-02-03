using System.Diagnostics;

namespace Asteroids
{
    public class Game
    {
        readonly Asteroids asteroids;
        readonly Bullets bullets;
        readonly SpaceShip spaceShip;
        readonly Collectables collectables;
        readonly Levels levels;

        bool gameOver;
        int score;
        bool left, right, up;

        public Game()
        {
            spaceShip = new SpaceShip();
            asteroids = new Asteroids();
            collectables = new Collectables();
            bullets = new Bullets();
            levels = new Levels(this);

            score = 0;
            left = right = up = false;
            gameOver = false;
            levels.StartLevel();
        }

        public void OnGameUpdate(object? sender, EventArgs e)
        {
            ShipMovement();
            Logic();
            Render();
        }

        private void ShipMovement()
        {
            if (left)
                spaceShip.SteerLeft();
            if (right)
                spaceShip.SteerRight();
            if (up)
                spaceShip.ApplyThrust();
        }

        public void Input(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    left = true;
                    break;
                case Keys.Right:
                    right = true;
                    break;
                case Keys.Up:
                    up = true;
                    break;
            }
        }

        public void ReleaseInput(object? sneder, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    left = false;
                    break;
                case Keys.Right:
                    right = false;
                    break;
                case Keys.Up:
                    up = false;
                    break;

                case Keys.Space:
                    bullets.Add(spaceShip);
                    break;
            }
        }

        private void Logic()
        {
            if (collectables.Collision(spaceShip))
            {
                spaceShip.Upgrade();
                Toolbox.lblShipLevel.Text = spaceShip.Level.ToString();
            }

            LevelStatus levelStatus = asteroids.CollisionWithBullets(bullets);
            score += levelStatus.AsteroidsHit;
            Toolbox.lblScore.Text = score.ToString();

            if (levelStatus.Passed)
            {
                Pause();
                if (levels.IsLastLevel())
                {
                    Toolbox.btnPlayAgain.Enabled = true;
                    Toolbox.pnlYouWon.Visible = true;
                    return;
                }
                Toolbox.btnNextLevel.Enabled = true;
                Toolbox.pnlNextLevel.Visible = true;
                return;
            }

            gameOver = asteroids.CollisionWithSpaceShip(spaceShip);
            if (gameOver)
            {
                Pause();
                Toolbox.btnTryAgain.Enabled = true;
                Toolbox.pnlGameOver.Visible = true;
                return;
            }
        }

        private void Render()
        {
            Toolbox.graphics.Clear(Color.Black);
            //Toolbox.stopwatch.Stop();
            double elaspedTime = 1.0f;      //Toolbox.stopwatch.ElapsedMilliseconds / 1000.0f;

            spaceShip.Render(elaspedTime);
            asteroids.Render(elaspedTime);
            bullets.Render(elaspedTime);
            collectables.Render(elaspedTime);
            Toolbox.pnlGame.Refresh();
            //Toolbox.stopwatch.Start();
        }

        public void Reset()
        {
            levels.PlayAgain();
            spaceShip.Level = 1;
            gameOver = false;
            Resume();
        }

        public void NextLevel()
        {
            levels.NextLevel();
            Resume();
        }

        public void Pause()
        {
            Toolbox.tmrGameUpdate.Stop();
        }

        public void Resume()
        {
            Toolbox.tmrGameUpdate.Start();
            //Toolbox.stopwatch.Reset();
        }

        public SpaceShip SpaceShip
        {
            get => spaceShip;
        }

        public List<Asteroid> Asteroids
        {
            get => asteroids.AsteroidsList;
            set => asteroids.AsteroidsList = value;
        }

        public List<Bullet> Bullets
        {
            get => bullets.BulletsList;
            set => bullets.BulletsList = value;
        }

        public int Score
        {
            get => score;
            set => score = value;
        }

        public Collectables Collectables
        {
            get=> collectables;
        }
    }
}
