
using Asteroids2D.Engine.ObjectPool;
using Asteroids2D.Engine.Player;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class EnemyFire : IFire
    {
        private IViewServices _viewServices;
        private Transform _fireTransform;
        private GameObject _bulletPrefab;
        private float _bulletForce;

        private float _timer;
        private float _reloadTime = 0.5f;

        public EnemyFire(IViewServices viewServices,Transform fireTransform,float bulletForce,GameObject bulletPrefab)
        {
            _viewServices = viewServices;
            _fireTransform = fireTransform;
            _bulletForce = bulletForce;
            _bulletPrefab = bulletPrefab;
        }

        public void FireFixedUpdate(PlayerView playerView)
        {
            Reload(playerView);
        }

        private void Reload(PlayerView playerView)
        {
            _timer += Time.fixedDeltaTime;

            if (_timer >= _reloadTime)
            {
                CreateBullet(playerView);
                _timer = 0f;
            }
        }

        private void CreateBullet(PlayerView playerView)
        {
            if (Vector2.Distance(playerView.transform.position, _fireTransform.position) < 10f)
            {
                var bullet = _viewServices.Instantiate<Rigidbody2D>(_bulletPrefab, _fireTransform);
                bullet.AddForce(_fireTransform.up * _bulletForce);
            }
        }

    }
}
