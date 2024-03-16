
using Asteroids2D.Config;
using Asteroids2D.Engine.Player;

namespace Asteroids2D.Engine
{
    internal sealed class GameController : BaseController
    {
        private readonly ProfileGame _profileGame;
        private readonly SettingsContainer _settingsContainer;

        private PlayerController _playerController;

        public GameController(ProfileGame profileGame,SettingsContainer settingsContainer)
        {
            _profileGame = profileGame;
            _settingsContainer = settingsContainer;

            CreateAllControllers();
        }

        private void CreateAllControllers()
        {
            _playerController = new PlayerController(_settingsContainer.PlayerModel);
        }

        protected override void OnDispose()
        {
            
        }
    }
}
