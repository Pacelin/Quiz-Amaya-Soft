using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game.Misc.Animations
{
    public class TextFadeTweenEffect : TweenEffect
    {
        [SerializeField] private TextMeshProUGUI _target;
        [SerializeField] private float _initialAlpha = 0;
        [SerializeField] private float _targetAlpha = 1;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Ease _ease = Ease.Linear;

        protected override void PrepareInternal() =>
            _target.alpha = _initialAlpha;

        protected override Tween PlayInternal()
        {
            return _target.DOFade(_targetAlpha, _duration)
                .SetTarget(_target)
                .SetEase(_ease);
        }
    }
}