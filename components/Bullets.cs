namespace Asteroids
{
    public class Bullets
    {
        private List<Bullet> bullets;
        int size;
        double speed;

        public Bullets(int size = 5, double speed = 10)
        {
            bullets = new List<Bullet>();
            this.size = size;   
            this.speed = speed;
        }

        public List<Bullet> BulletsList
        {
            get => bullets;
            set => bullets = value;
        }

        public void Add(SpaceShip spaceShip)
        {
            PointF[] transformed = Utils.RotateModel(spaceShip.Model, spaceShip.Angle);
            Utils.TranslateModel(transformed, spaceShip.Position);


            double perLine = Utils.DegreeToRadians(30) / spaceShip.Level;
            double start = spaceShip.Angle + Utils.DegreeToRadians(15);
            double angle = start + (perLine/2);
            for (int i=0; i<spaceShip.Level; i++)
            {
                angle -= perLine;
                Vec2D position = new(transformed[1].X, transformed[1].Y);
                Vec2D velocity = new(speed * Math.Cos(angle), speed * Math.Sin(angle));
                bullets.Add(new Bullet(position, velocity, size));
            }
        }

        public void Render(double elapsedTime)
        {
            List<Bullet> visibleBullets = new();

            foreach (Bullet bullet in bullets)
            {
                if (!bullet.IsVisible())
                    continue;

                visibleBullets.Add(bullet);
                bullet.Render(elapsedTime); 
            }

            bullets = visibleBullets;
        }

        public void Clear()
        {
            bullets.Clear();
        }
    }
}
