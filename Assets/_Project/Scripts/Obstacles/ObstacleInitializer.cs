using _Project.Level;
using UnityEngine;

namespace _Project.Obstacles
{
    public class ObstacleInitializer : MonoBehaviour
    {
        [SerializeField] private Obstacle _obstacle;
        [SerializeField] private ObstacleMovement _movement;

        public void Init(IEndGameHandler endGameHandler, float speed, float minSpeed, float offsetUp, float offsetDown)
        {
            _obstacle.Init(endGameHandler);
            _movement.Init(speed, minSpeed, offsetUp, offsetDown);
        }
    }
}