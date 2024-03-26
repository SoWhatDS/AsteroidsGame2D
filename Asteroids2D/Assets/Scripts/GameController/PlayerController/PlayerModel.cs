
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    [CreateAssetMenu(fileName = nameof(PlayerModel),menuName = "Settings/ " + nameof(PlayerModel))]
    internal sealed class PlayerModel : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Acceleration { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }

        [field: SerializeField] public float BulletForce { get; private set;}
        [field: SerializeField] public Rigidbody2D BulletPrefab { get; private set;}
    }
}
