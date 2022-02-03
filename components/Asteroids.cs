namespace Asteroids
{
    public class Asteroids
    {
        private List<Asteroid> asteroids;

        public Asteroids()
        {
            asteroids = new List<Asteroid>();
        }

        public void Render(double elapsedTime)
        {
            foreach (Asteroid asteroid in asteroids)
            {
                asteroid.Render(elapsedTime);
            }
        }

        public LevelStatus CollisionWithBullets(Bullets bullets)
        {
            List<Asteroid> notCollidedAsteroids = new ();
            List<Bullet> notCollidedBullets = new ();
            LevelStatus levelStatus = new ();

            foreach (Asteroid asteroid in asteroids)
            {
                bool collided = false;

                foreach (Bullet bullet in bullets.BulletsList)
                {
                    if (!asteroid.IsCollidedWithBullet(bullet))
                        continue;

                    bullet.Position.X = -1000;
                    
                    levelStatus.AsteroidsHit += 1;
                    collided = true;

                    if (asteroid.Size != 64)
                        break;

                    double angle1 = Utils.RandomAngle();
                    double angle2 = Utils.RandomAngle();

                    Asteroid child1 = new (
                        new Vec2D(asteroid.Position.X, asteroid.Position.Y),
                        new Vec2D(Math.Cos(angle1), Math.Sin(angle1)),
                        32);
                    notCollidedAsteroids.Add(child1);

                    Asteroid child2 = new (
                        new Vec2D(asteroid.Position.X, asteroid.Position.Y),
                        new Vec2D(Math.Cos(angle2), Math.Sin(angle2)),
                        32);
                    notCollidedAsteroids.Add(child2);

                    break;
                }
                if (!collided)
                    notCollidedAsteroids.Add(asteroid);
            }

            foreach (Bullet bullet in bullets.BulletsList)
            {
                if (bullet.Position.X == -1000)
                    continue;
                notCollidedBullets.Add(bullet);
            }

            bullets.BulletsList = notCollidedBullets;
            asteroids = notCollidedAsteroids;
            levelStatus.Passed = asteroids.Count == 0;
            return levelStatus;
        }

        public bool CollisionWithSpaceShip(SpaceShip spaceShip)
        {
            foreach (Asteroid asteroid in asteroids)
            {
                if (spaceShip.CollisionWithAsteroid(asteroid))
                    return true;
            }

            return false;
        }

        public void Add(Asteroid asteroid)
        {
            asteroids.Add(asteroid);
        }

        public void Clear()
        {
            asteroids.Clear();
        }

        public List<Asteroid> AsteroidsList
        {
            get => asteroids;
            set => asteroids = value;
        }
    }
}
