namespace Games
{
    public class RightCommand: IGameCommand
    {
        public void Execute(IGame game) {
            game.GoRight();
        }
    }    
}