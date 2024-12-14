using System;
using Game.Misc.Animations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
    public class LevelFinishUI : MonoBehaviour
    {
        public event Action OnRestartClicked
        {
            add => _restartButton.onClick.AddListener(new UnityAction(value));
            remove => _restartButton.onClick.RemoveListener(new UnityAction(value));
        }

        public TweenEffect ShowingEffect => _showingEffect;
        
        [SerializeField] private Button _restartButton;
        [SerializeField] private TweenEffect _showingEffect;
    }
}
