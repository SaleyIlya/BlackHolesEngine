using UnityEngine;

namespace BlackHoles.Game
{
    public class WallGameObject : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void Init(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}