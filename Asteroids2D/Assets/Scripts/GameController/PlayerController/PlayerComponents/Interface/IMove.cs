using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    internal interface IMove 
    {
        float Speed { get; }
        void Move(float horizontal,float vertical,float deltaTime);
    }
}
