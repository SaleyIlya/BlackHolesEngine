using System.Collections.Generic;
using UnityEngine;

namespace BlackHoles.Game
{
    public class BossGameObject : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float speed;
        [SerializeField] private List<Transform> shootPoints;
        [SerializeField] private float shootDelay;
        [SerializeField] private int hp;

        public List<Transform> ShootPoints => shootPoints;
        public float Speed => speed;
        public float ShootDelay => shootDelay;
        public int Hp => hp;

        public void Init(Sprite bossSprite)
        {
            spriteRenderer.sprite = bossSprite;
        }
    }
}