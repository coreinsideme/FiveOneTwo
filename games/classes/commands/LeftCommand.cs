namespace Games
{
    public class LeftCommand: IGameCommand
    {
        public void Execute(IGame game) {
            game.GoLeft();
        }
    }    
}