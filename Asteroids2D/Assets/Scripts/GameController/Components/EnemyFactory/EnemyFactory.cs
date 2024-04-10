using System.Collections;
using System.Collections.Generic;
using Asteroids2D.Config;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class EnemyFactory : IEnemyFactory
    {
        private SettingsContainer _settingsContainer;

        private List<IEnemyUnit> _enemiesOnMapList;

        public List<IEnemyUnit> EnemiesOnMapList => _enemiesOnMapList;

        public EnemyFactory(SettingsContainer settingsContainer)
        {
            _settingsContainer = settingsContainer;
            _enemiesOnMapList = new List<IEnemyUnit>();
        }

        public IEnemyUnit CreateEnemy(Vector2 startPosition)
        {
            IEnemyUnit enemyUnit = new EnemyController(_settingsContainer.EnemyModel,startPosition);
            _enemiesOnMapList.Add(enemyUnit);
            return enemyUnit;
        }

        public IEnemyUnit CreateMiddleEnemy(Vector2 startPosition)
        {
            IEnemyUnit enemyUnit = new MiddleEnemyController(_settingsContainer.MiddleEnemyModel,startPosition);
            _enemiesOnMapList.Add(enemyUnit);
            return enemyUnit;
        }

        public void Dispose()
        {
            foreach (IEnemyUnit enemy in _enemiesOnMapList)
            {
                _enemiesOnMapList.Remove(enemy);
            }

            _enemiesOnMapList.Clear();
        }
    }
}
