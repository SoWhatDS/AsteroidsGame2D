
using Asteroids2D.Engine.GameInput;
using Asteroids2D.Utils;
using Cinemachine;
using JoostenProductions;
using UnityEngine;


namespace Asteroids2D.Engine.Player
{
    internal sealed class PlayerController : BaseController
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private Player _player;
        private InputReader _inputReader;

        private Vector2 _direction;

        public PlayerController(PlayerModel playerModel,InputReader inputReader)
        {
            _playerView = LoadView();
            _playerModel = playerModel;
            _inputReader = inputReader;

            CinemachineVirtualCamera camera = Object.FindObjectOfType<CinemachineVirtualCamera>();
            camera.Follow = _playerView.transform;
            camera.LookAt = _playerView.transform;

            IMove Rigidbody2DMove = new AccelerationRigidbodyMove(_playerView.Rigidbody2D,_playerModel.Speed,_playerModel.Acceleration);
            IRotation RotationTransform = new RotationPlayer(_playerView.transform,_playerModel.RotationSpeed);
            IFire FireShip = new FireShip(_playerModel.BulletPrefab,_playerView.FireTransform,_playerModel.BulletForce,_playerView.transform);
            ITakeDamage TakeDamageShip = new TakeDamageShip(_playerModel.Health,_playerModel.Damage);

            _player = new Player(Rigidbody2DMove, RotationTransform,FireShip,TakeDamageShip);

            _inputReader.MoveEvent += HandleMove;
            _inputReader.AccelerateEvent += HandleAcceleration;
            _inputReader.AccelerateCanceledEvent += HandleCancelledAcceleration;
            _inputReader.FireEvent += HandleFire;

            _playerView.OnTakeDamage += TakeDamage; 

            UpdateManager.SubscribeToUpdate(Update);
            UpdateManager.SubscribeToFixedUpdate(FixedUpdate);
            
        }

        private void TakeDamage()
        {
            _player.TakeDamage();
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
            PlayerRotation();
        }

        private void FixedUpdate()
        {
            Rigidbody2DMovePlayer();
        }


        private void PlayerRotation()
        {
            _player.Rotation(_direction);
        }

        private void Rigidbody2DMovePlayer()
        {
            _player.Move(_direction);
        }

        private void HandleFire()
        {
            _player.Fire();
        }

        private void HandleMove(Vector2 direction)
        {
            _direction = direction;
        }

        private void HandleAcceleration()
        {
            _player.AddAcceleration();
        }

        private void HandleCancelledAcceleration()
        {
            _player.RemoveAcceleration();
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);
            UpdateManager.UnsubscribeFromFixedUpdate(FixedUpdate);

            _inputReader.MoveEvent -= HandleMove;
            _inputReader.AccelerateEvent -= HandleAcceleration;
            _inputReader.AccelerateCanceledEvent -= HandleCancelledAcceleration;
            _inputReader.FireEvent -= HandleFire;
        }
    }
}
