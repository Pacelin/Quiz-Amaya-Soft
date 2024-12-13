﻿using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Levels
{
    [System.Serializable]
    public class LevelData
    {
        public int RowsCount => _rowsCount;
        public int ColumnsCount => _columnsCount;
        
        [SerializeField] private int _rowsCount;
        [SerializeField] private int _columnsCount;
    }
}