using System.Collections.Generic;
using UnityEngine;

namespace BlackHoles.Game
{
    public class EnemyGameObject : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private List<Transform> shootPoints;
        [SerializeField] private float shootDelay;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float minSpeed;

        private float? _speed;

        public float Speed => _speed ?? (_speed = Random.Range(minSpeed, maxSpeed)).Value;
        public List<Transform> ShootPoints => shootPoints;
        public float ShootDelay => shootDelay;
        
        public void Init(Sprite enemySprite)
        {
            spriteRenderer.sprite = enemySprite;
        }
    }
}