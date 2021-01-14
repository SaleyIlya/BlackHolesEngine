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
            transform.localPosition = Vector3.zero;
            spriteRenderer.sprite = sprite;
        }

        private void Update()
        {
            transform.position += Vector3.up * (speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
        }
    }
}