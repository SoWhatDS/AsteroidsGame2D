
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    internal class MoveTransform : IMove
    {
        private readonly Transform _transform;
        private Vector3 _move;

        public float Speed { get; protected set; }

        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }

        public void Move(Vector2 direction)
        {
            if (direction == Vector2.zero)
            {
                return;
            }

            float speed = Speed * Time.deltaTime;
            _move.Set(direction.x * speed, direction.y * speed, 0);
            _transform.localPosition += _move;
        }
    }
}
