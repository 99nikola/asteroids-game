
namespace Asteroids
{
    public class LevelStatus
    {
        private int asteroidsHit;
        private bool passed;

        public LevelStatus()
        {
            asteroidsHit = 0;   
            passed = false;
        }

        public int AsteroidsHit
        {
            get => asteroidsHit;
            set => asteroidsHit = value;
        }

        public bool Passed
        {
            get => passed;
            set => passed = value;
        }

    }
}
