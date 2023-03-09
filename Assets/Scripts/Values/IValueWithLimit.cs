namespace MirrorShooter.Values
{
    interface IValueWithLimit : IValue
    {
        float MaxValue { get; }
    }
}