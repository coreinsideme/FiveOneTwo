namespace Games
{
    public class StartCommand: IGameCommand
    {
        public void Execute(IGame game) {
            game.StartGame();
        }
    }    
}