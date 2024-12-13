using Game.Misc.Animations;
using UnityEngine;

namespace Game.Gameplay.Cards
{
    public class CardView : MonoBehaviour
    {
        public TweenEffect CreationEffect => _creationEffect;
        public TweenEffect CorrectEffect => _correctEffect;
        public TweenEffect IncorrectEffect => _incorrectEffect;
        
        [SerializeField] private TweenEffect _creationEffect;
        [SerializeField] private TweenEffect _correctEffect;
        [SerializeField] private TweenEffect _incorrectEffect;
        [SerializeField] private SpriteRenderer _iconRenderer;

        public void SetData(CardData cardData)
        {
            _iconRenderer.sprite = cardData.Icon;
            _iconRenderer.flipX = cardData.IconFlipX;
            _iconRenderer.flipY = cardData.IconFlipY;
            _iconRenderer.transform.localScale = Vector3.one * cardData.IconScale;
            _iconRenderer.transform.rotation = Quaternion.Euler(0, 0, cardData.IconAngleZ);
        }
    }
}