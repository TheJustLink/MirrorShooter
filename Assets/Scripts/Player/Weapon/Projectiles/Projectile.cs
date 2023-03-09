using Mirror;

using UnityEngine;

namespace MirrorShooter.Player.Weapon.Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    class Projectile : NetworkBehaviour
    {
        [SerializeField] private float _impulse = 10f;
        [SerializeField] private ParticleSystem _trailParticles;
        [SerializeField] private ParticleSystem _hitParticlesPrefab;
        [SerializeField] private Collider _collider;
        
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