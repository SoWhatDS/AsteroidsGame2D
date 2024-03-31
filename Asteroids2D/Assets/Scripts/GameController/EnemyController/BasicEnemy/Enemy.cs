

using Asteroids2D.Engine.Player;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class Enemy :IEnemyMove,IRotateEnemy,IFire
    {
        private IEnemyMove _enemyMove;
        private IRotateEnemy _rotateEnemy;
        private IFire _enemyFire;
        
        public Enemy(IEnemyMove enemyMove,IRotateEnemy rotateEnemy,IFire enemyFire)
        {
            _enemyMove = enemyMove;
            _rotateEnemy = rotateEnemy;
            _enemyFire = enemyFire;
        }

        public void FireFixedUpdate(PlayerView playerView)
        {
            _enemyFire.FireFixedUpdate(playerView);
        }

        public void Move()
        {
            _enemyMove.Move();
        }

        public void MoveToTarget(PlayerView playerView)
        {
            _enemyMove.MoveToTarget(playerView);
        }

        public void Rotate()
        {
            _rotateEnemy.Rotate();
        }

        public void RotateTotarget(PlayerView playerView)
        {
            _rotateEnemy.RotateTotarget(playerView);
        }
    }
}
