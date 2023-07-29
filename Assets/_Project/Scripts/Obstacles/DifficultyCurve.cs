using UnityEngine;

namespace _Project.Obstacles
{
    [CreateAssetMenu(menuName = "Create DifficultyCurve", fileName = "DifficultyCurve", order = 0)]
    public class DifficultyCurve : ScriptableObject
    {
        [SerializeField] private AnimationCurve _difficulty;

        public int GetObstaclesCount(int forScore)
        {
            return (int)_difficulty.Evaluate(forScore);
        }
    }
}