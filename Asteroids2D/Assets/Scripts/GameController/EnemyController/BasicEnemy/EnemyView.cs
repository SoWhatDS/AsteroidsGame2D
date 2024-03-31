
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class EnemyView : MonoBehaviour
    {
        [field: SerializeField] public EnemyVision EnemyVision { get; private set; }
        [field: SerializeField] public Transform FireTransform { get; private set; }
    }
}
