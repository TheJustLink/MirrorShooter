using UnityEngine;

namespace MirrorShooter.Input.Direction
{
    class LookToTransformDirectionInput : IDirectionInput<Vector3>
    {
        private readonly Transform _selfTransform;
        private readonly Transform _targetTransform;

        public LookToTransformDirectionInput(Transform selfTransform, Transform targetTransform) =>
            (_selfTransform, _targetTransform) = (selfTransform, targetTransform);

        public Vector3 GetDirection()
        {
            return GetDirectionRaw();
        }
        public Vector3 GetDirectionRaw()
        {
            var vector = _targetTransform.position - _selfTransform.position;
            var direction = vector.normalized;

            return direction;
        }
    }
}
