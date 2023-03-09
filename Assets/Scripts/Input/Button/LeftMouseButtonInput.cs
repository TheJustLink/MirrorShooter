using UnityEngine;

namespace MirrorShooter.Input.Button
{
    class LeftMouseButtonInput : KeyCodeButtonInput
    {
        private const KeyCode LeftMouseButtonKeyCode = KeyCode.Mouse0;

        public LeftMouseButtonInput() : base(LeftMouseButtonKeyCode) { }
    }
}