using System;
using System.Collections.Generic;

namespace QueenProblem
{
    public class DoubleProvider : IElementProvider
    {
        public ushort GetNextElement(IList<ushort> triedElements, ushort numberOfQueens)
        {
            for (ushort element = 0; element < numberOfQueens; element += 2)
            {
                if (!triedElements.Contains(element))
                {
                    triedElements.Add(element);
                    return element;
                }
            }
            for (ushort element = 1; element < numberOfQueens; element += 2)
            {
                if (!triedElements.Contains(element))
                {
                    triedElements.Add(element);
                    return element;
                }
            }

            return UInt16.MaxValue;
        }
    }
}