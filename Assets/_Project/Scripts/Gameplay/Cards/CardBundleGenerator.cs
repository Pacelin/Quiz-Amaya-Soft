using System.Collections.Generic;
using Game.Misc;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Gameplay.Cards
{
    public class CardBundleGeneratorNoRepeat : ICardBundleGenerator
    {
        private readonly CardBundlesCollection _cardBundles;
        private readonly List<CardData>[] _bundlesGoals;

        public CardBundleGeneratorNoRepeat(CardBundlesCollection cardBundles)
        {
            _cardBundles = cardBundles;
            _bundlesGoals = new List<CardData>[_cardBundles.Count];
            for (int i = 0; i < _bundlesGoals.Length; i++)
                _bundlesGoals[i] = new List<CardData>();
        }

        public CardData[] Generate(int count, out int goalIndex)
        {
            var randomBundleIndex = Random.Range(0, _cardBundles.Count);
            if (_bundlesGoals[randomBundleIndex].Count == 0)
                FillGoals(randomBundleIndex);

            var cards = new List<CardData>(_cardBundles[randomBundleIndex].Cards);
            cards.Shuffle();
            var goals = _bundlesGoals[randomBundleIndex];
            
            var result = new CardData[count];
            var goal = goals[goals.Count - 1];
            goals.RemoveAt(goals.Count - 1);
            
            goalIndex = Random.Range(0, count);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = cards[i];
                if (result[i] == goal)
                    goalIndex = i;
            }
            result[goalIndex] = goal;

            return result;
        }

        private void FillGoals(int bundleIndex)
        {
            Assert.IsTrue(_bundlesGoals[bundleIndex].Count == 0);
            
            _bundlesGoals[bundleIndex].AddRange(_cardBundles[bundleIndex].Cards);
            _bundlesGoals[bundleIndex].Shuffle();
        }
    }
}