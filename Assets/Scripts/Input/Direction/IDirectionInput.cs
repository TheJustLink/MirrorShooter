using UnityEngine;

namespace MirrorShooter.Input.Direction
{
    interface IDirectionInput<out T> where T : struct
    {
        T GetDirection();
        T GetDirectionRaw();
    }
}