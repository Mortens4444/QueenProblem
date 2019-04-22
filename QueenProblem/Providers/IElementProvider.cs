using System.Collections.Generic;

namespace QueenProblem
{
    public interface IElementProvider
    {
        ushort GetNextElement(IList<ushort> triedElements, ushort numberOfQueens);
    }
}

