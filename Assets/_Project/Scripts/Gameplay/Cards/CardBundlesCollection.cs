using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Cards
{
    [CreateAssetMenu(menuName = "Game/Card Bundles Collection")]
    public class CardBundlesCollection : ScriptableObject, IReadOnlyList<CardBundle>
    {
        public int Count => _bundles.Length;
        
        [SerializeField] private CardBundle[] _bundles;

        public IEnumerator<CardBundle> GetEnumerator() => ((IEnumerable<CardBundle>)_bundles).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _bundles.GetEnumerator();

        public CardBundle this[int index] => _bundles[index];
    }
    public class CardBundleGenerator
    {
        private readonly CardBundlesCollection _cardBundles;
        private readonly Dictionary<CardBundle, List<CardData>> _bundlesGoals;

        public CardBundleGenerator(CardBundlesCollection cardBundles)
        {
            _cardBundles = cardBundles;
            _bundlesGoals = new Dictionary<CardBundle, List<CardData>>();
        }

        public CardData[] Generate(int count)
        {
            
        }
    }
}