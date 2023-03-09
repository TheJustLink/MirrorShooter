using MirrorShooter.Input.Axis;

namespace MirrorShooter.Input.Direction
{
    class MouseDirectionInput : CompositeVector2DirectionInput
    {
        private const string MouseXAxisName = "Mouse X";
        private const string MouseYAxisName = "Mouse Y";
        
        public MouseDirectionInput() : base(new DefaultAxisInput(MouseXAxisName), new DefaultAxisInput(MouseYAxisName)) { }
    }
}