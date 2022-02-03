namespace Asteroids
{
    public class Vec2D
    {
        private double x;
        private double y;
        public Vec2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double X
        {
            get => x;
            set => x = value;
        }
        public double Y
        {
            get => y;
            set => y = value;
        }

        public Vec2D (PointF point)
        {
            x = point.X;
            y = point.Y;   
        }

        public Vec2D Add(Vec2D other)
        {
            return new Vec2D(X + other.X, Y + other.Y);
        }

        public Vec2D Sub(Vec2D other)
        {
            return new Vec2D(X - other.X, Y - other.Y);
        }

        public Vec2D Mult(double scalar)
        {
            return new Vec2D(X * scalar, Y * scalar);
        }
    }
}
