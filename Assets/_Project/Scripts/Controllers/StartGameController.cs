using _Project.Infrastructure;
using _Project.Level;
using _Project.Obstacles;
using _Project.Player;

namespace _Project.Controllers
{
    public class StartGameController
    {
        private readonly IStartGameHandler _startGameHandler;

        public StartGameController(IStartGameHandler startGameHandler)
        {
            _startGameHandler = startGameHandler;
        }

        public void Update()
        {
            if (GameInput.JumpButtonPressed && !_startGameHandler.IsStarted)
            {
                _startGameHandler.StartGame();
            }
        }
    }
}