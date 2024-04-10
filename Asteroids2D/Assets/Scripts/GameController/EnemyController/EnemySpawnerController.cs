using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy.Spawner
{
    internal sealed class EnemySpawnerController : BaseController
    {
        private EnemySpawnerModel _enemySpawnerModel;
        private IEnemyFactory _enemyFactory;

        private float _timer;
        private int _indexWaveSpawnLevel;
        private float _radiusSpawn = 100f;
        private float _timeSpawnWave;
        private Vector2 _spawnCenter;
        private LevelSpawnWave _levelSpawnWave;

        public EnemySpawnerController(EnemySpawnerModel enemySpawnerModel,IEnemyFactory enemyFactory)
        {
            _enemySpawnerModel = enemySpawnerModel;
            _enemyFactory = enemyFactory;
            _timer = 0f;
            _indexWaveSpawnLevel = 0;
            _spawnCenter = Vector2.zero;
            _timeSpawnWave = enemySpawnerModel.TimeSpawnEnemy;
            SwitchLevelIndex();
            UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            TimerForSpawn();
        }

        private void SwitchLevelIndex()
        {
            for (int i = 0; i < _enemySpawnerModel.LevelsInGameSpawn.GameLevelsSpawner.Count; i++)
            {
                if (_enemySpawnerModel.LevelsInGameSpawn.GameLevelsSpawner[i].IndexLevel == 1)
                {
                    _levelSpawnWave = _enemySpawnerModel.LevelsInGameSpawn.GameLevelsSpawner[i];
                }
            }
        }

        private void TimerForSpawn()
        {
            _timer += Time.deltaTime;

            if (_timer >= _timeSpawnWave)
            {
                SpawnLevelWave();
                Debug.Log("NextWave");
                _timer = 0f;
            }
        }

        private void SpawnLevelWave()
        {
            if (_indexWaveSpawnLevel > _levelSpawnWave.SpawnWaveInLevel.Count)
            {
                Debug.Log("Level Complete");
                return;
            }

            for (int i = 0; i < _levelSpawnWave.SpawnWaveInLevel.Count; i++)
            {
                if (i == _indexWaveSpawnLevel)
                {
                    for (int j = 0; j < _levelSpawnWave.SpawnWaveInLevel[i].EnemyCount; j++)
                    {
                        Vector2 randomOffSetSpawn = Random.insideUnitCircle * _radiusSpawn;
                        Vector2 spawnPosition = _spawnCenter + randomOffSetSpawn;
                        _enemyFactory.CreateEnemy(spawnPosition);
                        Debug.Log(randomOffSetSpawn);
                    }

                    /*for (int k = 0; k < _levelSpawnWave.SpawnWaveInLevel[i].MiddleEnemyCount; k++)
                    {
                        Vector2 randomOffSetSpawn = Random.insideUnitCircle * _radiusSpawn;
                        Vector2 spawnPosition = _spawnCenter + randomOffSetSpawn;
                        _enemyFactory.CreateMiddleEnemy(spawnPosition);
                    }*/
                }
            }

            _indexWaveSpawnLevel++;
        }



        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);
        }
    }
}
