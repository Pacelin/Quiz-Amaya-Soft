using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Game/Levels Collection")]
    public class LevelsCollection : ScriptableObject, IReadOnlyList<LevelData>
    {
        public int Count => _levels.Length;
        
        [SerializeField] private LevelData[] _levels;
        
        public LevelData this[int index] => _levels[index];

        public IEnumerator<LevelData> GetEnumerator() => ((IEnumerable<LevelData>)_levels).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _levels.GetEnumerator();
    }
}