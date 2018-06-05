
using System;
using Field;

namespace Games {

    public class FiveOneTwoGameBuilder: IGameBuilder {
        
        public int GameSize { get; set; }

        public IGame GetGame() {
            return new FiveOneTwoGame();
        }
    }
}
