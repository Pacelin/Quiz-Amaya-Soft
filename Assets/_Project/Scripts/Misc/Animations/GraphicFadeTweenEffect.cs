using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Misc.Animations
{
    public class GraphicFadeTweenEffect : TweenEffect
    {
        [SerializeField] private Graphic _target;
        [SerializeField] private Color _initialColor;
        [SerializeField] private Color _targetColor;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Ease _ease = Ease.Linear;

        protected override void PrepareInternal() =>
            _target.color = _initialColor;

        protected override Tween PlayInternal()
        {
            return _target.DOColor(_targetColor, _duration)
                .SetTarget(_target)
                .SetEase(_ease);
        }
    }
}