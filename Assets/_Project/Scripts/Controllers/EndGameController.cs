using System;
using _Project.Level;
using UnityEngine.SceneManagement;

namespace _Project.Controllers
{
    public class SpawnObstaclesController
    {
        
    }
    public class EndGameController : IDisposable
    {
        private readonly IGameModel _gameModel;

        public EndGameController(IGameModel gameModel)
        {
            _gameModel = gameModel;
        }

        public void Init()
        {
            _gameModel.OnEnd += ReloadScene;
        }

        public void Dispose()
        {
            _gameModel.OnEnd -= ReloadScene;
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}