namespace Asteroids
{
    public abstract class SpaceObject
    {
        protected Vec2D position;
        protected Vec2D velocity;
        protected int size;

        public SpaceObject(Vec2D position, Vec2D velocity, int size)
        {
            this.position = position;
            this.velocity = velocity;
            this.size = size;   
        }

        public Vec2D Position
        {
            get => position;
            set => position = value;
        }

        public Vec2D Velocity
        {
            get => velocity;
            set => velocity = value;
        }

        public int Size
        {
            get => size;
            set => size = value;
        }

        public void WrapCoordinates(int width, int height)
        {

            if (position.X < 0)
                position.X = width;
            else if (position.X > width)
                position.X = 0;

            if (position.Y < 0)
                position.Y = height;
            else if(position.Y > height)
                position.Y = 0;
        }

        public abstract void Render(double elaspedTime);
    }
}
