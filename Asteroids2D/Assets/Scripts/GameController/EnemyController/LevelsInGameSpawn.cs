using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy.Spawner
{
    [CreateAssetMenu(fileName = nameof(LevelsInGameSpawn),menuName = "Settings/ " + nameof(LevelsInGameSpawn))]
    internal sealed class LevelsInGameSpawn : ScriptableObject
    {
        [field: SerializeField] public List<LevelSpawnWave> GameLevelsSpawner { get; private set; }
    }
}
