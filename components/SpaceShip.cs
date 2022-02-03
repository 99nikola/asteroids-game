namespace Asteroids
{
    public class SpaceShip : SpaceObject
    {
        private double angle;
        readonly private double SPEED_LIMIT = 3;
        readonly private double ACCELERATION = 0.25;
        readonly private double STEER_SPEED = 0.07;
        readonly private PointF[] model =
            {
                new PointF(-22.361f, 20),
                new PointF(30, 0),
                new PointF(-22.361f, -20)
            };
        private int level = 1;
        readonly private int LEVEL_MAX = 4;

        public SpaceShip(Vec2D position, Vec2D velocity, double angle, int size) : base(position, velocity, size)
        {
            this.angle = angle;
        }

        public SpaceShip() : base (new Vec2D(0, 0), new Vec2D(0, 0), 30)
        {
        }

        public double Angle
        {
            get => angle;
            set => angle = value;   
        }

        public override void Render(double elapsedTime)
        {
            position.X += velocity.X * elapsedTime;
            position.Y += velocity.Y * elapsedTime;   
            WrapCoordinates(Toolbox.pnlGame.Width, Toolbox.pnlGame.Height);
            Utils.FillPolygonModel(Toolbox.graphics, Toolbox.brush, model, position, angle);
        }

        public void SteerLeft()
        {
            angle -= STEER_SPEED;
        }

        public void SteerRight()
        {
            angle += STEER_SPEED;
        }

        public void ApplyThrust()
        {
            velocity.X += Math.Cos(angle) * ACCELERATION;
            velocity.Y += Math.Sin(angle) * ACCELERATION;


            CheckLimitSpeed();
        }

        public void Upgrade()
        {
            if (level == LEVEL_MAX)
                return;

            level++;
        }

        public int Level
        {
            get => level;
            set => level = value;
        }
        

        public void CheckLimitSpeed()
        {
            if (velocity.X > SPEED_LIMIT)
                velocity.X = SPEED_LIMIT;
            else if (velocity.X < -SPEED_LIMIT)
                velocity.X = -SPEED_LIMIT;

            if (velocity.Y > SPEED_LIMIT)
                velocity.Y = SPEED_LIMIT;
            else if (velocity.Y < -SPEED_LIMIT)
                velocity.Y = -SPEED_LIMIT;
        }

        public bool CollisionWithAsteroid(Asteroid asteroid)
        {
            Vec2D[] centerToVertex = new Vec2D[3];
            double[] cvSquared = new double[3];
            Vec2D[] edges = new Vec2D[3];
            double sizeSquared = asteroid.Size * asteroid.Size;

            PointF[] vertices = Utils.RotateModel(model, angle);
            Utils.TranslateModel(vertices, position);

            for (int i = 0; i<3; i++)
            {
                centerToVertex[i] = new Vec2D(asteroid.Position.X - vertices[i].X, asteroid.Position.Y - vertices[i].Y);
                cvSquared[i] = centerToVertex[i].X * centerToVertex[i].X + centerToVertex[i].Y * centerToVertex[i].Y;

                if (cvSquared[i] <= sizeSquared)
                    return true;
            }
            
            for (int i=0; i<3; i++)
                edges[i] = new Vec2D(vertices[(i+1) % 3].X - vertices[i].X, vertices[(i+1) % 3].Y - vertices[i].Y);


            bool[] checks = new bool[3];
            for (int i = 0; i<3; i++)
                checks[i] = (edges[i].Y * centerToVertex[i].X - edges[i].X * centerToVertex[i].Y) >= 0;

            if (checks[0] && checks[1] && checks[2])
                return true;


            for (int i=0; i<3; i++)
            {
                double k = centerToVertex[i].X * edges[i].X + centerToVertex[i].Y * edges[i].Y;
                if (k > 0)
                {
                    double lenSquared = edges[i].X * edges[i].X + edges[i].Y * edges[i].Y;

                    k = k*k / lenSquared;

                    if (k < lenSquared)
                    {
                        if (cvSquared[i] - k <= sizeSquared)
                            return true;
                    }
                }
            }

            return false;
        }

        public void ResetToMiddle()
        {
            position.X = Toolbox.pnlGame.Width / 2;
            position.Y = Toolbox.pnlGame.Height / 2;
            angle = Utils.DegreeToRadians(-90);
            velocity.X = 0;
            velocity.Y = 0;
        }

        public PointF[] Model
        {
            get => model;
        }
    }   
}
