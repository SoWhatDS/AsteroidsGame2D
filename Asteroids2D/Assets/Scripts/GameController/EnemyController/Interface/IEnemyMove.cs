

using Asteroids2D.Engine.Player;

namespace Asteroids2D.Engine.Enemy
{
    internal interface IEnemyMove 
    {
        public void Move();
        public void MoveToTarget(PlayerView playerView);
    }
}
