namespace MirrorShooter.Input.Axis
{
    class DefaultAxisInput : IAxisInput
    {
        private readonly string _axisName;
        public DefaultAxisInput(string axisName) => _axisName = axisName;

        public float GetAxis() => UnityEngine.Input.GetAxis(_axisName);
        public float GetAxisRaw() => UnityEngine.Input.GetAxisRaw(_axisName);
    }
}