namespace Games
{
    public interface IGameCommand
    {
        void Execute(IGame game);
    }
}