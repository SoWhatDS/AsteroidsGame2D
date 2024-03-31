using System.Collections;
using System.Collections.Generic;
using Asteroids2D.Engine.Player;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class MiddleEnemy :IEnemyMove,IRotateEnemy,IFire
    {
        private IEnemyMove _enemyMove;
        private IRotateEnemy _enemyRotate;
        private IFire _enemyFire;

        public MiddleEnemy(IEnemyMove enemyMove,IRotateEnemy rotateEnemy,IFire enemyFire)
        {
            _enemyMove = enemyMove;
            _enemyRotate = rotateEnemy;
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
            _enemyRotate.Rotate();
        }

        public void RotateTotarget(PlayerView playerView)
        {
            _enemyRotate.RotateTotarget(playerView);
        }
    }
}
