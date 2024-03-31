using System.Collections;
using System.Collections.Generic;
using Asteroids2D.Config;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class ForAllEnemiesController : BaseController
    {
        private SettingsContainer _settingsContainer;

        public ForAllEnemiesController(SettingsContainer settingsContainer)
        {
            _settingsContainer = settingsContainer;
            EnemyFactory enemyFactory = new EnemyFactory(_settingsContainer);
        }

        protected override void OnDispose()
        {
            
        }
    }
}
