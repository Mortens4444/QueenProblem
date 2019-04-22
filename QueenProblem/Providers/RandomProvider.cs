using System;
using System.Collections.Generic;

namespace QueenProblem
{
    public class RandomProvider : IElementProvider
    {
        private static readonly Random random = new Random();        

        public ushort GetNextElement(IList<ushort> triedElements, ushort numberOfQueens)
        {
            ushort element;
            var tested = new List<ushort>();
            do
            {
                element = (ushort)random.Next(0, numberOfQueens);
                tested.Add(element);
            }
            while (triedElements.Contains(element) && tested.Count < numberOfQueens);
            if (tested.Count == numberOfQueens)
            {
                return UInt16.MaxValue;
            }
            triedElements.Add(element);
            return element;
        }
    }
}