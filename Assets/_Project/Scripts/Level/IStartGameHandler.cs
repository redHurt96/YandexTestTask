namespace _Project.Level
{
    public interface IStartGameHandler
    {
        bool IsStarted { get; }
        void StartGame();
    }
}