using Game.Misc.Animations;
using TMPro;
using UnityEngine;

namespace Game.Gameplay.Levels
{
    public class LevelGoalView : MonoBehaviour
    {
        public TweenEffect CreationEffect => _creationEffect;
        
        [SerializeField] private TweenEffect _creationEffect;
        [SerializeField] private TextMeshProUGUI _goalText;
        [SerializeField] private string _goalTextFormat;

        public void SetGoal(string identifier) =>
            _goalText.text = string.Format(_goalTextFormat, identifier);
    }
}