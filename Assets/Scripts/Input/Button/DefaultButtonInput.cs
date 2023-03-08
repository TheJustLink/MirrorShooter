namespace MirrorShooter.Input.Button
{
    class DefaultButtonInput : IButtonInput
    {
        private readonly string _buttonName;

        public DefaultButtonInput(string buttonName) => _buttonName = buttonName;

        public bool GetButton() => UnityEngine.Input.GetButton(_buttonName);
        public bool GetButtonDown() => UnityEngine.Input.GetButtonDown(_buttonName);
        public bool GetButtonUp() => UnityEngine.Input.GetButtonUp(_buttonName);
    }
}