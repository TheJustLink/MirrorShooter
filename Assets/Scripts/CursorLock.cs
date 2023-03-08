using MirrorShooter.Input.Button;

using UnityEngine;

namespace MirrorShooter
{
    class CursorLock : MonoBehaviour
    {
        private IButtonInput _switchLockButtonInput = new KeyCodeButtonInput(KeyCode.Escape);
        
        private void Update()
        {
            if (IsEscapePressed())
            {
                SwitchLock();
            }
        }

        private void OnEnable()
        {
            Lock();
        }
        private void OnDisable()
        {
            Unlock();
        }

        public void Construct(IButtonInput switchLockButtonInput)
        {
            _switchLockButtonInput = switchLockButtonInput;
        }
        public void Enable()
        {
            enabled = true;
        }
        public void Disable()
        {
            enabled = false;
        }

        private void SwitchLock()
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Unlock();
            }
            else
            {
                Lock();
            }
        }
        private void Lock()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        private void Unlock()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        private bool IsEscapePressed()
        {
            return _switchLockButtonInput.GetButtonDown();
        }
    }
}