using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.ChuongScripts
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Slicing : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Texture2D texture;
        [SerializeField] private Vector2 pivot = new(0.5f, 0.5f);
        [Range(0, 0.5f)] [SerializeField] private float left = 0.5f, right = 0.5f;

        private void OnValidate()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

#if TEST_CUTTING
        private void Update()
        {
            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetPercent(point.x, out var leftPercent, out var rightPercent);
            Cutting(leftPercent, rightPercent);
        }
#endif

        [Button]
        public void LoadSprite()
        {
            Cutting(0.5f, 0.5f);
        }
        
        public void GetPercent(float xPos, out float leftPercent, out float rightPercent)
        {
            var width = texture.width / _spriteRenderer.sprite.pixelsPerUnit;
            width = _spriteRenderer.transform.lossyScale.x * width;
            var xCenter = transform.position.x;
            
            if (xPos >= transform.position.x)
            {
                rightPercent = (xPos - xCenter) / width;
                leftPercent = 0.5f;
            }
            else
            {
                leftPercent = (xCenter - xPos) / width;
                rightPercent = 0.5f;
            }
        }

        [Button]
        //percent from mid
        public void Cutting(float leftPercent, float rightPercent, float botPercent = 0.5f, float topPercent = 0.5f)
        {
            if (leftPercent >= 0.5f) leftPercent = 0.5f;
            var removeLeftPercent = 0.5f - leftPercent;
            if (rightPercent >= 0.5f) rightPercent = 0.5f;
            var removeRightPercent  = 0.5f - rightPercent;
            if (botPercent >= 0.5f) botPercent = 0.5f;
            var removeBotPercent  = 0.5f - botPercent;
            if (topPercent >= 0.5f) topPercent = 0.5f;
            var removeTopPercent  = 0.5f - topPercent;
            var x = texture.width * removeLeftPercent;
            var y = texture.height * removeBotPercent;
            var width = texture.width * (1f - removeLeftPercent - removeRightPercent);
            var height = texture.height * (1f - removeTopPercent - removeBotPercent);
            var rect = new Rect(x, y, width, height);
            var cuttingPivot = pivot;
            if(leftPercent + rightPercent > 0)
            {
                cuttingPivot.x = (pivot.x - removeLeftPercent) / (leftPercent + rightPercent);
            }

            if(botPercent + topPercent > 0)
            {
                cuttingPivot.y = (pivot.y - removeBotPercent) / (botPercent + topPercent);
            }
            _spriteRenderer.sprite = Sprite.Create(texture, rect, cuttingPivot);
        }
    }
}