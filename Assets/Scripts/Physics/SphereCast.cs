using UnityEngine;

namespace MirrorShooter.Physics
{
    class SphereCast : MonoBehaviour
    {
        [SerializeField] private LayerMask _mask;
        [SerializeField] private float _radius = 0.5f;

        public bool IsColliding()
        {
            return UnityEngine.Physics.CheckSphere(transform.position, _radius, _mask);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}