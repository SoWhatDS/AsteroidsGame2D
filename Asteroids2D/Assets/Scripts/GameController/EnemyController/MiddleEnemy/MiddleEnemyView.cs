
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class MiddleEnemyView : MonoBehaviour
    {
        [field: SerializeField] public Transform FireTransform { get; private set; }
        [field: SerializeField] public EnemyVision EnemyVision { get; private set; }
    }
}
