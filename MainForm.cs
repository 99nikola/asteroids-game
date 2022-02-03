using System.Reflection;

namespace Asteroids
{
    public partial class MainForm : Form
    {
        Game game;

        public MainForm()
        {
            InitializeComponent();
            
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, pnlGame, new object[] { true });

            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;


            Bitmap bitmap = new(pnlGame.Width, pnlGame.Height);
            pnlGame.BackgroundImage = bitmap;

            Graphics graphics = Graphics.FromImage(bitmap);
            Toolbox.Init(graphics, pnlGame, lblScore, tmrGameUpdate, pnlGameStatus, pnlNextLevel, pnlYouWon, btnTryAgain, btnNextLevel, btnPlayAgain, lblLevel, lblShipLevel);

            game = new();
            KeyDown += game.Input;
            KeyUp += game.ReleaseInput;

            tmrGameUpdate.Tick += game.OnGameUpdate;
            btnTryAgain.Click += HandleReset;
            btnNextLevel.Click += HandleNextLevel;
            btnPlayAgain.Click += HandlePlayAgain;
        }

        private void HandleReset(object? sender, EventArgs e)
        {
            pnlGameStatus.Visible = false;
            btnTryAgain.Enabled = false;
            game.Reset();
        }

        private void HandleNextLevel(object? sender, EventArgs e)
        {
            pnlNextLevel.Visible = false;
            btnNextLevel.Enabled = false;
            game.NextLevel();
        }

        private void HandlePlayAgain(object? sender, EventArgs e)
        {
            pnlYouWon.Visible = false;
            btnPlayAgain.Enabled = false;
            game.Reset();
        }
    }
}