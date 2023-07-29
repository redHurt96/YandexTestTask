using _Project.Infrastructure;
using _Project.Level;
using UnityEngine;

namespace _Project.Obstacles
{
    [CreateAssetMenu(menuName = "Create ObstaclesConfig", fileName = "ObstaclesConfig", order = 0)]
    public class ObstaclesConfig : ScriptableObject, ISpawnConfig
    {
        public float SpawnDelay => _spawnDelay;

        public float XOffset;
        public Vector2 RandomizedOffset;
        public ObstacleInitializer Prefab;
        public float MinSpeed;
        public float Speed;
        public float ChangeDirectionOffset;
        
        [SerializeField] private float _spawnDelay;
    }
}