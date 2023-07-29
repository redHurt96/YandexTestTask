using _Project.Level;
using UnityEngine;

namespace _Project.Player
{
    public class ScorePointsCollector : MonoBehaviour
    {
        private IUpdateScoreHandler _scoreHandler;

        public void Init(IUpdateScoreHandler scoreHandler)
        {
            _scoreHandler = scoreHandler;
        }
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Score Point"))
            {
                _scoreHandler.AddPoint();
                Destroy(collider.gameObject);
            }
        }
    }
}