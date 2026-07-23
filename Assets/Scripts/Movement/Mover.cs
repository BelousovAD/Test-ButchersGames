using Inputs;
using UnityEngine;

namespace Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private MonoBehaviour _inputReaderComponent;

        private IInput _input;
        private Vector3 _horizontalVelocity;

        private void OnValidate()
        {
            if (_inputReaderComponent is null)
            {
                return;
            }
            
            if (_inputReaderComponent is IInput inputReader)
            {
                _input = inputReader;
            }
            else
            {
                _inputReaderComponent = null;
                Debug.LogError($"Field:{nameof(_inputReaderComponent)} must inherited from {nameof(IInput)}");
            }
        }

        private void OnEnable() =>
            _input.MoveRequested += UpdateVelocity;

        private void OnDisable() =>
            _input.MoveRequested -= UpdateVelocity;

        private void FixedUpdate() =>
            _rigidbody.velocity = transform.rotation * _horizontalVelocity;

        private void UpdateVelocity(float direction) =>
            _horizontalVelocity = new Vector3(direction, 0f, 1f) * _speed;
    }
}