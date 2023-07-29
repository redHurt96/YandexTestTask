using _Project.Level;
using UnityEngine;

namespace _Project.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        private IEndGameHandler _endGameHandler;

        public void Init(IEndGameHandler endGameHandler)
        {
            _endGameHandler = endGameHandler;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _endGameHandler.EndGame();
            }
        }
    }
}