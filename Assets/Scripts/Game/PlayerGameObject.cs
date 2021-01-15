using System.Collections.Generic;
using UnityEngine;

namespace BlackHoles.Game
{
    public class PlayerGameObject : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private List<Transform> shootPoints;
        [SerializeField] private float speed;
        [SerializeField] private float shootDelay;

        public List<Transform> ShootPoints => shootPoints;
        public float Speed => speed;

        public float ShootDelay => shootDelay;

        public void Init(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}