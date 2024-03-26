
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    internal class RigidbodyMove : IMove
    {
        private Rigidbody2D _playerRigidbody2D;
        public float Speed { get; protected set; }

        public RigidbodyMove(Rigidbody2D playerRigidbody2D, float speed)
        {
            _playerRigidbody2D = playerRigidbody2D;
            Speed = speed;
        }

        public void Move(Vector2 direction)
        {
            _playerRigidbody2D.velocity = direction * Time.fixedDeltaTime * Speed;
        }
    }
}
