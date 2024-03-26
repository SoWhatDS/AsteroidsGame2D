
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    internal sealed class FireShip : IFire
    {
        private Rigidbody2D _bulletPrefab;
        private Transform _fireTransform;
        private Transform _playerTransform;
        private float _bulletForce;

        public FireShip(Rigidbody2D bulletPrefab,Transform fireTransform,float bulletForce,Transform playerTransform)
        {
            _bulletPrefab = bulletPrefab;
            _fireTransform = fireTransform;
            _playerTransform = playerTransform;
            _bulletForce = bulletForce;
        }

        public void Fire()
        {
            Rigidbody2D bullet = Object.Instantiate(_bulletPrefab, _fireTransform.position, _playerTransform.rotation);
            bullet.AddForce(_fireTransform.up * _bulletForce);
        }
    }
}
