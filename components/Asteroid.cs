namespace Asteroids
{
    public class Asteroid : SpaceObject
    {

        readonly private static double intensity = 5.0f;
        readonly private static int radius = 64;

        public Asteroid(Vec2D position) : base (position, new Vec2D(0.5 * intensity, -0.1 * intensity), radius)
        {
        }

        public Asteroid(Vec2D position, Vec2D velocity, int radius) : base(position, new Vec2D(velocity.X * intensity, velocity.Y * intensity), radius)
        {
        }

        public override void Render(double elapsedTime)
        {
            position.X += velocity.X * elapsedTime;
            position.Y += velocity.Y * elapsedTime;
            WrapCoordinates(Toolbox.pnlGame.Width, Toolbox.pnlGame.Height);
            Utils.DrawCircleSpaceObject(this, Toolbox.graphics, Toolbox.pen);
        }

        public bool IsCollidedWithBullet(Bullet bullet)
        {
            double x = position.X - bullet.Position.X;
            double y = position.Y - bullet.Position.Y; 

            double distancePow2 = x*x + y*y;
            double radiusPow2 = (size + bullet.Size) * (size + bullet.Size);

            return distancePow2 <= radiusPow2;
        }
    }
}
