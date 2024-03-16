
using Asteroids2D.Utils;

namespace Asteroids2D.Config
{
    internal sealed class ProfileGame 
    {
        public readonly SubscriptionProperty<GameState> CurrentGameState;

        public ProfileGame(GameState initialGameState)
        {
            CurrentGameState = new SubscriptionProperty<GameState>();
            CurrentGameState.Value = initialGameState;
        }
    }
}
