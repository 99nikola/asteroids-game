using System.Diagnostics;

namespace Asteroids
{
    public partial class MainForm : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        Random random;

        Stopwatch timer;
        List<SpaceObject> asteroids;
        List<SpaceObject> bullets; 
        SpaceObject player;
        Brush brush;
        bool gameOver;
        Point imgAsteroidLocation;

        PointF[] shipModel =
        {
            new PointF(0.0f, -20.0f),
            new PointF(-15.0f, 20.0f),
            new PointF(15.0f, 20.0f),
        };
        PointF[] asteroidModel;


        public MainForm()
        {
            InitializeComponent();
            bitmap = new Bitmap(pnlGame.Width, pnlGame.Height); ;
            pnlGame.BackgroundImage = bitmap;
            graphics = Graphics.FromImage(bitmap);

            brush = new SolidBrush(Color.White);
            random = new Random(); 
            imgAsteroidLocation = imgAsteroid.Location;

            OnGameStart();
        }

        private void OnGameStart()
        {
            gameOver = false;

            int asteroidVertices = 20;
            asteroidModel = new PointF[asteroidVertices];
            for (int i=0; i<asteroidVertices; i++)
            {
                float angle = ((float)i / (float)asteroidVertices) * (float)Math.PI * 2;
                Debug.WriteLine(angle);
                asteroidModel[i] = new PointF((float)Math.Sin(angle), (float)Math.Cos(angle));
            }


            asteroids = new List<SpaceObject>()
            {
                new SpaceObject(imgAsteroidLocation.X, imgAsteroidLocation.Y, 15.0f, -10.0f, 0.0f, 64)
            };
            player = new SpaceObject(pnlGame.Width / 2.0f, pnlGame.Height / 2.0f, 0f, 0f, 0.0f);

            bullets = new List<SpaceObject>();

            timer = new Stopwatch();
            timer.Start();

            tmrGameUpdate.Tick += OnGameUpdate;
            this.KeyDown += UserInput;
        }

        private void UserInput(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {   
                // Steer 
                case Keys.Left:
                    player.angle -= 0.1f;
                    break;
                case Keys.Right:
                    player.angle += 0.1f;
                    break;

                // Thrust
                case Keys.Up:
                    // Acceleration changes Velocity (with respect to time)
                    player.d.X += (float)Math.Sin(player.angle) * 1.0f;
                    player.d.Y += -(float)Math.Cos(player.angle) * 1.0f;
                    break;

                case Keys.Space:
                    bullets.Add(new SpaceObject(player.pos.X, player.pos.Y, 150 * (float)Math.Sin(player.angle), -150 * (float)Math.Cos(player.angle), 0, 10));
                    break;
            }
            // Cap
            if (player.d.X > 5.0f)
                player.d.X = 5.0f;
            if (player.d.X < -5.0f)
                player.d.X = -5.0f;

            if (player.d.Y > 5.0f)
                player.d.Y = 5.0f;
            if (player.d.Y < -5.0f)
                player.d.Y = -5.0f;

        }
        private void OnGameUpdate(object? sender, EventArgs e)
        {
            if (gameOver)
            {
                tmrGameUpdate.Enabled = false;
                return;
            }

            timer.Stop();
            float elapsedTime = timer.ElapsedMilliseconds / 1000.0f;
            graphics.Clear(Color.Black);

            RenderSpaceShip(elapsedTime);
            RenderAsteroids(elapsedTime);
            RenderBullets(elapsedTime);
            pnlGame.Refresh();
        }

        private void FillPolygonModel(PointF[] modelCoordinates, PointF pos, float rotate = 0.0f, float scale = 1.0f)
        {
            int vertices = modelCoordinates.Length;
            PointF[] transformedCoordinates = new PointF[vertices];

            // Rotate 
            for (int i=0; i<vertices; i++)
            {
                transformedCoordinates[i].X = modelCoordinates[i].X * (float)Math.Cos(rotate) - modelCoordinates[i].Y * (float)Math.Sin(rotate);
                transformedCoordinates[i].Y = modelCoordinates[i].X * (float)Math.Sin(rotate) + modelCoordinates[i].Y * (float)Math.Cos(rotate);
            }

            // Scale 
            for (int i=0; i<vertices; i++)
            {
                transformedCoordinates[i].X = transformedCoordinates[i].X * scale;
                transformedCoordinates[i].Y = transformedCoordinates[i].Y * scale;
            }

            // Translate
            for (int i=0; i<vertices; i++)
            {
                transformedCoordinates[i].X = transformedCoordinates[i].X + pos.X;
                transformedCoordinates[i].Y = transformedCoordinates[i].Y + pos.Y;
            }

            // Draw closed polygon
            graphics.FillPolygon(brush, transformedCoordinates);
        }
         
        private void RenderSpaceShip(float elapsedTime)
        {
            // Velocity changes position (with respect to time)
            player.pos.X += player.d.X;
            player.pos.Y += player.d.Y;
            player.WrapCoordinates(pnlGame.Width, pnlGame.Height);
            FillPolygonModel(shipModel, player.pos, player.angle);

            foreach (SpaceObject asteroid in asteroids)
            {
                if (doesCirclesIntersects(player.pos, 10, asteroid.pos, asteroid.size))
                {
                    gameOver = true;
                    return;
                }
            }
        }

        private void RenderAsteroids(float elapsedTime)
        {
            foreach (SpaceObject asteroid in asteroids)
            {
                asteroid.pos.X += asteroid.d.X * elapsedTime;
                asteroid.pos.Y += asteroid.d.Y * elapsedTime;

                asteroid.WrapCoordinates(pnlGame.Width, pnlGame.Height);
                // FillPolygonModel(asteroidModel, asteroid.pos, 0, asteroid.size);

                PictureBox pbAsteroid = new PictureBox();
                pbAsteroid.BackgroundImage = imgAsteroid.BackgroundImage;
                pbAsteroid.BackgroundImageLayout = ImageLayout.Stretch;
                pbAsteroid.BackColor = Color.Transparent;
                pbAsteroid.Size = new Size(asteroid.size, asteroid.size);
                Point location = pbAsteroid.Location;
                location.X = (int)asteroid.pos.X;
                location.Y = (int)asteroid.pos.Y;
                pbAsteroid.Location = location;
            }
            imgAsteroid.Location = imgAsteroidLocation;
        }
        private void RenderBullets(float elapsedTime)
        {
            List<SpaceObject> newAsteroids = new List<SpaceObject>();

            foreach (SpaceObject bullet in bullets)
            {
                bullet.pos.X += bullet.d.X * elapsedTime;
                bullet.pos.Y += bullet.d.Y * elapsedTime;
                graphics.FillEllipse(brush, bullet.pos.X - bullet.size / 2, bullet.pos.Y - bullet.size / 2, bullet.size, bullet.size);


                // check collision with asteroids
                foreach (SpaceObject asteroid in asteroids)
                {
                    if (doesCirclesIntersects(bullet.pos, bullet.size, asteroid.pos, asteroid.size))
                    {
                        bullet.pos.X = -1000;   // off screen so later it gets removed

                        if (asteroid.size == 64)
                        {
                            float angle1 = (float)random.NextDouble() * (float)Math.PI * 2;
                            float angle2 = (float)random.NextDouble() * (float)Math.PI * 2;
                            newAsteroids.Add(new SpaceObject(asteroid.pos.X, asteroid.pos.Y, 20 * (float)Math.Sin(angle1), 20 * (float)Math.Cos(angle1), angle1, 32));
                            newAsteroids.Add(new SpaceObject(asteroid.pos.X, asteroid.pos.Y, 20 * (float)Math.Sin(angle2), 20 * (float)Math.Cos(angle2), angle2, 32));
                        }
                        asteroid.pos.X = -1000;
                    }
                }
            }

            for (int i = 0; i < asteroids.Count; i++)
            {
                SpaceObject asteroid = asteroids[i];
                if (asteroid.pos.X >= 0)
                    newAsteroids.Add(asteroid);
            }
            asteroids = newAsteroids;

            List<SpaceObject> visibleBullets = new List<SpaceObject>();

            for (int i = 0; i < bullets.Count; i++)
            {
                SpaceObject bullet = bullets[i];
                if (bullet.pos.X >= 0 && bullet.pos.Y >= 0 && bullet.pos.X <= pnlGame.Width && bullet.pos.Y <= pnlGame.Height)
                    visibleBullets.Add(bullet);
            }
            bullets = visibleBullets;
        }

        private bool doesCirclesIntersects(PointF posCircle1, float radius1, PointF posCircle2, float radius2)
        {
            float x = (posCircle1.X - posCircle2.X);
            float y = (posCircle1.Y - posCircle2.Y);
            float distance = (float)Math.Sqrt(x * x + y * y);

            return (distance - radius1 - radius2) <= 0;
        }
    }

    public class SpaceObject
    {
        public PointF pos;
        public PointF d;     // velocity coords; speed and direction that object is traveling;
        public float angle;
        public int size;

        public SpaceObject(float xPos, float yPos, float dx = 0, float dy = 0, float angle = 0, int size = 0)
        {
            pos = new PointF(xPos, yPos);
            d = new PointF(dx, dy);
            this.angle = angle;
            this.size = size;  
        }
        public void WrapCoordinates(int width, int height)
        {
            if (pos.X < 0.0f)
                pos.X += width;

            if (pos.X >= width)
                pos.X -= width;

            if (pos.Y < 0.0f)
                pos.Y += height;

            if (pos.Y >= height)
                pos.Y -= height;
        }
    }
}