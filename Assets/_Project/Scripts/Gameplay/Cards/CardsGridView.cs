using System;
using Game.Misc;
using Game.Misc.Animations;
using UnityEngine;

namespace Game.Gameplay.Cards
{
    public class CardsGridView : MonoBehaviour
    {
        public event Action<int> OnClickCard
        {
            add => _grid.OnCellClick += value;
            remove => _grid.OnCellClick -= value;
        }

        public TweenSequenceEffect CardCreationSequence => _cardCreationSequence;
        
        [SerializeField] private GameObjectGrid _grid;
        [SerializeField] private TweenSequenceEffect _cardCreationSequence;
        
        public void SetGridSize(int rowsCount, int columnsCount) =>
            _grid.SetGridSize(rowsCount, columnsCount);
        public void PlaceCard(CardView card, int index) =>
            _grid.PlaceInGrid(card.transform, index);
    }
}