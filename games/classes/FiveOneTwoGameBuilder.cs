
using System;
using Field;

namespace Games {

    public class FiveOneTwoGameBuilder: IGameBuilder {
        
        private readonly FiveOneTwoGame game;
        private readonly int fieldSize = 5;

        private readonly IFieldBuilder fieldBuilder;
        private readonly IGameDataProvider gameDataProvider;

        public FiveOneTwoGameBuilder(IFieldBuilder _fieldBuilder, IGameDataProvider _gameDataProvider) {
            if(_fieldBuilder == null) throw new ArgumentNullException("fieldBuilder should not be null");
            if(_gameDataProvider == null) throw new ArgumentNullException("gameDataProvider should not be null");
            
            fieldBuilder = _fieldBuilder;
            gameDataProvider = _gameDataProvider;

            game = new FiveOneTwoGame();
        }

        public void SetFieldBuilder() {
            game.SetFieldBuilder(fieldBuilder);
        }

        public void SetData() {
            game.Data = gameDataProvider.GetStartData(fieldSize);
        }

        public IGame GetGame() {
            return game;
        }
    }
}
