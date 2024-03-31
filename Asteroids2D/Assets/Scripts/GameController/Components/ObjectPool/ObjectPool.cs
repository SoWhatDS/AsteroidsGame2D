using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids2D.Engine.ObjectPool
{
    internal sealed class ObjectPool : IDisposable
    {
        private readonly Stack<GameObject> _stack;
        private readonly Transform _root;
        private readonly GameObject _prefab;

        public ObjectPool(GameObject prefab)
        {
            _stack = new Stack<GameObject>();
            _prefab = prefab;
            _root = new GameObject($"[{_prefab.name}]").transform;

        }

        public GameObject Pop()
        {
            GameObject go;

            if (_stack.Count == 0)
            {
                go = Object.Instantiate(_prefab);
                go.name = _prefab.name;
            }
            else
            {
                go = _stack.Pop();
            }

            go.SetActive(true);
            go.transform.SetParent(null);
            return go;
        }

        public GameObject Pop(Transform prefabInstantiateTransform)
        {
            GameObject go;

            if (_stack.Count == 0)
            {
                go = Object.Instantiate(_prefab,prefabInstantiateTransform);
                go.name = _prefab.name;
            }
            else
            {
                go = _stack.Pop();
            }

            go.SetActive(true);
            go.transform.SetParent(null);
            return go;
        }

        public void Push(GameObject prefab)
        {
            _stack.Push(prefab);
            prefab.transform.SetParent(_root);
            prefab.SetActive(false);
        }

        public void Dispose()
        {
            GameObject go;

            for (int i = 0; i < _stack.Count; i++)
            {
                go = _stack.Pop();
                Object.Destroy(go);
            }

            Object.Destroy(_root);
            _stack.Clear();
        }
    }
}
