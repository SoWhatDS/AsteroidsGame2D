
using Asteroids2D.Engine.Enemy;
using Asteroids2D.Engine.Enemy.Spawner;
using Asteroids2D.Engine.GameInput;
using Asteroids2D.Engine.Player;
using UnityEngine;

namespace Asteroids2D.Config
{
    [CreateAssetMenu(fileName = nameof(SettingsContainer),menuName = "Settings/ " + nameof(SettingsContainer))]
    internal sealed class SettingsContainer : ScriptableObject
    {
        [field: SerializeField] public InputReader InputReader { get; private set; }
        [field: SerializeField] public PlayerModel PlayerModel { get; private set; }
        [field: SerializeField] public EnemyModel EnemyModel { get; private set; }
        [field: SerializeField] public MiddleEnemyModel MiddleEnemyModel { get; private set; }
        [field: SerializeField] public EnemySpawnerModel EnemySpawnerModel { get; private set; }
    }
}
