namespace MirrorShooter.Input.Button
{
    interface IButtonInput
    {
        bool GetButton();
        bool GetButtonDown();
        bool GetButtonUp();
    }
}