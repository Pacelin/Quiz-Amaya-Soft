using UnityEngine;

namespace Game.Gameplay.Cards
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _backgroundRenderer;
        [SerializeField] private SpriteRenderer _iconRenderer;

        public void SetBackgroundColor(Color color)
        {
            _backgroundRenderer.color = color;
        }
        
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