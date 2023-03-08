using UnityEngine;

namespace MirrorShooter.Input.Button
{
    class KeyCodeButtonInput : IButtonInput
    {
        private readonly KeyCode _keyCode;

        public KeyCodeButtonInput(KeyCode keyCode) => _keyCode = keyCode;

        public bool GetButton() => UnityEngine.Input.GetKey(_keyCode);
        public bool GetButtonDown() => UnityEngine.Input.GetKeyDown(_keyCode);
        public bool GetButtonUp() => UnityEngine.Input.GetKeyUp(_keyCode);
    }
}