using System;

namespace MirrorShooter.Values
{
    interface IValue
    {
        event Action<float> Changed;
        float Value { get; }
    }
}