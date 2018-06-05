using System;

namespace Games
{
    public interface IGamePlayProcessor
    {
        void Process(char commandChar);

        void StartGame();

        void StopGame();

        void SaveGame();

        void LoadGame();
    }
}