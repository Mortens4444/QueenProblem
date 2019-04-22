using System;

namespace QueenProblem
{
    public class Square
    {
        public ushort Rank { get; set; }

        public ushort Column { get; set; }

        public ushort LeftDiagonal { get; set; }

        public ushort RightDiagonal { get; set; }

        public Square(ushort rank, ushort column)
        {
            Rank = rank;
            Column = column;
            LeftDiagonal = (ushort)(rank + column);
            RightDiagonal = (ushort)(rank + column + rank * -2);
        }

        public override int GetHashCode()
        {
            return LeftDiagonal;
        }

        public override bool Equals(object obj)
        {
            var square = obj as Square;
            if (square == null)
            {
                return false;
            }
            return Rank == square.Rank && Column == square.Column;
        }

        public override string ToString()
        {
            var column = (char)('A' + Column);
            var row = (char)('1' + Rank);
            return column.ToString() + row;
        }
    }
}