

using Asteroids2D.Engine.Player;

namespace Asteroids2D.Engine.Enemy
{
    internal interface IRotateEnemy 
    {
        public void Rotate();
        public void RotateTotarget(PlayerView playerView);
    }
}
