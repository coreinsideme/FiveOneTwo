using System;

namespace Games
{
    public interface IGameCreator
    {
        IGamePlayProcessor CreateGame();
    } 
}