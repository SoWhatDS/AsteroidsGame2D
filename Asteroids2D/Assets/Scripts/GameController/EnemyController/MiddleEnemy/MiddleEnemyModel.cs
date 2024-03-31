
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    [CreateAssetMenu(fileName = nameof(MiddleEnemy),menuName = "Settings/ " + nameof(MiddleEnemy))]
    internal sealed class MiddleEnemyModel : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float RotateSpeed { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public GameObject BulletPrefab { get; private set; }
        [field: SerializeField] public float BulletForce { get; private set;}
    }
}
