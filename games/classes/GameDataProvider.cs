using System;

namespace Games
{
    public class GameDataProvider: IGameDataProvider
    {
        public int[,] GetStartData(int fieldSize) {
            var result = new int[fieldSize, fieldSize];
            var random = new Random();
            
            for (int i = 0; i < fieldSize; i++)
            {
                result[random.Next(0, fieldSize - 1), random.Next(0, fieldSize - 1)] = 2;
            }

            return result;
        }

    } 
}