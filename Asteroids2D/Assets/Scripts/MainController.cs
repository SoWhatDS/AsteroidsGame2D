
using Asteroids2D.Config;
using UnityEngine;

namespace Asteroids2D.Engine
{
    internal sealed class MainController : BaseController
    {
        private readonly ProfileGame _profileGame;
        private readonly SettingsContainer _settingsContainer;

        private GameController _gameController;

        internal MainController(ProfileGame profileGame,SettingsContainer settingsContainer)
        {
            _profileGame = profileGame;
            _settingsContainer = settingsContainer;

            _profileGame.CurrentGameState.SubscribeOnChanged(OnChangeGameState);
            OnChangeGameState(_profileGame.CurrentGameState.Value);
        }

        private void OnChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.MainMenu:
                    break;
                case GameState.Loading:
                    break;
                case GameState.StartGame:
                    _gameController = new GameController(_profileGame,_settingsContainer);
                    break;
                case GameState.Pause:
                    break;
                case GameState.ExitGame:
                    QuitGame();
                    break;
                default:
                    DisposeAllControllers();
                    break;
            }
        }

        private void QuitGame()
        {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            {
                Debug.Log(this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
#endif

#if (UNITY_EDITOR)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }

#elif (UNITY_STANDALONE)
            {
               Application.Quit();
            }
#elif (UNITY_WEBGL)
            {
               SceneManager.LoadScene("QuitScene");
            }
#endif
        }

        private void CreateAllControllers()
        {

        }

        private void DisposeAllControllers()
        {
            _gameController?.Dispose();
        }
    }
}
