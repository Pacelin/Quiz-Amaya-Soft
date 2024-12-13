using System.Collections.Generic;
using Game.Gameplay.Cards;

namespace Game.Gameplay.Levels
{
    public class GameLevelState
    {
        public int GoalIndex => _goalIndex;
        public IReadOnlyList<CardData> Cards => _cards;

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
        }
        
        public void Next()
        {
            _level++;
            InitializeLevel();
        }

        private void InitializeLevel()
        {
            _levelData = _levels[_level];
            _cards = _cardBundleGenerator.Generate(_levelData.ColumnsCount * _levelData.RowsCount, out _goalIndex);
        }
    }
}