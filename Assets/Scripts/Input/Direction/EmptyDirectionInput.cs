using UnityEngine;

namespace MirrorShooter.Input.Direction
{
    class EmptyDirectionInput : IDirectionInput
    {
        public Vector2 GetDirection() => Vector2.zero;
        public Vector2 GetDirectionRaw() => Vector2.zero;
    }
}