using System;

namespace Games
{
    public interface IGameBuilder
    {
        int GameSize { get; set; }

        IGame GetGame();
    }
}