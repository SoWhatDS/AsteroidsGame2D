
using Asteroids2D.Engine.ObjectPool;
using Asteroids2D.Utils;
using JoostenProductions;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class EnemyController : BaseController,IEnemyUnit
    {
        private EnemyView _enemyView;
        private EnemyModel _enemyModel;
        private Enemy _enemy;
        private Transform[] _wayPoints;

        private IViewServices _viewServices;

        public EnemyController(EnemyModel enemyModel)
        {
            _enemyView = LoadView();
            _enemyModel = enemyModel;

            _viewServices = new ViewServices();

            IEnemyMove EnemyMove = new EnemyMoveTransform(_enemyView.transform,_enemyModel.Speed,_wayPoints);
            IRotateEnemy EnemyRotate = new EnemyRotation(_enemyModel.RotateSpeed,_wayPoints,_enemyView.transform);
            IFire EnemyFire = new EnemyFire(_viewServices,_enemyView.FireTransform,_enemyModel.BulletForce,_enemyModel.BulletPrefab);
            _enemy = new Enemy(EnemyMove,EnemyRotate,EnemyFire);

            UpdateManager.SubscribeToUpdate(Update);
            UpdateManager.SubscribeToFixedUpdate(FixedUpdate);
        }

        private EnemyView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.ENEMY_VIEW);
            GameObject prefabWayPoints = ResourceLoader.LoadPrefab(GameConstantsView.ENEMYWAYPOINTS);
            GameObject objectView = Object.Instantiate(prefab);
            GameObject wayPointsObject = Object.Instantiate(prefabWayPoints);
            _wayPoints = wayPointsObject.GetComponentsInChildren<Transform>();
            AddGameObject(objectView);
            AddGameObject(wayPointsObject);
            return ResourceLoader.GetOrAddComponent<EnemyView>(objectView);
        }

        private void Update()
        {
            if (_enemyView.EnemyVision.TargetPlayer == null)
            {
                _enemy.Move();
                _enemy.Rotate();
                
            }
            else
            {
                _enemy.MoveToTarget(_enemyView.EnemyVision.TargetPlayer);
                _enemy.RotateTotarget(_enemyView.EnemyVision.TargetPlayer);             
            }
        }

        private void FixedUpdate()
        {
            if (_enemyView.EnemyVision.TargetPlayer == null)
            {
                return;
            }

            _enemy.FireFixedUpdate(_enemyView.EnemyVision.TargetPlayer);
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);
            UpdateManager.UnsubscribeFromFixedUpdate(FixedUpdate);
        }
    }
}
