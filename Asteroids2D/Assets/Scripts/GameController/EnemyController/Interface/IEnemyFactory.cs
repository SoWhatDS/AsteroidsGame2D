

using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal interface IEnemyFactory
    {
        public IEnemyUnit CreateEnemy(Vector2 startPositon);
        public IEnemyUnit CreateMiddleEnemy(Vector2 startPosition);
    }
}
