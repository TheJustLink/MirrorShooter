using UnityEngine;

namespace MirrorShooter.Input.Direction
{
    interface IDirectionInput
    {
        Vector2 GetDirection();
        Vector2 GetDirectionRaw();
    }
}