using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    public class BestPossibleHand : IBestPossibleHand, IEquatable<IBestPossibleHand>, IComparable<IBestPossibleHand>
    {
        public BestPossibleHand(HandName name, IList<ICard> bestHand, IList<CardValue> kickers)
        {
            HandName = name;
            HandCards = new ReadOnlyCollection<ICard>(bestHand);
            KickerValues = new ReadOnlyCollection<CardValue>(kickers);
            
        }

        public ReadOnlyCollection<ICard> HandCards { get; private set; }

        public HandName HandName { get; private set;}

        public ReadOnlyCollection<CardValue> KickerValues { get; private set; }

        public int CompareTo(IBestPossibleHand other)
        {
            if (other == null)
            {
                return 1;
            }
            int compareResult = CompareToHandName(other.HandName);
            if (compareResult == 0)
            {
                compareResult = CompareHandValues(other.HandCards);
                if (compareResult == 0)
                {
                    var compareKickers = CompareKickers(other.KickerValues);
                    return compareKickers;
                }
            }
            return compareResult;
        }

        private int CompareHandValues(ReadOnlyCollection<ICard> handCards)
        {
            int result = 0;
            int counter = 0;
            while (result == 0 && counter < HandCards.Count)
            {
                if (HandCards[counter].Value > handCards[counter].Value)
                {
                    result = 1;
                }
                if (HandCards[counter].Value < handCards[counter].Value)
                {
                    result = -1;
                }
                counter++;
            }
            return result;
        }

        public override string ToString()
        {
            var toString = HandName.ToString() + ": ";
            foreach (var item in HandCards)
            {
                toString += item.ToString() + " ";
            }

            if (KickerValues.Count > 0)
            {
                toString += "( ";
                foreach (var item in KickerValues)
                {
                    toString += item + " ";
                }
                toString += ") ";
            }
            return toString;
        }

        private int CompareToHandName(HandName otherHandName)
        {
            var difference = HandName - otherHandName;
            return difference > 0 ? 1 : difference < 0 ? -1 : 0;
        }

        private int CompareKickers(IList<CardValue> secondPlayerKickers)
        {
            int compareResult = 0; ;
            var numberOfKikersToCompare = KickerValues.Count;
            if (numberOfKikersToCompare > 0)
            {
                var difference = KickerValues[0] - secondPlayerKickers[0];
                compareResult = difference > 0 ? 1 : difference < 0 ? -1 : 0;
                var counter = 1;
                while (counter < numberOfKikersToCompare && compareResult == 0)
                {
                    difference = KickerValues[counter] - secondPlayerKickers[counter];
                    compareResult = difference > 0 ? 1 : difference < 0 ? -1 : 0;
                    counter++;
                }
            }
            return compareResult;
        }

        public override bool Equals(object obj)
        {
            var other = obj as IBestPossibleHand;
            if (other == null)
            {
                return false;
            }
            return Equals(other);
        }

        public override int GetHashCode()
        {
            var kickersSum = 0;
            foreach (var item in KickerValues)
            {
                kickersSum += (int)item;
            }

            return (137 * (int)HandName) + kickersSum;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public static bool operator ==(BestPossibleHand firstOperator, BestPossibleHand secondOperator)
        {
            return firstOperator.CompareTo(secondOperator) == 0;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public static bool operator !=(BestPossibleHand firstOperator, BestPossibleHand secondOperator)
        {
            return firstOperator.CompareTo(secondOperator) != 0;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public static bool operator <(BestPossibleHand firstOperator, BestPossibleHand secondOperator)
        {
            return firstOperator.CompareTo(secondOperator) == -1;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public static bool operator >(BestPossibleHand firstOperator, BestPossibleHand secondOperator)
        {
            return firstOperator.CompareTo(secondOperator) == 1;
        }

        public bool Equals(IBestPossibleHand other)
        {
            return other == null ? false : CompareTo(other) == 0;
        }
    }
}
