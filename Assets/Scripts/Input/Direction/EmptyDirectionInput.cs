namespace MirrorShooter.Input.Direction
{
    class EmptyDirectionInput<T> : IDirectionInput<T> where T : struct
    {
        public T GetDirection() => default;
        public T GetDirectionRaw() => default;
    }
}