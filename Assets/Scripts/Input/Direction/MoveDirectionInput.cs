using MirrorShooter.Input.Axis;

namespace MirrorShooter.Input.Direction
{
    class MoveDirectionInput : CompositeDirectionInput
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        public MoveDirectionInput()
            : base(new DefaultAxisInput(HorizontalAxis), new DefaultAxisInput(VerticalAxis)) { }
    }
}
