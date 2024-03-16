using System.Collections;
using System.Collections.Generic;
using Asteroids2D.Utils;
using JoostenProductions;
using UnityEngine;

namespace Asteroids2D.Engine.Player
{
    internal sealed class PlayerController : BaseController
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;

        private IMove _moveTransform;
        private IRotation _rotationTransform;

        public PlayerController(PlayerModel playerModel)
        {
            _playerView = LoadView();
            _playerModel = playerModel;

            _moveTransform = new AccelerationMove(_playerView.transform,_playerModel.Speed,_playerModel.Acceleration);
            _rotationTransform = new RotationPlayer(_playerView.transform);

            UpdateManager.SubscribeToUpdate(Update);
            
        }

        private PlayerView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.PLAYER_VIEW);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);
            return ResourceLoader.GetOrAddComponent<PlayerView>(objectView);
        }

        private void Update()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            _moveTransform.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.AddAcceleration();
                }
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.RemoveAcceleration();
                }
            }
        }

        private void PlayerRotation()
        {

        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);
        }
    }
}
