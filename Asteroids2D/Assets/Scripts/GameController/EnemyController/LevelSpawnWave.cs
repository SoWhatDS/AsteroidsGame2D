
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy.Spawner
{
    [CreateAssetMenu(fileName = nameof(LevelSpawnWave),menuName = "Settings/ " + nameof(LevelSpawnWave))]
    internal sealed class LevelSpawnWave : ScriptableObject
    {
        [field: SerializeField] public int IndexLevel { get; private set;}
        [field: SerializeField] public List<SpawnWave> SpawnWaveInLevel { get; private set; } 
    }
}
