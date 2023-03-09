using MirrorShooter.Values;

using UnityEngine;
using UnityEngine.UI;

namespace MirrorShooter.UI
{
    class ValueWithLimitView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _fillImage;
        [SerializeField] private Gradient _colorGradient;

        private IValueWithLimit _valueWithLimit;
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponentInParent<Canvas>();

            var color = _colorGradient.Evaluate(_slider.value);
            _fillImage.CrossFadeColor(color, 0f, true, true);
        }
        private void OnEnable()
        {
            if (_valueWithLimit != null)
                _valueWithLimit.Changed += OnValueWithLimitChanged;
        }
        private void OnDisable()
        {
            if (_valueWithLimit != null)
                _valueWithLimit.Changed -= OnValueWithLimitChanged;
        }

        public void Construct(IValueWithLimit valueWithLimit)
        {
            _valueWithLimit = valueWithLimit;

            _valueWithLimit.Changed += OnValueWithLimitChanged;
            OnValueWithLimitChanged(valueWithLimit.Value);
        }

        public void Show()
        {
            _canvas.enabled = true;
        }
        public void Hide()
        {
            _canvas.enabled = false;
        }

        private void OnValueWithLimitChanged(float value)
        {
            var progress = value / _valueWithLimit.MaxValue;
            var color = _colorGradient.Evaluate(progress);

            _slider.value = progress;
            _fillImage.CrossFadeColor(color, 0.1f, true, false);
        }
    }
}