using System;
using UnityEngine;

namespace BlackHoles.Menu
{
    public class MenuBullet : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float speed;

        public void Init(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

        private void Update()
        {
            transform.position += Vector3.up * (speed * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
    }
}