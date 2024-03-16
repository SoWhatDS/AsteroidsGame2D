
using Asteroids2D.Config;
using Asteroids2D.Engine;
using UnityEngine;

namespace Asteroids2D
{
    internal class GameStarter : MonoBehaviour
    {
        [SerializeField] private SettingsContainer _settingsContainer;

        private const GameState _initialState = GameState.StartGame;

        private MainController _mainController;

        private void Start()
        {
            ProfileGame profileGame = new ProfileGame(_initialState);
            _mainController = new MainController(profileGame,_settingsContainer);
        }

        private void OnDestroy()
        {
            _mainController.Dispose();
        }
    }
}
