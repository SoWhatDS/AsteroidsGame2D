
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    internal interface IMove 
    {
        float Speed { get; }
        void Move(Vector2 direction);
    }
}
