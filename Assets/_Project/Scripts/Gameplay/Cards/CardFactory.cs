using UnityEngine;

namespace Game.Gameplay.Cards
{
    public class CardFactory
    {
        private readonly CardView _prefab;
        private readonly Transform _parent;
        
        public CardFactory(CardView prefab, CardsGridView cardsGrid)
        {
            _prefab = prefab;
            _parent = cardsGrid.transform;
        }
        
        public CardView Create() =>
            Object.Instantiate(_prefab, _parent);
    }
}
