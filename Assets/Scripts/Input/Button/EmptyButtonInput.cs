namespace MirrorShooter.Input.Button
{
    class EmptyButtonInput : IButtonInput
    {
        public bool GetButton() => false;
        public bool GetButtonDown() => false;
        public bool GetButtonUp() => false;
    }
}