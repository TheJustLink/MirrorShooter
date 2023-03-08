using MirrorShooter.Input.Button;
using MirrorShooter.Input.Direction;
using MirrorShooter.Player.Movement;

using UnityEngine;

namespace MirrorShooter.Player
{
    class Player : MonoBehaviour
    {
        [SerializeField] private RigidbodyMovement _rigidbodyMovement;
        
        public void Construct()
        {
            _rigidbodyMovement.Construct(new MoveDirectionInput(), new JumpButtonInput());
        }
    }
}