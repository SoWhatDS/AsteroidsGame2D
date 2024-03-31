
using Asteroids2D.Engine.Player;
using UnityEngine;

namespace Asteroids2D.Engine.Enemy
{
    internal sealed class EnemyVision : MonoBehaviour
    {
        [field: SerializeField] public PlayerView TargetPlayer { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerView>(out PlayerView player))
            {
                TargetPlayer = player;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            TargetPlayer = null;
        }
    }
}
