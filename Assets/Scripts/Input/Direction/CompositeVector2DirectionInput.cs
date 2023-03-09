using MirrorShooter.Input.Axis;

using UnityEngine;

namespace MirrorShooter.Input.Direction
{
    class CompositeVector2DirectionInput : IDirectionInput<Vector2>
    {
        private readonly IAxisInput _axisX;
        private readonly IAxisInput _axisY;
        
        public CompositeVector2DirectionInput(IAxisInput axisX, IAxisInput axisY) =>
            (_axisX, _axisY) = (axisX, axisY);

        public Vector2 GetDirection() => new Vector2(_axisX.GetAxis(), _axisY.GetAxis());
        public Vector2 GetDirectionRaw() => new Vector2(_axisX.GetAxisRaw(), _axisY.GetAxisRaw());
    }
}