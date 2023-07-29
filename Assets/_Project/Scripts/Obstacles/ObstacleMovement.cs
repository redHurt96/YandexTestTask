using UnityEngine;

namespace _Project.Obstacles
{
    public class ObstacleMovement : MonoBehaviour
    {
        [SerializeField] private MoveDirection _direction;
        [SerializeField] private Rigidbody2D _rigidbody;

        private float _speed;
        private float _minSpeed;
        private float _changeDirectionOffsetUp;
        private float _changeDirectionOffsetDown;
        private float _pointsDistance;

        private void Update()
        {
            UpdateSpeed();

            if (NeedChangeDirection())
            {
                ChangeDirection();
            }
        }

        public void Init(float speed, float minSpeed, float changeDirectionOffsetUp, float changeDirectionOffsetDown)
        {
            _minSpeed = minSpeed;
            _speed = speed;
            _changeDirectionOffsetUp = changeDirectionOffsetUp;
            _changeDirectionOffsetDown = changeDirectionOffsetDown;
            _pointsDistance = Mathf.Abs(_changeDirectionOffsetUp - _changeDirectionOffsetDown);
        }

        private void UpdateSpeed()
        {
            float target = _direction == MoveDirection.Up
                ? _changeDirectionOffsetUp
                : _changeDirectionOffsetDown;

            float speedCoefficient = Mathf.Abs(transform.position.y - target) / _pointsDistance;
            float speed = Mathf.Lerp(_minSpeed, _speed, speedCoefficient);
            
            _rigidbody.velocity = _direction == MoveDirection.Up
                ? Vector2.up * speed
                : Vector2.down * speed;
        }

        private bool NeedChangeDirection()
        {
            return _direction == MoveDirection.Up && transform.position.y > _changeDirectionOffsetUp
                   || _direction == MoveDirection.Down && transform.position.y < _changeDirectionOffsetDown;
        }

        private void ChangeDirection()
        {
            _direction = _direction == MoveDirection.Up
                ? MoveDirection.Down
                : MoveDirection.Up;
        }
    }
}