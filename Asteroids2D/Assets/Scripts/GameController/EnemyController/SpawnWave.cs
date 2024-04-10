
using UnityEngine;

namespace Asteroids2D.Engine.Enemy.Spawner
{
    [CreateAssetMenu(fileName = nameof(SpawnWave), menuName = "Settings/ " + nameof(SpawnWave))]
    internal sealed class SpawnWave : ScriptableObject
    {
        [field: SerializeField] public int EnemyCount { get; private set;}
        [field: SerializeField] public int MiddleEnemyCount { get; private set;}
        [field: SerializeField] public int IndexWave { get; private set; }
    }
}
