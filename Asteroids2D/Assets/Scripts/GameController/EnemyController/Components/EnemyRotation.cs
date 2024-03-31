
using Asteroids2D.Engine.Player;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class EnemyRotation : IRotateEnemy
    {
        private float _rotationSpeed;
        private Transform[] _wayPoints;
        private Transform _enemy;
        private int _currentWayPointIndex;

        public EnemyRotation(float rotationSpeed, Transform[] wayPoints,Transform enemy)
        {
            _rotationSpeed = rotationSpeed;
            _wayPoints = wayPoints;
            _enemy = enemy;
            _currentWayPointIndex = 0;
        }

        public void Rotate()
        {
            if (_currentWayPointIndex < _wayPoints.Length)
            {
                Vector2 lookDirection = _wayPoints[_currentWayPointIndex].position - _enemy.position;
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90.0f);
                _enemy.rotation = Quaternion.RotateTowards(_enemy.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

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

        public void RotateTotarget(PlayerView playerView)
        {
            if (playerView == null)
            {
                return;
            }

            Vector2 lookDirection = playerView.transform.position - _enemy.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90.0f);
            _enemy.rotation = Quaternion.RotateTowards(_enemy.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
