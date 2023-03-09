﻿using MirrorShooter.Input.Button;
using MirrorShooter.Input.Direction;
using MirrorShooter.Player.Movement;

using UnityEngine;

namespace MirrorShooter.Player
{
    class Player : MonoBehaviour
    {
        [SerializeField] private RigidbodyMovement _rigidbodyMovement;
        [SerializeField] private Weapon.Weapon _weapon;

        private IButtonInput _shootInput = new EmptyButtonInput();

        public void Construct(IDirectionInput<Vector3> shootDirectionInput)
        {
            _rigidbodyMovement.Construct(new MoveDirectionInput(), new JumpButtonInput());
            _weapon.Construct(shootDirectionInput);

            _shootInput = new LeftMouseButtonInput();
        }

        private void Update()
        {
            if (_shootInput.GetButtonDown())
                _weapon.Shoot();
        }
    }
}