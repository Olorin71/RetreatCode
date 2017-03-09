using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmService
{
    internal class Player
    {
        public Player(string name, int chipsAmount)
        {
            Name = name;
            Chips = chipsAmount;
        }

        public int Chips { get; private set; }

        public ICard FirstHoleCard { get; set; }
        public ICard SecondHoleCard { get; set; }

        public string Name { get; private set; }
    }
}
