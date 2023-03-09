using Mirror;

using MirrorShooter.Player.Health;

using UnityEngine;

namespace MirrorShooter.Player.Weapon.Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    class Projectile : NetworkBehaviour
    {
        [Header("References")]
        [SerializeField] private ParticleSystem _trailParticles;
        [SerializeField] private ParticleSystem _hitParticlesPrefab;
        [SerializeField] private Collider _collider;
        [Header("Parameters")]
        [SerializeField] private float _impulse = 10f;
        [SerializeField] private float _damage = 30f;

        private void Start()
        {
            var rigidbody = GetComponent<Rigidbody>();
            
            rigidbody.AddForce(transform.forward * _impulse, ForceMode.Impulse);
        }
        private void OnCollisionEnter(Collision collision)
        {
            var contactPoint =  collision.GetContact(0);
            SpawnHitParticleAt(contactPoint);

            DetachTrailParticles();
            
            Destroy(gameObject);

            if (isServer)
            {
                OnCollisionInServer(collision.gameObject);
            }
        }

        [Server]
        private void OnCollisionInServer(GameObject collisionWith)
        {
            if (collisionWith.TryGetComponent(out IDamageable damageable))
                OnCollisionWithDamageable(damageable);
        }
        [Server]
        private void OnCollisionWithDamageable(IDamageable damageable)
        {
            damageable.ApplyDamage(_damage);
        }
        
        public void IgnoreCollisionWith(Collider otherCollider)
        {   
            UnityEngine.Physics.IgnoreCollision(_collider, otherCollider);
        }
        
        private void SpawnHitParticleAt(ContactPoint contactPoint)
        {
            var rotation = Quaternion.LookRotation(contactPoint.normal);

            var hitParticles = Instantiate(_hitParticlesPrefab, contactPoint.point, rotation);
            Destroy(hitParticles.gameObject, 1f);
        }
        private void DetachTrailParticles()
        {
            _trailParticles.transform.parent = null;
            Destroy(_trailParticles.gameObject, 1f);
        }
    }
}