
using UnityEngine;


namespace Asteroids2D.Engine.Player
{
    public class RotationPlayer : IRotation
    {
        private Transform _transform;
        private float _rotationSpeed;

        public RotationPlayer(Transform transform,float rotationSpeed)
        {
            _transform = transform;
            _rotationSpeed = rotationSpeed;
        }

        public void Rotation(Vector2 direction)
        {
            if (direction == Vector2.zero)
            {
                return;
            }

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90f);
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        }
    }
}
