
using Asteroids2D.Config;
using Asteroids2D.Engine.Enemy;
using Asteroids2D.Engine.Player;

namespace Asteroids2D.Engine
{
    internal sealed class GameController : BaseController
    {
        private readonly ProfileGame _profileGame;
        private readonly SettingsContainer _settingsContainer;

        private PlayerController _playerController;
        private ForAllEnemiesController _forAllEnemiesController;

        public GameController(ProfileGame profileGame,SettingsContainer settingsContainer)
        {
            _profileGame = profileGame;
            _settingsContainer = settingsContainer;

            CreateAllControllers();
        }

        private void CreateAllControllers()
        {
            _playerController = new PlayerController(_settingsContainer.PlayerModel,_settingsContainer.InputReader);
            AddController(_playerController);

            _forAllEnemiesController = new ForAllEnemiesController(_settingsContainer);
            AddController(_forAllEnemiesController);

        }

        protected override void OnDispose()
        {
            _playerController?.Dispose();
            _forAllEnemiesController?.Dispose();
        }
    }
}
