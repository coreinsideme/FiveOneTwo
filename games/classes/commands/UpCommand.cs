
namespace Games
{
    public class UpCommand: IGameCommand
    {
        public void Execute(IGame game) {
            game.GoUp();
        }
    }    
}
