using System;
using _Project.Player;
using UnityEngine;

namespace _Project.UI
{
    public class CharacterTrigger : MonoBehaviour
    {
        public event Action<Transform> Triggered;
        
        [SerializeField] private BoxCollider2D _collider;
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out PlayerInitializer player))
            {
                Triggered?.Invoke(player.transform);
            }
        }

        public void SetDistance(float distance)
        {
            _collider.size = Vector2.one * distance;
        }
    }
}