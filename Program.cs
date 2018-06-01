using System;
using Games;
using Field;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameBuilder gameBuilder = new FiveOneTwoGameBuilder(new GameDataProvider());
            IGameCreator gameCreator = new GameCreator(gameBuilder);

            IGamePlayProcessor gameProcessor = new GamePlayProcessor(gameCreator.CreateGame());
            gameProcessor.StartGame();

            while(true) {
                char key = Console.ReadKey().KeyChar;

                if(key == 'e') {
                    gameProcessor.StopGame();
                    return;
                }

                gameProcessor.Process(key);

                if(gameProcessor.GameState == GameState.Lost || gameProcessor.GameState == GameState.Won) {
                    Console.WriteLine("Game is over, you've " + gameProcessor.GameState + " , press 'e' to exit");
                }
            }
        }
    }
}
