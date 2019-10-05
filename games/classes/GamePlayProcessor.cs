using System;
using Field;

namespace Games
{
    public class GamePlayProcessor: IGamePlayProcessor {

        private IGame game;
        private IGameDataProvider gameDataProvider;
        private IFieldBuilder fieldBuilder;

        public GamePlayProcessor(IGame _game, IFieldBuilder _fieldBuilder, IGameDataProvider _gameDataProvider)
        {
            if (_game == null) throw new ArgumentNullException(nameof(_game) + " should be passed");
            if (_gameDataProvider == null) throw new ArgumentNullException( nameof(_gameDataProvider) + "should be passed");
            if (_fieldBuilder == null) throw new ArgumentNullException( nameof(_fieldBuilder) + "should be passed");

            game = _game;
        }

        public void StartGame() {
            game.GameState = GetStartState();

            Refresh();
        }

        public void StopGame() {}

        public void SaveGame() {}

        public void LoadGame() {}

        public void Process(char commandChar) {

            if(gameProcessor.GameState == GameState.Lost || gameProcessor.GameState == GameState.Won) {
                    Console.WriteLine("Game is over, you've " + gameProcessor.GameState + " , press 'e' to exit");
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
            Refresh();            
        }
    }
}