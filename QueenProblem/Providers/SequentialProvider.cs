using System;
using System.Collections.Generic;

namespace QueenProblem
{
    public class SequentialProvider : IElementProvider
    {
        public ushort GetNextElement(IList<ushort> triedElements, ushort numberOfQueens)
        {
            for (ushort element = 0; element < numberOfQueens; element++)
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