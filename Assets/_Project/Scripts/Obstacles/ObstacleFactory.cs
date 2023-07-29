using _Project.Infrastructure;
using _Project.Level;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace _Project.Obstacles
{
    public class ObstacleFactory : IFactory
    {
        private readonly Transform _player;
        private readonly IGameModel _gameModel;
        private readonly IEndGameHandler _endGameHandler;
        private readonly ObstaclesConfig _config;
        private readonly DifficultyCurve _difficultyCurve;
        private readonly Transform _parent;

        public ObstacleFactory(Transform player, GameModel gameModel, ObstaclesConfig config,
            DifficultyCurve difficultyCurve, Transform parent)
        {
            _player = player;
            _gameModel = gameModel;
            _endGameHandler = gameModel;
            _config = config;
            _difficultyCurve = difficultyCurve;
            _parent = parent;
        }

        public void Create()
        {
            int count = _difficultyCurve.GetObstaclesCount(_gameModel.Score);
            
            for (int i = 0; i < count; i++)
                Instantiate();
        }

        private void Instantiate()
        {
            Vector3 position = new Vector3(
                _player.position.x + _config.XOffset + Random.Range(-_config.RandomizedOffset.x, _config.RandomizedOffset.x),
                Random.Range(-_config.RandomizedOffset.y, _config.RandomizedOffset.y),
                0f);
            ObstacleInitializer instance = Object.Instantiate(_config.Prefab, position, Quaternion.identity, _parent);

            instance.Init(
                _endGameHandler, 
                Random.Range(_config.MinSpeed, _config.Speed),
                _config.MinSpeed,
                Random.Range(0f, _config.ChangeDirectionOffset),
                -Random.Range(0f, _config.ChangeDirectionOffset));
        }
    }
}