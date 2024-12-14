using System;
using DG.Tweening;
using Game.Misc.Animations;
using UnityEngine;

namespace Game.UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private TweenEffect _fadeInEffect;
        [SerializeField] private TweenEffect _fadeOutEffect;
        [SerializeField] private float _loadingDuration;

        private Tween _loadingTween;
        
        public void Show(Action loadingAction, Action onLoadFinished)
        {
            _fadeInEffect.Prepare();
            gameObject.SetActive(true);
            _loadingTween = DOTween.Sequence()
                .Append(_fadeInEffect.Play())
                .AppendCallback(() =>
                {
                    loadingAction();
                    _fadeOutEffect.Prepare();
                })
                .AppendInterval(_loadingDuration)
                .Append(_fadeOutEffect.Play())
                .AppendCallback(() =>
                {
                    onLoadFinished();
                    gameObject.SetActive(false);
                });
        }

        private void OnDisable()
        {
            _loadingTween?.Kill();
        }
    }
}