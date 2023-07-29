using UnityEngine;

namespace _Project.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private float _speed;

        private void Update()
        {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
        }

        public void SetSpeed(float moveSpeed)
        {
            _speed = moveSpeed;
        }
    }
}