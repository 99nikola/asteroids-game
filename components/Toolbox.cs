using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace Asteroids
{
    public static class Toolbox
    {
        public static Graphics graphics;
        public static Pen pen;
        public static Brush brush;
        public static Panel pnlGame;
        public static Label lblScore;
        public static Timer tmrGameUpdate;
        public static Stopwatch stopwatch;
        public static Panel pnlGameOver;
        public static Panel pnlNextLevel;
        public static Panel pnlYouWon;
        public static Button btnTryAgain;
        public static Button btnNextLevel;
        public static Button btnPlayAgain;
        public static Label lblLevel;
        public static Label lblShipLevel;

        public static void Init(Graphics g, Panel pnl, Label s, Timer t, Panel pnlGO, Panel pnlNL, Panel pnlYW, Button btnTA, Button btnNL, Button btnPA, Label lblL, Label lblSL)
        {
            graphics = g;
            brush = new SolidBrush(Color.White);
            pen = new(brush, 1);
            pnlGame = pnl;
            lblScore = s;
            tmrGameUpdate = t;
            stopwatch = new Stopwatch();
            pnlGameOver = pnlGO;
            pnlNextLevel = pnlNL;
            pnlYouWon = pnlYW;
            btnNextLevel = btnNL;
            btnTryAgain = btnTA;
            btnPlayAgain = btnPA;
            lblLevel = lblL;
            lblShipLevel = lblSL;
        }
    }
}
