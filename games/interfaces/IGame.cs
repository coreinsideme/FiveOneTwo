using System;
using Field;

namespace Games
{
    public interface IGame
    {
        GameState GameState { get; }

        void StartGame();

        void GoUp();

        void GoDown();

        void GoLeft();

        void GoRight();
    }
}