using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Gameplay.Cards;
using Game.Gameplay.Levels;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Game.Gameplay
{
    public class LevelPresenter : IInitializable, IDisposable
    {
        private readonly GameLevelState _levelState;
        private readonly CardsGridView _cardsGridView;
        private readonly CardFactory _cardFactory;
        private readonly LevelGoalView _levelGoalView;
        
        private readonly List<CardView> _cards;
        private bool _canClick = true;
        
        public LevelPresenter(GameLevelState levelState, CardsGridView cardsGridView, 
            CardFactory cardFactory, LevelGoalView levelGoalView)
        {
            _levelState = levelState;
            _cardsGridView = cardsGridView;
            _cardFactory = cardFactory;
            _levelGoalView = levelGoalView;
            _cards = new List<CardView>();
        }
        
        public void Initialize()
        {
            _levelState.OnStart += OnStartLevel;
            _levelState.OnNext += OnNextLevel;
            _levelState.OnReset += OnResetLevel;
            _cardsGridView.OnClickCard += OnClickCard;
            _levelGoalView.CreationEffect.Prepare();
        }

        public void Dispose()
        {
            _levelState.OnStart -= OnStartLevel;
            _levelState.OnNext -= OnNextLevel;
            _levelState.OnReset -= OnResetLevel;
            _cardsGridView.OnClickCard -= OnClickCard; 
        }

        private void OnStartLevel()
        {            
            OnNextLevel();
            _cardsGridView.CardCreationSequence.SetEffects(_cards.Select(card => card.CreationEffect).ToArray());
            _cardsGridView.CardCreationSequence.Prepare();
            _cardsGridView.CardCreationSequence.Play();
            _levelGoalView.CreationEffect.Play();
        }

        private void OnNextLevel()
        {
            ResetGrid();
            
            for (int i = 0; i < _levelState.Cards.Count; i++)
            {
                var cardView = _cardFactory.Create();
                cardView.SetData(_levelState.Cards[i]);
                _cards.Add(cardView);
                _cardsGridView.PlaceCard(cardView, i);
            }
            
            _levelGoalView.SetGoal(_levelState.Cards[_levelState.GoalIndex].Identifier);
        }

        private void OnResetLevel()
        {
            ResetGrid();
            _levelGoalView.CreationEffect.Prepare();
        }
        
        private void ResetGrid()
        {
            foreach (var card in _cards)
                Object.Destroy(card.gameObject);
            _cards.Clear();
            _cardsGridView.SetGridSize(_levelState.LevelData.RowsCount, _levelState.LevelData.ColumnsCount);
        }
        
        private async void OnClickCard(int index)
        {
            if (_cardsGridView.CardCreationSequence.IsPlaying)
                return;
            if (!_canClick)
                return;

            var isCorrect = index == _levelState.GoalIndex;

            var effect = isCorrect ? _cards[index].CorrectEffect : _cards[index].IncorrectEffect;
            effect.Prepare();
            effect.Play();

            if (isCorrect)
            {
                _canClick = false;
                while (effect.IsPlaying)
                    await Task.Yield();
                _levelState.Next();
                _canClick = true;
            }
        }
    }
}
