using UnityEngine;
using UnityEngine.UI;

namespace _Project.ScorePoints
{
    public class ScoreScreen : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        
        public void UpdatePoints(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}