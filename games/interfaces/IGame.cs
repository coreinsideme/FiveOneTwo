using System;
using Field;

namespace Games
{
    public interface IGame
    {
        GameState GameState { get; }
        int[, ] Data { get; set; }

        void StartGame();

        void GoUp();

        void GoDown();

        void GoLeft();

        void GoRight();
    }
}