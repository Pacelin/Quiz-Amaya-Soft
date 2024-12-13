using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Game.Misc
{
    public static class ArrayExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count * list.Count; j++)
                {
                    var randomIndex = Random.Range(0, list.Count);
                    (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
                }
            }
        }
    }
}