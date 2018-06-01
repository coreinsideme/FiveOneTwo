using System;

namespace Games
{
    public interface IGameBuilder
    {
        void SetData();

        IGame GetGame();
    }
}