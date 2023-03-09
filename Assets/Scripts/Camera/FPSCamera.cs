using MirrorShooter.Input.Direction;

using UnityEngine;

namespace MirrorShooter.Camera
{
    class FPSCamera : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 50f;
        [SerializeField] private Vector3 _offset;

        private IDirectionInput<Vector2> _directionInput;
        private Transform _targetTransform;

        private float _rotationX;
        private float _rotationY;
        
        public void Construct(IDirectionInput<Vector2> directionInput, Transform targetTransformTransform)
        {
            _directionInput = directionInput;
            _targetTransform = targetTransformTransform;
        }

        public void Update()
        {
            if (CanUpdate() == false)
                return;

            UpdatePosition();

            var inputDirection = _directionInput.GetDirectionRaw();
            var inputVector = inputDirection * Time.deltaTime * _sensitivity;
            
            UpdateRotationsBy(inputVector);
            ApplyRotation(_rotationX, _rotationY);
        }

        private bool CanUpdate()
        {
            return _directionInput != null
                && _targetTransform != null;
        }
        private void UpdatePosition()
        {
            transform.position = _targetTransform.position + _offset;
        }
        private void UpdateRotationsBy(Vector2 inputVector)
        {
            _rotationX -= inputVector.y;
            _rotationY += inputVector.x;

            _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
        }
        private void ApplyRotation(float rotationX, float rotationY)
        {
            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
            _targetTransform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        }
    }
}