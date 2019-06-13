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
			var leftDiagonal = (ushort)(rank + column);
			Rank = rank;
            Column = column;
            LeftDiagonal = leftDiagonal;
            RightDiagonal = (ushort)(leftDiagonal + rank * -2);
        }

        public override int GetHashCode()
        {
            return LeftDiagonal;
        }

        public override bool Equals(object obj)
        {
			if (!(obj is Square square))
			{
				return false;
			}
			return Rank == square.Rank && Column == square.Column;
        }

        public override string ToString()
        {
            var column = Column < 26 ? ((char)('A' + Column)).ToString() : $"(C{Column + 1})";
            var rank = Rank < 9 ? ((char)('1' + Rank)).ToString() : $"(R{Rank + 1})";
            return column + rank;
        }
    }
}