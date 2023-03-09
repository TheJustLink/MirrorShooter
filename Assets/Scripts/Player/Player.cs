using Mirror;

using MirrorShooter.Input.Button;
using MirrorShooter.Input.Direction;
using MirrorShooter.Movement;
using MirrorShooter.Player.Movement;

using UnityEngine;

namespace MirrorShooter.Player
{
    class Player : NetworkBehaviour
    {
        public Health.Health Health => _health;

        [SerializeField] private RigidbodyMovement _rigidbodyMovement;
        [SerializeField] private Weapon.Weapon _weapon;
        [SerializeField] private Health.Health _health;
        [SerializeField] private UI.ValueWithLimitView _healthWorldView;
        [SerializeField] private LookAtDirection _lookAtForHealthWorldView;

        private IButtonInput _shootInput = new EmptyButtonInput();
        
        private void Update()
        {
            if (_shootInput.GetButtonDown())
                _weapon.Shoot();
        }
        
        public void Construct(IDirectionInput<Vector3> shootDirectionInput)
        {
            _rigidbodyMovement.Construct(new MoveDirectionInput(), new JumpButtonInput());
            _weapon.Construct(shootDirectionInput);

            _shootInput = new LeftMouseButtonInput();
        }
        public void ConstructHealthWorldUIFor(Transform targetTransform)
        {
            var directionInput = new LookToTransformDirectionInput(_healthWorldView.transform, targetTransform);
            
            _lookAtForHealthWorldView.Construct(directionInput);
            _healthWorldView.Construct(_health);
        }
    }
}