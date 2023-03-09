using System.Collections;

using MirrorShooter.Input.Direction;

using UnityEngine;

namespace MirrorShooter.Movement
{
    class LookAtDirection : MonoBehaviour
    {
        private IDirectionInput<Vector3> _directionInput;

        private Coroutine _coroutine;

        private void OnEnable()
        {
            _coroutine ??= StartCoroutine(LookAt());
        }
        private void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        public void Construct(IDirectionInput<Vector3> directionInput)
        {
            _directionInput = directionInput;

            OnEnable();
        }

        private IEnumerator LookAt()
        {
            while (_directionInput != null)
            {
                var direction =  _directionInput.GetDirectionRaw();
                transform.rotation = Quaternion.LookRotation(direction);

                yield return null;
            }
        }
    }
}