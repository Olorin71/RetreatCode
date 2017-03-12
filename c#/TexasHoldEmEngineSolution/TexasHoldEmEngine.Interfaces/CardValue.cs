using System.Collections.Generic;

namespace TexasHoldEmEngine.Interfaces
{
    /// <summary>
    /// The card values in the game.
    /// Each enum value has an assigned int value to simplify comparisions. The higher the value rank, the higher the number.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", 
        Justification = "Zero is not a valid value.")]
    public enum CardValue
    {
        Ace = 14, King = 13, Queen = 12, Jack = 11, Ten = 10, Nine = 9, Eight = 8, Seven = 7, Six = 6, Five = 5, Four = 4, Three = 3, Two = 2
    }

}
