using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Cards
{
    [CreateAssetMenu(menuName = "Game/Card Bundle")]
    public class CardBundle : ScriptableObject
    {
        public IReadOnlyList<CardData> Cards => _cards;

        [SerializeField] private CardData[] _cards;
    }
}