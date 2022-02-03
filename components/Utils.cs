namespace Asteroids
{
    class Utils
    {
        private static Random randomInstance;

        public static Random GetRandomInstance()
        {
            if (randomInstance != null)
                return randomInstance;

            return new Random();
        }

        public static double DegreeToRadians(double degree)
        {
            return degree * (Math.PI / 180);
        }

        public static void DrawCircleSpaceObject(SpaceObject spaceObject, Graphics graphics, Pen pen)
        {
            graphics.DrawEllipse(pen, (float)spaceObject.Position.X - spaceObject.Size, (float)spaceObject.Position.Y - spaceObject.Size, 2 * spaceObject.Size, 2 *spaceObject.Size);
        }

        public static void FillCircleSpaceObject(SpaceObject spaceObject, Graphics graphics, Brush brush)
        {
            graphics.FillEllipse(brush, (float)spaceObject.Position.X - spaceObject.Size, (float)spaceObject.Position.Y - spaceObject.Size, 2 * spaceObject.Size, 2 *spaceObject.Size);
        }
        
        public static void FillRectSpaceObject(SpaceObject spaceObject, Graphics graphics, Brush brush)
        {
            graphics.FillRectangle(brush, (float)spaceObject.Position.X - (spaceObject.Size/2), (float)spaceObject.Position.Y - (spaceObject.Size/2), spaceObject.Size, spaceObject.Size);
        }

        public static double RandomAngle()
        {
            Random random = GetRandomInstance();
            return random.NextDouble() * Math.PI * 2;
        }

        public static PointF[] RotateModel(PointF[] model, double angle)
        {
            PointF[] transformed = new PointF[model.Length];
            for (int i=0; i<model.Length; i++)
                transformed[i] = new PointF(model[i].X, model[i].Y);

            for (int i = 0; i<model.Length; i++)
            {
                transformed[i].X = model[i].X * (float)Math.Cos(angle) - model[i].Y * (float)Math.Sin(angle);
                transformed[i].Y = model[i].X * (float)Math.Sin(angle) + model[i].Y * (float)Math.Cos(angle);
            }

            return transformed;
        }

        public static void ScaleModel(PointF[] model, float scale)
        {
            for (int i = 0; i<model.Length; i++)
            {
                model[i].X = model[i].X * scale;
                model[i].Y = model[i].Y * scale;
            }
        }

        public static void TranslateModel(PointF[] model, Vec2D pos)
        {
            for (int i = 0; i<model.Length; i++)
            {
                model[i].X = (float)(model[i].X + pos.X);
                model[i].Y = (float)(model[i].Y + pos.Y);
            }
        }

        public static void FillPolygonModel(Graphics graphics, Brush brush, PointF[] modelCoordinates, Vec2D pos, double rotate = 0.0f, float scale = 1.0f)
        {
            
            PointF[] transformedCoordinates = RotateModel(modelCoordinates, rotate);
            ScaleModel(transformedCoordinates, scale);
            TranslateModel(transformedCoordinates, pos);

            graphics.FillPolygon(brush, transformedCoordinates);
        }

        // a1 is line1 start, a2 is line1 end, b1 is line2 start, b2 is line2 end
        public static bool Intersects(Vec2D a1, Vec2D a2, Vec2D b1, Vec2D b2)
        {
            Vec2D b = a2.Sub(a1);
            Vec2D d = b2.Sub(b1);
            double bDotDPerp = b.X * d.Y - b.Y * d.X;

            // if b dot d == 0, it means the lines are parallel so have infinite intersection points
            if (bDotDPerp == 0)
                return false;

            Vec2D c = b1.Sub(a1);
            double t = (c.X * d.Y - c.Y * d.X) / bDotDPerp;
            if (t < 0 || t > 1)
                return false;

            double u = (c.X * b.Y - c.Y * b.X) / bDotDPerp;
            if (u < 0 || u > 1)
                return false;

            return true;
        }
    }
}
