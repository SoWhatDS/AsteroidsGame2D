using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    public class RotationPlayer : IRotation
    {
        private Transform _transform;

        public RotationPlayer(Transform transform)
        {
            _transform = transform;
        }

        public void Rotation(Vector3 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
