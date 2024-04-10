using System.Collections;
using System.Collections.Generic;
using Asteroids2D.Engine.ObjectPool;
using Asteroids2D.Utils;
using JoostenProductions;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class MiddleEnemyController : BaseController,IEnemyUnit
    {
        private MiddleEnemyView _middleEnemyView;
        private MiddleEnemyModel _middleEnemyModel;
        private MiddleEnemy _middleEnemy;

        private Vector2 _startPosition;



        private Transform[] _wayPoints;

        public MiddleEnemyController(MiddleEnemyModel middleEnemyModel,Vector2 startPosition)
        {
            _middleEnemyView = LoadView();
            _middleEnemyModel = middleEnemyModel;

            IViewServices viewServices = new ViewServices();
            _startPosition = startPosition;
            
            IEnemyMove enemyMove = new EnemyMoveTransform(_middleEnemyView.transform,_middleEnemyModel.Speed,_wayPoints);
            IRotateEnemy rotateEnemy = new EnemyRotation(_middleEnemyModel.RotateSpeed,_wayPoints,_middleEnemyView.transform);
            IFire enemyFire = new EnemyFire(viewServices,_middleEnemyView.FireTransform,_middleEnemyModel.BulletForce,_middleEnemyModel.BulletPrefab);

            _middleEnemy = new MiddleEnemy(enemyMove,rotateEnemy,enemyFire);

            UpdateManager.SubscribeToUpdate(Update);
            UpdateManager.SubscribeToFixedUpdate(FixedUpdate);
        }

        private void Update()
        {
            if (_middleEnemyView.EnemyVision.TargetPlayer == null)
            {
                _middleEnemy.Move();
                _middleEnemy.Rotate();
            }
            else
            {
                _middleEnemy.MoveToTarget(_middleEnemyView.EnemyVision.TargetPlayer);
                _middleEnemy.RotateTotarget(_middleEnemyView.EnemyVision.TargetPlayer);
            }
        }

        private void FixedUpdate()
        {
            if (_middleEnemyView.EnemyVision.TargetPlayer == null)
            {
                return;
            }

            _middleEnemy.FireFixedUpdate(_middleEnemyView.EnemyVision.TargetPlayer);
        }

        private MiddleEnemyView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.MIDDLEENEMY_VIEW);
            GameObject objectView = Object.Instantiate(prefab,_startPosition,Quaternion.identity);
            GameObject wayPoints = ResourceLoader.LoadPrefab(GameConstantsView.ENEMYWAYPOINTS);
            GameObject wayPointsView = Object.Instantiate(wayPoints, objectView.transform);
            _wayPoints = wayPoints.GetComponentsInChildren<Transform>();
            AddGameObject(wayPoints);
            AddGameObject(objectView);
            return ResourceLoader.GetOrAddComponent<MiddleEnemyView>(objectView);
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);
            UpdateManager.UnsubscribeFromFixedUpdate(FixedUpdate);
        }
    }
}
