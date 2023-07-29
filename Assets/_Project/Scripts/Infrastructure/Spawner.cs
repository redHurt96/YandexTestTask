using UnityEngine;

namespace _Project.Infrastructure
{
    public class Spawner
    {
        private float _currentDelay;
        
        private readonly ISpawnConfig _config;
        private readonly IFactory _factory;

        public Spawner(ISpawnConfig config, IFactory factory)
        {
            _config = config;
            _factory = factory;
        }
        
        public void Update()
        {
            if (_currentDelay <= 0f)
            {
                _currentDelay = _config.SpawnDelay;
                _factory.Create();
            }
            else
            {
                _currentDelay -= Time.deltaTime;
            }
        }
    }
}