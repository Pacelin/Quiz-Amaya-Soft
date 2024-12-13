using DG.Tweening;
using UnityEngine;

namespace Game.Misc.Animations
{
    public abstract class TweenEffect : MonoBehaviour
    {
        public enum RestartMode
        {
            Kill,
            Complete
        }

        public bool IsPlaying => _tween != null && _tween.IsActive();
        
        [SerializeField] private RestartMode _restartMode;
        [SerializeField] private TweenEffect[] _joinEffects;
        
        private Tween _tween;

        public void Prepare()
        {
            foreach (var effect in _joinEffects)
                effect.Prepare();
            PrepareInternal();
        }
        
        public Tween Play(float delay = 0)
        {
            _tween?.Kill(_restartMode == RestartMode.Complete);
            
            var seq = DOTween.Sequence();
            seq.Append(PlayInternal());
            
            foreach (var joinEffect in _joinEffects)
                seq.Join(joinEffect.Play(0));
            
            _tween = seq;
            
            if (delay > 0)
                _tween.SetDelay(delay);
            
            return _tween;
        }

        private void OnDisable()
        {
            _tween?.Kill(_restartMode == RestartMode.Complete);
        }

        protected abstract void PrepareInternal();
        protected abstract Tween PlayInternal();
    }
}