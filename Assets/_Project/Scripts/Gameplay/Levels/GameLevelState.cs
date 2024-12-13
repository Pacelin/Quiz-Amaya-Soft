using System.Collections.Generic;
using Game.Gameplay.Cards;

namespace Game.Gameplay.Levels
{
    
    public class GameLevelState
    {
        private readonly CardBundlesCollection _cardBundles;
        private readonly LevelsCollection _levels;

        private readonly Dictionary<CardBundle, List<CardData>> _bundlesGoals;
        
        private int _rowsCount;
        private int _columnsCount;
        private int _level;
        private CardData[] _cards;
        
        public GameLevelState(CardBundlesCollection cardBundles, LevelsCollection levels)
        {
            _cardBundles = cardBundles;
            _levels = levels;

            _bundlesGoals = new Dictionary<CardBundle, List<CardData>>();
            _level = 0;
        }

        public void Next()
        {
            var levelData = _levels[_level++];
            _rowsCount = levelData.RowsCount;
            _columnsCount = levelData.ColumnsCount;
            _cards = new CardData[_rowsCount * _columnsCount];
            
        }
    }
}