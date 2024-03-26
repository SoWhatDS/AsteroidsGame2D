
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    internal sealed class Player : IMove, IRotation,IFire,ITakeDamage
    {
        private readonly IMove _rigidbody2DMove;
        private readonly IRotation _rotationTransform;
        private readonly IFire _fireShip;
        private readonly ITakeDamage _takeDamageShip;

        public float Speed => _rigidbody2DMove.Speed;

        public Player(IMove Rigidbody2DMove,IRotation rotationTransform,IFire fireShip,ITakeDamage takeDamageShip)
        {
            _rigidbody2DMove = Rigidbody2DMove;
            _rotationTransform = rotationTransform;
            _fireShip = fireShip;
            _takeDamageShip = takeDamageShip;      
        }

        public void Move(Vector2 direction)
        {
            _rigidbody2DMove.Move(direction);
        }

        public void Rotation(Vector2 direction)
        {
            _rotationTransform.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_rigidbody2DMove is AccelerationRigidbodyMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_rigidbody2DMove is AccelerationRigidbodyMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

        public void Fire()
        {
            _fireShip.Fire();   
        }

        public void TakeDamage()
        {
            _takeDamageShip.TakeDamage();
        }
    }
}
