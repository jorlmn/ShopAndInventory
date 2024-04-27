
using System;
using UnityEngine;

namespace JOR.Shared
{
    public class WorldCollider : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        public event Action<Collider2D, bool> OnTriggerCollision;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            OnTriggerCollision?.Invoke(collider, true);
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            OnTriggerCollision?.Invoke(collider, false);
        }
    }
}
