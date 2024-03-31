
using Asteroids2D.Engine.Player;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class EnemyMoveTransform : IEnemyMove
    {
        private Transform _enemy;
        private Transform[] _wayPoints;
        private float _speed;
        private int _currentWayPointIndex;

        public EnemyMoveTransform(Transform enemy,float speed, Transform[] wayPoints)
        {
            _enemy = enemy;
            _speed = speed;
            _wayPoints = wayPoints;
            _currentWayPointIndex = 0;

        }

        public void Move()
        {
            if (_currentWayPointIndex < _wayPoints.Length)
            {
                _enemy.position = Vector2.MoveTowards(_enemy.position, _wayPoints[_currentWayPointIndex].position, _speed * Time.deltaTime);

                if (Vector2.Distance(_enemy.position, _wayPoints[_currentWayPointIndex].position) < 0.1f)
                {
                    _currentWayPointIndex++;
                }
            }
            else
            {             
                _currentWayPointIndex = 0;
            }
        }

        public void MoveToTarget(PlayerView playerView)
        {
            if (playerView == null)
            {
                return;
            }

            if (Vector2.Distance(_enemy.position, playerView.transform.position) < 1f)
            {
                return;
            }

            _enemy.position = Vector2.MoveTowards(_enemy.position, playerView.transform.position, _speed * Time.deltaTime);
        }
    }
}
