using _Project.Infrastructure;
using _Project.ScorePoints;
using _Project.UI;
using UnityEngine;

namespace _Project.Obstacles
{
    [CreateAssetMenu(menuName = "Create ScorePointsConfig", fileName = "ScorePointsConfig", order = 0)]
    public class ScorePointsConfig : ScriptableObject, ISpawnConfig
    {
        public float SpawnDelay => _spawnDelay;

        public float XOffset;
        public float YOffset;
        public ScorePointMovement Prefab;
        public float Speed;
        public float Radius;
        
        [SerializeField] private float _spawnDelay;
    }
}