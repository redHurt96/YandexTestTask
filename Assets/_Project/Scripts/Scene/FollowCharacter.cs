using UnityEngine;

namespace _Project.Scene
{
    public class FollowCharacter : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _offset;
        [SerializeField] private float _lerpValue = .125f;

        private void FixedUpdate()
        {
            Vector3 newPosition = new Vector3(
                _target.position.x + _offset,
                transform.position.y,
                transform.position.z);
            
            transform.position = Vector3.Lerp(transform.position, newPosition, _lerpValue);
        }
    }
}
