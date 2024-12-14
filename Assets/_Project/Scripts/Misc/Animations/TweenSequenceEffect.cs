using DG.Tweening;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Misc.Animations
{
    public class TweenSequenceEffect : TweenEffect
    {
        [SerializeField] private TweenEffect[] _effects;
        [SerializeField] private float _interval;

        protected override void PrepareInternal()
        {
            foreach (var effect in _effects)
                effect.Prepare();
        }

        protected override Tween PlayInternal()
        {
            Assert.IsTrue(_effects.Length > 0);
            var seq = DOTween.Sequence()
                .Join(_effects[0].Play());
            for (int i = 1; i < _effects.Length; i++)
                seq.Join(_effects[i].Play(_interval * i));
            return seq;
        }

        public void SetEffects(TweenEffect[] effects) =>
            _effects = effects;
    }
}