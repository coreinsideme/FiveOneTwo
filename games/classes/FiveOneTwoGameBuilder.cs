
using System;
using Field;

namespace Games {

    public class FiveOneTwoGameBuilder: IGameBuilder {
        
        private readonly FiveOneTwoGame game;
        private const int fieldSize = 5;

        private readonly IGameDataProvider gameDataProvider;

        public FiveOneTwoGameBuilder(IGameDataProvider _gameDataProvider) {
            if(_gameDataProvider == null) throw new ArgumentNullException("gameDataProvider should not be null");
            
            gameDataProvider = _gameDataProvider;

            game = new FiveOneTwoGame(new FiveOneTwoFieldBuilder(fieldSize));
        }

        public void SetData() {
            game.Data = gameDataProvider.GetStartData(fieldSize);
        }

        public IGame GetGame() {
            return game;
        }
    }
}
