using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace Game.Misc
{
    public class GameObjectGrid : MonoBehaviour, IPointerClickHandler
    {
        public event Action<int> OnCellClick;
        
        [SerializeField] private Vector2 _cellSize;
        [SerializeField] private Vector2 _cellSpacing;
        [SerializeField] private int _rowsCount;
        [SerializeField] private int _columnsCount;
        [Space] 
        [SerializeField] private BoxCollider2D _gridCollider;
        [SerializeField] private SpriteRenderer _gridSprite;

        private Bounds _bounds;

        private void Awake() => RecalculateBounds();

        public void SetGridSize(int rows, int columns)
        {
            _rowsCount = rows;
            _columnsCount = columns;
            RecalculateBounds();
        }

        public void PlaceInGrid(Transform cellTransform, int index)
        {
            Assert.IsTrue(index >= 0 && index < _rowsCount * _columnsCount);
            
            var row = index / _columnsCount;
            var column = index % _columnsCount;
            var xOffset = _bounds.min.x + column * (_cellSpacing.x + _cellSize.x) + 
                          _cellSpacing.x + _cellSize.x * 0.5f;
            var yOffset = _bounds.min.y + row * (_cellSpacing.y + _cellSize.y) + 
                          _cellSpacing.y + _cellSize.y * 0.5f;
            cellTransform.position = transform.position + new Vector3(xOffset, yOffset);
        }
        
        private void RecalculateBounds()
        {
            var size = new Vector2(_cellSize.x * _columnsCount + _cellSpacing.x * (_columnsCount + 1),
                _cellSize.y * _rowsCount + _cellSpacing.y * (_rowsCount + 1));
            _bounds = new Bounds(transform.position, size);

            _gridSprite.size = size;
            _gridCollider.size = size;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            var point = eventData.pointerCurrentRaycast.worldPosition;
            var xHit = point.x - _bounds.min.x;
            var yHit = point.y - _bounds.min.y;
            var column = (int) Mathf.Clamp(xHit / (_cellSize.x + _cellSpacing.x), 0, _columnsCount - 1);
            var row = (int) Mathf.Clamp(yHit / (_cellSize.y + _cellSpacing.y), 0, _rowsCount - 1);
            OnCellClick?.Invoke(row * _columnsCount + column);
        }
    }
}