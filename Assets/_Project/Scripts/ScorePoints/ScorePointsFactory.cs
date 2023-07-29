using _Project.Infrastructure;
using _Project.Obstacles;
using UnityEngine;

namespace _Project.ScorePoints
{
    public class ScorePointsFactory : IFactory
    {
        private readonly ScorePointsConfig _config;
        private readonly Transform _player;
        private readonly Transform _parent;

        public ScorePointsFactory(ScorePointsConfig config, Transform player, Transform parent)
        {
            _config = config;
            _player = player;
            _parent = parent;
        }
        
        public void Create()
        {
            Vector3 position = new Vector3(
                _player.position.x + _config.XOffset,
                Random.Range(-_config.YOffset, _config.YOffset),
                0f);

            ScorePointMovement instance = Object.Instantiate(_config.Prefab, position, Quaternion.identity, _parent);
            instance.Init(_config.Speed, _config.Radius);
        }
    }
}