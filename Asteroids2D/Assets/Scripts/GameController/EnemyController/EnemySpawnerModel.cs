
using UnityEngine;

namespace Asteroids2D.Engine.Enemy.Spawner
{
    [CreateAssetMenu(fileName = nameof(EnemySpawnerModel),menuName = "Settings/ " + nameof(EnemySpawnerModel))]
    internal sealed class EnemySpawnerModel : ScriptableObject
    {
        [field: SerializeField] public float Timer { get; private set; }
        [field: SerializeField] public float TimeSpawnEnemy { get; private set;}
        [field: SerializeField] public LevelsInGameSpawn LevelsInGameSpawn { get; private set; }
    }
}
