using UnityEngine;

namespace Game.Gameplay.Cards
{
    public class CardFactory
    {
        private readonly CardView _prefab;
        private readonly Transform _parent;

        public CardFactory(CardView prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }
        
        public CardView Create() =>
            Object.Instantiate(_prefab, _parent);
    }
}