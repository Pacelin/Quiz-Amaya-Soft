using DG.Tweening;
using UnityEngine;

namespace Game.Misc.Animations
{
    public class ParticleEffect : TweenEffect
    {
        [SerializeField] private ParticleSystem _target;
        
        // I know that this method empty, but this effect don't have a prepare phase
        protected override void PrepareInternal() { }
        
        protected override Tween PlayInternal()
        {
            return DOTween.Sequence()
                .AppendCallback(() => _target.Play());
        }
    }
}