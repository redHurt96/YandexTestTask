using System;
using _Project.Level;
using _Project.ScorePoints;
using _Project.UI;

namespace _Project.Controllers
{
    public class UIController : IDisposable
    {
        private readonly IGameModel _gameModel;
        private readonly StartScreen _startScreen;
        private readonly ScoreScreen _scoreScreen;

        public UIController(IGameModel gameModel, StartScreen startScreen, ScoreScreen scoreScreen)
        {
            _gameModel = gameModel;
            _startScreen = startScreen;
            _scoreScreen = scoreScreen;
        }

        public void Init()
        {
            _gameModel.OnStart += DisableStartScreen;
            _gameModel.ScoreUpdated += UpdatePointsScreen;
        }

        public void Dispose()
        {
            _gameModel.OnStart -= DisableStartScreen;
            _gameModel.ScoreUpdated -= UpdatePointsScreen;
        }

        private void DisableStartScreen()
        {
            _startScreen.Disable();
        }

        private void UpdatePointsScreen()
        {
            _scoreScreen.UpdatePoints(_gameModel.Score);
        }
    }
}
