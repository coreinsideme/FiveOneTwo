using System;

namespace Games
{
    public interface IGamePlayProcessor
    {
        GameState GameState { get; }

        void Process(char commandChar);

        void StartGame();

        void StopGame();

        void SaveGame();

        void LoadGame();
    }
}