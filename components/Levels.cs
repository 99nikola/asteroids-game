using System.Diagnostics;
namespace Asteroids
{
    public class Levels
    {
        Game game;
        int level;
        int MAX_LEVEL = 5;

        public Levels(Game game)
        {
            this.game = game;
            level = 1;
        }

        public int Level
        {
            get => level;
            set => level = value;
        }

        public void StartLevel()
        {
            Clear();
            switch (level)
            {
                case 1:
                    FirstLevel();
                    break;
                case 2:
                    SecondLevel();
                    break;
                case 3:
                    ThirdLevel();
                    break;
                case 4:
                    FourthLevel();
                    break;
                case 5:
                    FifthLevel();
                    break;
            }
        }

        public void Clear()
        {
            game.SpaceShip.ResetToMiddle();
            game.Asteroids.Clear();
            game.Bullets.Clear();
            game.Collectables.Clear();
        }

        public void PlayAgain()
        {
            level = 1;
            Toolbox.lblLevel.Text = "1";
            Toolbox.lblScore.Text = "0";
            Toolbox.lblLevel.Text = "1";
            Toolbox.lblShipLevel.Text = "1";
            StartLevel();
        }

        public void NextLevel()
        {
            if (level == MAX_LEVEL)
                return;

            level++;
            Toolbox.lblLevel.Text = level.ToString();
            StartLevel();
        }

        public void PrevLevel()
        {
            if (level == 1)
                return;

            level--;
            Toolbox.lblLevel.Text = level.ToString();
            StartLevel();
        }

        public bool IsLastLevel()
        {
            return level == MAX_LEVEL;
        }

        private void FirstLevel()
        {
            game.Score = 0;
            game.Asteroids.Add(new Asteroid(new Vec2D(128, 128)));
            game.Collectables.SpawnCollectable();
        }

        private void SecondLevel()
        {
            game.Asteroids.Add(new Asteroid(new Vec2D(64, Toolbox.pnlGame.Height - 64), new Vec2D(0.5, -0.5), 64));
            game.Asteroids.Add(new Asteroid(new Vec2D(Toolbox.pnlGame.Width - 32, 32), new Vec2D(-0.5, 0.5), 32));
            game.Collectables.SpawnCollectable();
        }

        private void ThirdLevel()
        {
            game.Asteroids.Add(new Asteroid(new Vec2D(64, Toolbox.pnlGame.Height - 64), new Vec2D(0.5, -0.5), 64));
            game.Asteroids.Add(new Asteroid(new Vec2D(Toolbox.pnlGame.Width - 64, 64), new Vec2D(-0.5, 0.5), 64));
            game.Asteroids.Add(new Asteroid(new Vec2D(32, 32), new Vec2D(0.5, 0.5), 32));
            game.Asteroids.Add(new Asteroid(new Vec2D(Toolbox.pnlGame.Width - 32, Toolbox.pnlGame.Height - 32), new Vec2D(-0.5, -0.5), 32));
            game.Collectables.SpawnCollectable();
        }

        private void FourthLevel()
        {
            for (int i = 0; i<Toolbox.pnlGame.Height/200; i++)
                game.Asteroids.Add(new Asteroid(new Vec2D(64, 64 + i*256), new Vec2D(0.4, 0), 64));

            game.Collectables.SpawnCollectable();
        }

        private void FifthLevel()
        {
            for (int i=0; i<Toolbox.pnlGame.Width/200; i++)
                game.Asteroids.Add(new Asteroid(new Vec2D(64 + i*256, 64), new Vec2D(0, 0.4), 64));

            game.Collectables.SpawnCollectable();
        }
    }
}
