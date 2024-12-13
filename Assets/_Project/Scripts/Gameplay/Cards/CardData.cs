using UnityEngine;

namespace Game.Gameplay.Cards
{
    [System.Serializable]
    public class CardData
    {
        public string Identifier => _identifier;
        
        public Sprite Icon => _icon;
        
        public float IconScale => _iconScale;
        public float IconAngleZ => _iconAngleZ;
        public bool IconFlipX => _iconFlipX;
        public bool IconFlipY => _iconFlipY;
        
        [SerializeField] private string _identifier;
        [Space]
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _iconScale = 1;
        [SerializeField] private float _iconAngleZ;
        [SerializeField] private bool _iconFlipX;
        [SerializeField] private bool _iconFlipY;
    }
}