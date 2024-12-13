using System;
using System.Collections.Generic;
using Game.Gameplay.Cards;
using UnityEngine;
using VContainer.Unity;

namespace Game.Gameplay.Levels
{
    public class GameLevelState : IStartable
    {
        public event Action OnStart;
        public event Action OnNext;
        public event Action OnFinish;

        public int GoalIndex => _goalIndex;
        public IReadOnlyList<CardData> Cards => _cards;
        public LevelData LevelData => _levelData;

        private readonly CardBundleGenerator _cardBundleGenerator;
        private readonly LevelsCollection _levels;

        private int _level;
        private LevelData _levelData;

        private int _goalIndex;
        private CardData[] _cards;
        
        public GameLevelState(CardBundleGenerator cardBundleGenerator, LevelsCollection levels)
        {
            _cardBundleGenerator = cardBundleGenerator;
            _levels = levels;
        }

        public void Start()
        {
            _level = 0;
            InitializeLevel();
            OnStart?.Invoke();
        }
        
        public void Next()
        {
            if (_level < _levels.Count - 1)
            {
                _level++;
                InitializeLevel();
                OnNext?.Invoke();
            }
            else
                OnFinish?.Invoke();
        }

        private void InitializeLevel()
        {
            _levelData = _levels[_level];
            _cards = _cardBundleGenerator.Generate(_levelData.ColumnsCount * _levelData.RowsCount, out _goalIndex);
        }
    }
}