namespace Asteroids
{
    public class Collectable : SpaceObject
    {
        private Vec2D[] model;

        public Collectable(Vec2D position, int radius) : base(position, new Vec2D(0, 0), radius)
        {
            model = new Vec2D[4];
            model[0] = new Vec2D(position.X - (radius/2), position.Y - (radius/2));
            model[1] = new Vec2D(position.X + (radius/2), position.Y - (radius/2));
            model[2] = new Vec2D(position.X + (radius/2), position.Y + (radius/2));
            model[3] = new Vec2D(position.X - (radius/2), position.Y + (radius/2));
        }

        public override void Render(double elaspedTime)
        {
            Utils.FillRectSpaceObject(this, Toolbox.graphics, Toolbox.brush);
        }

        public bool Collision(SpaceShip spaceShip)
        {
            PointF[] ship = Utils.RotateModel(spaceShip.Model, spaceShip.Angle);
            Utils.TranslateModel(ship, spaceShip.Position);


            for (int i=0; i<4; i++)
            {
                if (Utils.Intersects(new Vec2D(ship[0]), new Vec2D(ship[1]), model[i], model[(i+1) % 4]))
                    return true;
                if (Utils.Intersects(new Vec2D(ship[1]), new Vec2D(ship[2]), model[i], model[(i+1) % 4]))
                    return true;
                if (Utils.Intersects(new Vec2D(ship[2]), new Vec2D(ship[0]), model[i], model[(i+1) % 4]))
                    return true;
            }

            return false;
        }
    }
}
