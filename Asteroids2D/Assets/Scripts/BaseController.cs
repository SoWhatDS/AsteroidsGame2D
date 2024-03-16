using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids2D
{
    internal abstract class BaseController :IDisposable
    {
        private List<GameObject> _gameObjectsInGameList;
        private List<BaseController> _baseControllerInGameList;
        private bool _isDispose;

        public void Dispose()
        {
            if (_isDispose)
            {
                return;
            }

            OnDispose();
            DisposeAllControllers();
            DisposeAllGameObjects();
            _isDispose = true;

        }

        protected virtual void OnDispose() { }

        protected void AddGameObject(GameObject gameObject)
        {
            _gameObjectsInGameList ??= new List<GameObject>();

            _gameObjectsInGameList.Add(gameObject);
        }

        protected void AddController(BaseController baseController)
        {
            _baseControllerInGameList ??= new List<BaseController>();

            _baseControllerInGameList.Add(baseController);
        }

        private void DisposeAllGameObjects()
        {
            if (_gameObjectsInGameList == null)
            {
                return;
            }

            foreach (GameObject gameObject in _gameObjectsInGameList)
            {
                Object.Destroy(gameObject);
            }

            _gameObjectsInGameList.Clear();
        }

        private void DisposeAllControllers()
        {
            if (_baseControllerInGameList == null)
            {
                return;
            }

            foreach (BaseController baseController in _baseControllerInGameList)
            {
                baseController.Dispose();
            }

            _baseControllerInGameList.Clear();
        }
    }
}
