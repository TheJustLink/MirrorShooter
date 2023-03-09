using UnityEngine;

namespace MirrorShooter.Input.Direction
{
    class LookTransformForwardDirectionInput : IDirectionInput<Vector3>
    {
        private readonly Transform _transform;
        public LookTransformForwardDirectionInput(Transform transform) => _transform = transform;

        public Vector3 GetDirection() => GetDirectionRaw();
        public Vector3 GetDirectionRaw() => _transform.forward;
    }
}