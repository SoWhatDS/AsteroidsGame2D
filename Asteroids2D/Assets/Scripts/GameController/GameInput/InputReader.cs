using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInput;

namespace Asteroids2D.Engine.GameInput
{
    [CreateAssetMenu(fileName = nameof(InputReader), menuName = "Settings/ " + nameof(InputReader))]
    internal sealed class InputReader : ScriptableObject, IGameplayActions, IUIActions
    {
        private PlayerInput _playerInput;

        public event Action<Vector2> MoveEvent;

        public event Action AccelerateEvent;
        public event Action AccelerateCanceledEvent;

        public event Action PauseEvent;
        public event Action ResumeEvent;

        public event Action FireEvent;

        private void OnEnable()
        {
            if (_playerInput == null)
            {
                _playerInput = new PlayerInput();

                _playerInput.Gameplay.SetCallbacks(this);
                _playerInput.UI.SetCallbacks(this);

                SetGameplay();
            }
        }

        public void SetGameplay()
        {
            _playerInput.Gameplay.Enable();
            _playerInput.UI.Disable();
        }

        public void SetUI()
        {
            _playerInput.Gameplay.Disable();
            _playerInput.UI.Enable();
        }

        public void OnAccelerate(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                AccelerateEvent?.Invoke();
            }
            if (context.canceled)
            {
                AccelerateCanceledEvent?.Invoke();
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                PauseEvent?.Invoke();
                SetUI();
            }
        }

        public void OnResume(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                ResumeEvent?.Invoke();
                SetGameplay();
            }
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                FireEvent?.Invoke();
            }
        }
    }
}
