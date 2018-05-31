namespace Games
{
    public class DownCommand: IGameCommand
    {
        public void Execute(IGame game) {
            game.GoDown();
        }
    }    
}