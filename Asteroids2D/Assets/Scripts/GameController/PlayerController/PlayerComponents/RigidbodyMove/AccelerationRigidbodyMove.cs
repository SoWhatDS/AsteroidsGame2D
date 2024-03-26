
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    internal sealed class AccelerationRigidbodyMove : RigidbodyMove
    {
        private float _acceleration;

        public AccelerationRigidbodyMove(Rigidbody2D playerRigidbody2D, float speed,float acceleration) : base(playerRigidbody2D, speed)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}
