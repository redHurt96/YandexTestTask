using _Project.Level;
using UnityEngine;

namespace _Project.Player
{
    public class PlayerInitializer : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PlayerJump _jump;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private ScorePointsCollector _scorePointsCollector;
        
        private IGameModel _gameModel;

        public void Init(GameModel gameModel, PlayerConfig playerConfig)
        {
            _gameModel = gameModel;

            _playerMovement.SetSpeed(playerConfig.MoveSpeed);
            _jump.SetSpeed(playerConfig.JumpSpeed);
            _scorePointsCollector.Init(gameModel);

            _gameModel.OnStart += Run;
        }

        public void Dispose()
        {
            _gameModel.OnStart -= Run;
        }

        private void Run()
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _jump.enabled = true;
            _playerMovement.enabled = true;
        }
    }
}