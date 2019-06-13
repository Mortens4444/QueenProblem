using System;
using System.Linq;

namespace QueenProblem
{
    public class QueenProblemSolver
    {
        private readonly IElementProvider rankProvider;
        private readonly IElementProvider columnProvider;

        public QueenProblemSolver(IElementProvider rankProvider, IElementProvider columnProvider)
        {
            this.rankProvider = rankProvider;
            this.columnProvider = columnProvider;
        }

        public QueenList GetSolution(ushort numberOfQueens)
        {
            Queen queen = null;
            Square testSquare;
            ushort rank, column;
            bool removeLast = false;

            var result = new QueenList();

            bool goodSquare;
            while (result.Count < numberOfQueens)
            {
                queen = removeLast ? result[result.Count - 1] : new Queen(result.ReservedSquares.Select(square => square.Rank));

                do
                {
                    if (removeLast && queen.TriedColumns.Count < numberOfQueens)
                    {
                        rank = queen.Square.Rank;
                    }
                    else
                    {
                        rank = rankProvider.GetNextElement(queen.TriedRanks, numberOfQueens);
                    }

                    if (rank != UInt16.MaxValue)
                    {
                        if (removeLast)
                        {
                            result.RemoveAt(result.Count - 1);
                            removeLast = false;
                        }
                        else
                        {
                            queen.ClearTriedColumns(result.ReservedSquares.Select(square => square.Column));
                        }

                        do
                        {
                            column = columnProvider.GetNextElement(queen.TriedColumns, numberOfQueens);
                            if (column != UInt16.MaxValue)
                            {
                                testSquare = new Square(rank, column);
                                goodSquare = result.IsGoodSquare(testSquare);
                            }
                            else
                            {
                                goodSquare = false;
                                testSquare = null;
                            }
                        }
                        while (ContinueSearch(numberOfQueens, queen.TriedColumns.Count, goodSquare));
                    }
                    else
                    {
                        goodSquare = false;
                        testSquare = null;
                        result.RemoveAt(result.Count - 1);
                    }
                }
				while (ContinueSearch(numberOfQueens, queen.TriedRanks.Count, goodSquare));

                if (goodSquare)
                {
                    queen.Square = testSquare;
                    result.Add(queen);
                }
                else
                {
                    removeLast = true;
                }
            }

            return result;
        }

		private static bool ContinueSearch(ushort numberOfQueens, int actualCount, bool goodSquare)
		{
			return !goodSquare && (actualCount != numberOfQueens);
		}
	}
}