using DG.Tweening;
using UnityEngine;

namespace Game.Misc.Animations
{
   /* public class BounceTweenEffect : TweenEffect
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _initialScale;
        [SerializeField] private float _largeScale;
        [SerializeField] private float _targetScale;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease = Ease.Linear;
    }*/
    
    public class ScaleTweenEffect : TweenEffect
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _initialScale = 0;
        [SerializeField] private float _targetScale = 1;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Ease _ease = Ease.InElastic;

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