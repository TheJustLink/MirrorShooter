using MirrorShooter.Input.Axis;

using UnityEngine;

namespace MirrorShooter.Input.Direction
{
    class CompositeDirectionInput : IDirectionInput
    {
        private readonly IAxisInput _axisX;
        private readonly IAxisInput _axisY;
        
        public CompositeDirectionInput(IAxisInput axisX, IAxisInput axisY) =>
            (_axisX, _axisY) = (axisX, axisY);

        public Vector2 GetDirection() => new Vector2(_axisX.GetAxis(), _axisY.GetAxis());
        public Vector2 GetDirectionRaw() => new Vector2(_axisX.GetAxisRaw(), _axisY.GetAxisRaw());
    }
}