using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer.Unity;

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
}