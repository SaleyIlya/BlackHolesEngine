using UnityEngine;

namespace BlackHoles.Game
{
    public class BulletGameObject : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float speed;

        public float Speed => speed;

        public void Init(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}