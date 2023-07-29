using System;
using _Project.Obstacles;

namespace _Project.Level
{
    public class GameModel : IStartGameHandler, IEndGameHandler, IUpdateScoreHandler, IGameModel
    {
        public event Action OnStart;
        public event Action OnEnd;
        public event Action ScoreUpdated;

        public bool IsStarted { get; private set; }
        public int Score { get; private set; }
        
        public void StartGame()
        {
            IsStarted = true;
            OnStart?.Invoke();
        }

        public void EndGame()
        {
            OnEnd?.Invoke();
        }

        public void AddPoint()
        {
            Score++;
            ScoreUpdated?.Invoke();
        }
    }
}