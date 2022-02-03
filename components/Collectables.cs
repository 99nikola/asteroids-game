namespace Asteroids
{
    public class Collectables
    {
        List<Collectable> collectables;
        static Random random = new();
        static int radius = 20;

        public Collectables()
        {
            collectables = new List<Collectable>();
        }

        public void SpawnCollectable()
        {
            Vec2D position = new(random.NextDouble() * (Toolbox.pnlGame.Width-4*radius), random.NextDouble() * (Toolbox.pnlGame.Height - 4*radius));
            collectables.Add(new Collectable(position, radius));
        }


        public bool Collision(SpaceShip spaceShip)
        {
            bool collided = false;

            foreach (Collectable collectable in collectables)
            {
                if (collectable.Collision(spaceShip))
                {
                    collectable.Position.X = -1000;
                    collided = true;
                    break;
                }
            }

            List<Collectable> notCollided = new();
            foreach (Collectable collectable in collectables)
            {
                if (collectable.Position.X == -1000)
                    continue;
                notCollided.Add(collectable);
            }

            if (collided)
                collectables = notCollided;
            return collided;
        }

        public void Render(double elaspedTime)
        {
            foreach(Collectable collectable in collectables)
            {
                collectable.Render(elaspedTime);
            }
        }

        public void Clear()
        {
            collectables.Clear();
        }
    }
}
