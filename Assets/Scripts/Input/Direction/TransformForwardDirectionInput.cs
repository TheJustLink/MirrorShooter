using UnityEngine;

namespace MirrorShooter.Input.Direction
{
    class TransformForwardDirectionInput : IDirectionInput<Vector3>
    {
        private readonly Transform _transform;
        public TransformForwardDirectionInput(Transform transform) => _transform = transform;

        public Vector3 GetDirection() => GetDirectionRaw();
        public Vector3 GetDirectionRaw() => _transform.forward;
    }
}