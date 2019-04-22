using System.Collections.Generic;

namespace QueenProblem
{
    public class Queen
    {
        public List<ushort> TriedRanks { get; private set; }

        public List<ushort> TriedColumns { get; private set; }

        public Square Square { get; set; }

        public Queen(IEnumerable<ushort> reservedRanks)
        {
            TriedRanks = new List<ushort>(reservedRanks);
            TriedColumns = new List<ushort>();
        }

        public void ClearTriedColumns(IEnumerable<ushort> reservedColumns)
        {
            TriedColumns = new List<ushort>(reservedColumns);
        }

        public override string ToString()
        {
            return Square.ToString();
        }
    }
}