using DG.Tweening;
using UnityEngine;

namespace Game.Misc.Animations
{
    public class ScaleTweenEffect : TweenEffect
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _initialScale = 0;
        [SerializeField] private float _targetScale = 1;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Ease _ease = Ease.InBounce;

        protected override void PrepareInternal() =>
            _target.localScale = Vector3.one * _initialScale;

        protected override Tween PlayInternal()
        {
            return _target.DOScale(_targetScale, _duration)
                .SetEase(_ease)
                .SetTarget(_target);
        }
    }
}