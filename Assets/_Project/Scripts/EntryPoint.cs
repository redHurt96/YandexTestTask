using _Project.Controllers;
using _Project.Infrastructure;
using _Project.Level;
using _Project.Obstacles;
using _Project.Player;
using _Project.ScorePoints;
using _Project.UI;
using UnityEngine;

namespace _Project
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("From scene")]
        [SerializeField] private PlayerInitializer _playerInitializer;
        [SerializeField] private Obstacle[] _borders;
        [SerializeField] private StartScreen _startScreen;
        [SerializeField] private ScoreScreen _scoreScreen;
        [SerializeField] private Transform _obstaclesParent;
        [SerializeField] private Transform _scorePointsParent;
        
        [Header("From project")]
        [SerializeField] private ScorePointsConfig _scorePointsConfig;
        [SerializeField] private ObstaclesConfig _obstaclesConfig;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private DifficultyCurve _difficultyCurve;
        
        private GameModel _gameModel;
        private StartGameController _startGameController;
        private EndGameController _endGameController;
        private UIController _uiController;
        private ObstacleFactory _obstaclesFactory;
        private Spawner _obstaclesSpawner;
        
        private ScorePointsFactory _scorePointsFactory;
        private Spawner _scorePointsSpawner;

        private void Awake()
        {
            _gameModel = new GameModel();
            
            _endGameController = new EndGameController(_gameModel);
            _startGameController = new StartGameController(_gameModel);
            _uiController = new UIController(_gameModel, _startScreen, _scoreScreen);

            _obstaclesFactory = new ObstacleFactory(_playerInitializer.transform, _gameModel, _obstaclesConfig, _difficultyCurve, _obstaclesParent);
            _obstaclesSpawner = new Spawner(_obstaclesConfig, _obstaclesFactory);

            _scorePointsFactory = new ScorePointsFactory(_scorePointsConfig, _playerInitializer.transform, _scorePointsParent);
            _scorePointsSpawner = new Spawner(_scorePointsConfig, _scorePointsFactory);
        }

        private void Start()
        {
            _endGameController.Init();
            _playerInitializer.Init(_gameModel, _playerConfig);
            _uiController.Init();

            foreach (Obstacle obstacle in _borders)
                obstacle.Init(_gameModel);
        }

        private void OnDestroy()
        {
            _uiController.Dispose();
            _playerInitializer.Dispose();
            _endGameController.Dispose();
        }

        private void Update()
        {
            _startGameController.Update();
            
            if (_gameModel.IsStarted)
            {
                _obstaclesSpawner.Update();
                _scorePointsSpawner.Update();
            }
        }
    }
}