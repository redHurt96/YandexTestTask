using System;
using _Project.Infrastructure;
using UnityEngine;

namespace _Project.Player
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private float _speed;

        private void Update()
        {
            if (GameInput.JumpButtonPressed)
            {
                Jump();
            }
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        private void Jump() 
        {
            _rigidbody.velocity += Vector2.up * _speed * Time.deltaTime;
        }
    }
}
