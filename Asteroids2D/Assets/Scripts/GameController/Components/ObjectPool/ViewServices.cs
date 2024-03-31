using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Asteroids2D.Engine.ObjectPool
{
    internal sealed class ViewServices : IViewServices
    {
        private readonly Dictionary<string, ObjectPool> _viewCache = new Dictionary<string, ObjectPool>(12);

        public ViewServices()
        {

        }

        public T Instantiate<T>(GameObject prefab)
        {
            if (!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache[prefab.name] = viewPool;
            }

            if (viewPool.Pop().TryGetComponent(out T component))
            {
                return component;
            }
            

            throw new ArgumentOutOfRangeException($"{typeof(T)} not found!!!");
        }

        public T Instantiate<T>(GameObject prefab,Transform prefabInstantiateTransform)
        {
            if (!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache[prefab.name] = viewPool;
            }

            if (viewPool.Pop(prefabInstantiateTransform).TryGetComponent(out T component))
            {
                return component;
            }


            throw new ArgumentOutOfRangeException($"{typeof(T)} not found!!!");
        }

        public void Destroy(GameObject prefab)
        {
            _viewCache[prefab.name].Push(prefab);
        }
        
    }
}
