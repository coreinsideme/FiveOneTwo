using System;
using Games;
using Field;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameCreator gameCreator = new FiveOneTwoGameCreator(5);
            IGamePlayProcessor gameProcessor = gameCreator.CreateGame();
            
            Console.WriteLine("Do you wanna load the previous game, y/n?");
            char loadKey = Console.ReadKey().KeyChar;

            IGamePlayProcessor gameProcessor = new GamePlayProcessor(gameCreator.CreateGame());
            
            Console.WriteLine("Do you want to load previous game, y/n?");

            if(Console.ReadKey().KeyChar == 'y') {
                gameProcessor.LoadGame();
            } else {
                gameProcessor.StartGame();
            }            


            while(true) {
                char key = Console.ReadKey().KeyChar;

                if(key == 'e') {
                    Console.WriteLine("Do you want to save game, y/n?");

                    if(Console.ReadKey().KeyChar == 'y') {
                        gameProcessor.SaveGame();
                    }

                    gameProcessor.StopGame();

                    Console.WriteLine("Do you wanna save the game, y/n?");
                    char saveChar = Console.ReadKey().KeyChar;

                    if(saveChar == 'y') {
                        gameProcessor.SaveGame();
                    }

                    return;
                }

                gameProcessor.Process(key);
            }
        }
    }
}
