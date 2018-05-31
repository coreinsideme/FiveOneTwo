using System;

namespace Games
{
    public class GameCreator: IGameCreator
    {
        private readonly IGameBuilder builder;
        
        public GameCreator(IGameBuilder _builder) {
            if(_builder == null) throw new ArgumentNullException("builder should not be null");

            builder = _builder;
        }

        public IGame CreateGame() {
            builder.SetFieldBuilder();
            builder.SetData();
            return builder.GetGame();
        }
    } 
}