using MirrorShooter.Player.Weapon.Projectiles;

using UnityEngine;

namespace MirrorShooter.Player.Weapon
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Game/Weapon/Config")]
    class WeaponConfig : ScriptableObject
    {
        [field: SerializeField] public Projectile ProjectilePrefab { get; private set; }
    }
}