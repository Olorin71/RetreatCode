namespace TexasHoldEm.Interfaces
{
    public interface ITexasHoldEmGame
    {
        int NumberOfPlayers { get; }

        void AddPlayer(string playerName);
    }
}