
using Asteroids2D.Engine.Player;
using UnityEngine;

namespace Asteroids2D.Config
{
    [CreateAssetMenu(fileName = nameof(SettingsContainer),menuName = "Settings/ " + nameof(SettingsContainer))]
    internal sealed class SettingsContainer : ScriptableObject
    {
        [field: SerializeField] public PlayerModel PlayerModel { get; private set; }
    }
}