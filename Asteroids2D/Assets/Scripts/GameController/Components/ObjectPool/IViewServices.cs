

using UnityEngine;

namespace Asteroids2D.Engine.ObjectPool
{
    internal interface IViewServices
    {
        public T Instantiate<T>(GameObject prefab);
        public T Instantiate<T>(GameObject prefab,Transform prefabInstantiateTransform);

        public void Destroy(GameObject prefab);
    }
}
