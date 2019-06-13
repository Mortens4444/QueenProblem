using System;
using System.Collections.Generic;
using System.Linq;

namespace QueenProblem
{
	public class QueenList : List<Queen>
    {
        public IEnumerable<Square> ReservedSquares
        {
            get
            {
                return this.Select(queen => queen.Square);
            }
        }

        public bool IsGoodSquare(Square square)
        {
            if (ReservedSquares.Any(reservedSquare =>
                reservedSquare.LeftDiagonal == square.LeftDiagonal ||
                reservedSquare.RightDiagonal == square.RightDiagonal /*||
                reservedSquare.Rank == square.Rank ||
                reservedSquare.Column == square.Column*/))
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
			return String.Join(", ", this);
        }
    }
}