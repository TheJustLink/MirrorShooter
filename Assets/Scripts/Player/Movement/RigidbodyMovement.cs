using MirrorShooter.Input.Button;
using MirrorShooter.Input.Direction;
using MirrorShooter.Physics;

using UnityEngine;

namespace MirrorShooter.Player.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    class RigidbodyMovement : MonoBehaviour
    {
        [SerializeField] private SphereCast _groundCast;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _jumpForce = 5f;

        private Rigidbody _rigidbody;
        private Vector3 _inputDirection;

        private IDirectionInput<Vector2> _moveInput = new EmptyDirectionInput<Vector2>();
        private IButtonInput _jumpInput = new EmptyButtonInput();

        public void Construct(IDirectionInput<Vector2> directionInput, IButtonInput jumpInput)
        {
            _moveInput = directionInput;
            _jumpInput = jumpInput;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.freezeRotation = true;
        }

        private void Update()
        {
            _inputDirection = GetInputDirection();
        }

        private void FixedUpdate()
        {
            var movementDirection = GetMovementDirection(_inputDirection);
            Move(movementDirection);

            if (CanJump())
                Jump();
        }

        private Vector3 GetInputDirection()
        {
            var inputDirection = _moveInput.GetDirectionRaw();

            return new Vector3(inputDirection.x, 0, inputDirection.y).normalized;
        }
        private Vector3 GetMovementDirection(Vector3 inputDirection)
        {
            return transform.TransformDirection(inputDirection);
        }
        private void Move(Vector3 movementDirection)
        {
            var movementVector = movementDirection * _speed;

            _rigidbody.velocity = new Vector3(movementVector.x, _rigidbody.velocity.y, movementVector.z);
        }
        
        private bool CanJump()
        {
            return _groundCast.IsColliding()
                && _jumpInput.GetButton()
                && _rigidbody.velocity.y <= 0;
        }
        private void Jump()
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}