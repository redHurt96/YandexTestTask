using System.Collections;
using UnityEngine;

namespace _Project.Scene
{
    public class DelayedDestroyer : MonoBehaviour
    {
        [SerializeField] private float _delay = 10f;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_delay);
            
            Destroy(gameObject);
        }
    }
}