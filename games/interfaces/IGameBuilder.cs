using System;

namespace Games
{
    public interface IGameBuilder
    {
        void SetFieldBuilder();

        void SetData();

        IGame GetGame();
    }
}