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
            gameDataProvider = _gameDataProvider;
            fieldBuilder = _fieldBuilder;
        }

        public void StartGame() {
            game.GameState = GetStartState();

            Refresh();
        }

        public void StopGame() {}

        public void SaveGame() {
            GameState gameState = game.GameState;
            
            if (gameDataProvider.SaveData(gameState)) {
                Console.WriteLine("Game succesfully saved");
            } else {
                Console.WriteLine("Saving failed. Error occured");
            }
        }

        public void LoadGame() {
            GameState state = gameDataProvider.LoadData();

            if(state == null) {
                Console.WriteLine("Unable to open last game, new game created");
                state = GetStartState();
            }

            game.GameState = state;

            Refresh();
        }

        public void Process(char commandChar) {

            if(game.GameState.State != State.InProcess) {
                Console.WriteLine("Game is over, you've " + game.GameState.State + " , press 'e' to exit");
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

        private GameState GetStartState() {
            return game.GameState = new GameState {
                Data = gameDataProvider.GetStartData(),
                State = State.InProcess
            };
        }

        private void Refresh() {
            GameState state = game.GameState;
            
            Console.Clear();
            Console.WriteLine(fieldBuilder.CreateField(state.Data));
        }
    }
}