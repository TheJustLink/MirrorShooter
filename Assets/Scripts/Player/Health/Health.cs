using System;

using Mirror;

using MirrorShooter.Values;

using UnityEngine;

namespace MirrorShooter.Player.Health
{
    class Health : NetworkBehaviour, IDamageable, IValueWithLimit
    {
        public event Action<float> Changed;
        public event Action Death;

        public float MaxValue => _maxValue;
        public float Value => _value;

        [SerializeField] private float _maxValue;
        
        [SyncVar(hook = nameof(SyncValue))] private float _value;

        private bool _isDeath;

        public override void OnStartServer()
        {
            _value = MaxValue;
        }

        [Server]
        public void ApplyDamage(float damage)
        {
            ChangeValue(_value - damage);
        }
        [Server]
        private void ChangeValue(float value)
        {
            if (_isDeath) return;

            var newValue = Mathf.Clamp(value, 0f, _maxValue);
            if (newValue == _value) return;

            _value = newValue;
            Changed?.Invoke(newValue);

            if (_value == 0f)
            {
                _isDeath = true;
                Death?.Invoke();
            }
        }

        private void SyncValue(float oldValue, float newValue)
        {
            Changed?.Invoke(newValue);
        }
    }
}