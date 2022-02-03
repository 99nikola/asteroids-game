
namespace Asteroids
{
    public class Bullet : SpaceObject
    {
        public Bullet(Vec2D position, Vec2D velocity, int size) : base(position, velocity, size)
        {
        }

        public override void Render(double elaspedTime)
        {
            position.X += velocity.X * elaspedTime;
            position.Y += velocity.Y * elaspedTime;
            Utils.FillCircleSpaceObject(this, Toolbox.graphics, Toolbox.brush);
        }

        public bool IsVisible()
        {
            if (position.X < 0 || position.Y < 0 || position.X > Toolbox.pnlGame.Width || position.Y > Toolbox.pnlGame.Height)
                return false;
            return true;
        }
    }
}
