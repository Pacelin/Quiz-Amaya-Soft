using System;
using System.Collections.Generic;
using Game.Gameplay.Cards;
using VContainer.Unity;

namespace Game.Gameplay.Levels
{
    public class GameLevelState : IStartable
    {
        public event Action OnStart;
        public event Action OnNext;
        public event Action OnFinish;
        public event Action OnReset;
        
        public int GoalIndex => _goalIndex;
        public IReadOnlyList<CardData> Cards => _cards;
        public LevelData LevelData => _levelData;

        private readonly ICardBundleGenerator _cardBundleGenerator;
        private readonly LevelsCollection _levels;

        private int _level;
        private LevelData _levelData;

        private int _goalIndex;
        private CardData[] _cards;
        
        public GameLevelState(ICardBundleGenerator cardBundleGenerator, LevelsCollection levels)
        {
            _cardBundleGenerator = cardBundleGenerator;
            _levels = levels;
            _level = 0;
            _levelData = _levels[_level];
        }

        public void Start()
        {
            GenerateLevel();
            OnStart?.Invoke();
        }
        
        public void Next()
        {
            if (_level < _levels.Count - 1)
            {
                _levelData = _levels[++_level];
                GenerateLevel();
                OnNext?.Invoke();
            }
            else
                OnFinish?.Invoke();
        }

        public void Reset()
        {
            _level = 0;
            _levelData = _levels[_level];
            OnReset?.Invoke();
        }
        
        private void GenerateLevel() =>
            _cards = _cardBundleGenerator.Generate(_levelData.ColumnsCount * _levelData.RowsCount, out _goalIndex);
    }
}