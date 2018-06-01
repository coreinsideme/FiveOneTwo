using System;

namespace Games
{
    public class GamePlayProcessor: IGamePlayProcessor {

        private IGame game;

        public GamePlayProcessor(IGame _game)
        {
            if (_game == null) throw new ArgumentNullException("game should be passed");

            game = _game;
        }

        public GameState GameState {
            get {
                return game.GameState;
            }
        }

        public void StartGame() {
            game.StartGame();
        }

        public void StopGame() {}

        public void SaveGame() {}

        public void LoadGame() {}

        public void Process(char commandChar) {

            if(game.GameState != GameState.InProcess) {
                Console.WriteLine("Game is not in process");
                return;
            }
            
            IGameCommand command;

            switch (commandChar)
            {
                case 'w': {
                    command = new UpCommand();
                    break;
                }
                case 's': {
                    command = new DownCommand();
                    break;
                }
                case 'a': {
                    command = new LeftCommand();
                    break;
                }
                case 'd': {
                    command = new RightCommand();
                    break;
                }

                default: {
                    Console.WriteLine("Please type right character");
                    return;
                }
                    
            }

            command.Execute(game);
        }
    }
}