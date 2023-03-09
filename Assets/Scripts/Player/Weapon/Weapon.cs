using Mirror;

using MirrorShooter.Input.Direction;
using MirrorShooter.Player.Weapon.Projectiles;

using UnityEngine;

namespace MirrorShooter.Player.Weapon
{
    class Weapon : NetworkBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private WeaponConfig _config;
        [SerializeField] private Collider _ignoreCollider;
        
        private IDirectionInput<Vector3> _directionInput = new EmptyDirectionInput<Vector3>();

        public void Construct(IDirectionInput<Vector3> directionInput)
        {
            _directionInput = directionInput;
        }

        public void Shoot()
        {
            var direction = _directionInput.GetDirectionRaw();
            CmdSpawnProjectile(direction);
        }

        [Command]
        private void CmdSpawnProjectile(Vector3 direction)
        {
            var projectile = Instantiate(_config.ProjectilePrefab, _spawnPoint.position, Quaternion.LookRotation(direction));
            projectile.IgnoreCollisionWith(_ignoreCollider);

            NetworkServer.Spawn(projectile.gameObject);
            
            RpcIgnoreCollision(projectile);
        }
        [ClientRpc]
        private void RpcIgnoreCollision(Projectile projectile)
        {
            projectile.IgnoreCollisionWith(_ignoreCollider);
        }
    }
}