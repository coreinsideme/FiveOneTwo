using System;

namespace Games
{
    public interface IGameDataProvider
    {
        int[,] GetStartData(int fieldSize);
    }
}