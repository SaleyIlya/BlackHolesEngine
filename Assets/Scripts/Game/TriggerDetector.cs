using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlackHoles.Game
{
    public class TriggerDetector : MonoBehaviour
    {
        private List<GameObject> _triggerEnter;
        private List<GameObject> _triggerExit;

        public List<GameObject> TriggerEnter => _triggerEnter;
        public List<GameObject> TriggerExit => _triggerExit;

        private void Start()
        {
            _triggerEnter = new List<GameObject>();
            _triggerExit = new List<GameObject>();
        }

        private void FixedUpdate()
        {
            _triggerEnter.Clear();
            _triggerExit.Clear();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _triggerEnter.Add(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _triggerExit.Add(other.gameObject);
        }
    }
}