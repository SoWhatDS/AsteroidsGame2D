using System;
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    internal sealed class PlayerView : MonoBehaviour
    {
        [field: SerializeField] public Transform FireTransform { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }

        public event Action OnTakeDamage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTakeDamage?.Invoke();
        }
    }
}
