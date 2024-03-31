
using Asteroids2D.Engine.ObjectPool;
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    internal sealed class FireShip : IFire
    {
        private Rigidbody2D _bulletPrefab;
        private Transform _fireTransform;
        private Transform _playerTransform;
        private float _bulletForce;

        private IViewServices _viewServices;

        public FireShip(Rigidbody2D bulletPrefab,Transform fireTransform,float bulletForce,Transform playerTransform,IViewServices viewServices)
        {
            _bulletPrefab = bulletPrefab;
            _fireTransform = fireTransform;
            _playerTransform = playerTransform;
            _bulletForce = bulletForce;
            _viewServices = viewServices;
        }

        public void Fire()
        {
            Rigidbody2D bullet = _viewServices.Instantiate<Rigidbody2D>(_bulletPrefab.gameObject,_fireTransform);
            bullet.AddForce(_fireTransform.up * _bulletForce);
            //_viewServices.Destroy(bullet.gameObject);
        }
    }
}
