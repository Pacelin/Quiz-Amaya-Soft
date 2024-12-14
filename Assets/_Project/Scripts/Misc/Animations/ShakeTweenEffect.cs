using DG.Tweening;
using UnityEngine;

namespace Game.Misc.Animations
{
    public class ShakeTweenEffect : TweenEffect
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Vector3 _strength;
        [SerializeField] private Ease _ease = Ease.Linear;
        
        // I know that this method empty, but this effect don't have a prepare phase
        protected override void PrepareInternal() { }
        
        protected override Tween PlayInternal()
        {
            return _target.DOShakePosition(_duration, _strength)
                .SetTarget(_target)
                .SetEase(_ease);
        }
    }
}