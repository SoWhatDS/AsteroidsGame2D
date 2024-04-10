
using Asteroids2D.Config;
using Asteroids2D.Engine.Enemy.Spawner;


namespace Asteroids2D.Engine.Enemy
{
    internal sealed class ForAllEnemiesController : BaseController
    {
        private SettingsContainer _settingsContainer;
        private EnemySpawnerController _enemySpawnerController;

        public ForAllEnemiesController(SettingsContainer settingsContainer)
        {
            _settingsContainer = settingsContainer;
            EnemyFactory enemyFactory = new EnemyFactory(_settingsContainer);
            _enemySpawnerController = new EnemySpawnerController(_settingsContainer.EnemySpawnerModel, enemyFactory);
            AddController(_enemySpawnerController);

        }

        protected override void OnDispose()
        {
            _enemySpawnerController.Dispose();
        }
    }
}
