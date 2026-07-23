using System;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
    internal class PlayerInput : MonoBehaviour, IInput
    {
        private Input _input;

        public event Action<float> MoveRequested;

        [Inject]
        private void Initialize(Input input) =>
            _input = input;

        public void OnEnable()
        {
            _input.Enable();
            _input.Player.Move.performed += RequestMove;
            _input.Player.Move.canceled += RequestMove;
        }

        public void OnDisable()
        {
            _input.Disable();
            _input.Player.Move.performed -= RequestMove;
            _input.Player.Move.canceled -= RequestMove;
        }

        private void RequestMove(InputAction.CallbackContext context) =>
            MoveRequested?.Invoke(context.ReadValue<Vector2>().x);
    }
}