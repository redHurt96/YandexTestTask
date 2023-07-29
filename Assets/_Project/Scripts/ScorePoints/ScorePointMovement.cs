using _Project.UI;
using UnityEngine;

namespace _Project.ScorePoints
{
    public class ScorePointMovement : MonoBehaviour
    {
        [SerializeField] private CharacterTrigger _trigger;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;
        
        private Transform _player;

        public void Init(float speed, float distance)
        {
            _speed = speed;
            _trigger.SetDistance(distance);
        }
        
        private void Start()
        {
            _trigger.Triggered += SetupPlayer;
        }

        private void OnDestroy()
        {
            _trigger.Triggered -= SetupPlayer;
        }

        private void Update()
        {
            if (_player != null)
                _rigidbody.velocity = (_player.position - transform.position).normalized * _speed;
        }

        private void SetupPlayer(Transform transform)
        {
            _player = transform;
        }
    }
}