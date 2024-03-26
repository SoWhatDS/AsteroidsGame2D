using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    internal sealed class TakeDamageShip : ITakeDamage
    {
        private int _damage;
        private float _health;       

        public TakeDamageShip(float health,int damage)
        {
            _damage = damage;
            _health = health;
        }

        public void TakeDamage()
        {
            _health -= _damage;
            Debug.Log(_health);
        }
    }
}
