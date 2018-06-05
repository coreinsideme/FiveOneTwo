using System;

namespace Games
{
    public interface IGameDataProvider
    {
        int[,] GetStartData();

        bool SaveData(GameState gameState);

        GameState LoadData();
    }
}