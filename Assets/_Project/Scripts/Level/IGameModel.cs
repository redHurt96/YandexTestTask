using System;

namespace _Project.Level
{
    public interface IGameModel
    {
        event Action OnStart;
        event Action OnEnd;
        event Action ScoreUpdated;
        
        int Score { get; }
    }
}