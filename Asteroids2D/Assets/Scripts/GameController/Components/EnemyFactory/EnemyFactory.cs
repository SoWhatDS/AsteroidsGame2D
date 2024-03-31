using System.Collections;
using System.Collections.Generic;
using Asteroids2D.Config;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class EnemyFactory 
    {
        private SettingsContainer _settingsContainer;

        public EnemyFactory(SettingsContainer settingsContainer)
        {
            _settingsContainer = settingsContainer;
        }

        public IEnemyUnit CreateEnemy()
        {
            return new EnemyController(_settingsContainer.EnemyModel);
        }

        public IEnemyUnit CreateMiddleEnemy()
        {
            return new MiddleEnemyController(_settingsContainer.MiddleEnemyModel);
        }
    }
}
