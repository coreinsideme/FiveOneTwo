using System;
using Field;

namespace Games
{
    public class FiveOneTwoGameCreator: IGameCreator
    {
        private readonly IGameBuilder gameBuilder;
        private readonly IFieldBuilder fieldBuilder;


        private readonly int gameSize;
        
        public FiveOneTwoGameCreator(int _gameSize) {
            if(_gameSize <= 3) throw new ArgumentException(nameof(_gameSize) + " should be more or equal then 3 ");

            gameSize = _gameSize;
            
            gameBuilder = new FiveOneTwoGameBuilder();
            fieldBuilder = new FiveOneTwoFieldBuilder(gameSize);
        }

        public IGamePlayProcessor CreateGame() {
            gameBuilder.GameSize = gameSize;
            IGame game = gameBuilder.GetGame();
            return new GamePlayProcessor(game, fieldBuilder, new GameDataProvider(gameSize));
        }
    } 
}