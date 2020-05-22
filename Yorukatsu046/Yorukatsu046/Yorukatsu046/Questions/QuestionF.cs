using Yorukatsu046.Questions;
using Yorukatsu046.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu046.Questions
{
    /// <summary>
    /// ABC045 D
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hwn = inputStream.ReadIntArray();
            var height = hwn[0];
            var width = hwn[1];
            var paintedCount = hwn[2];

            var paintedCells = new Cell[paintedCount];

            for (int i = 0; i < paintedCells.Length; i++)
            {
                var ab = inputStream.ReadIntArray().Select(t => t - 1).ToArray();
                paintedCells[i] = new Cell(ab[0], ab[1]);
            }

            Array.Sort(paintedCells);

            var counts = new Dictionary<Cell, int>();

            foreach (var paintedCell in paintedCells)
            {
                CheckAround(paintedCell, counts, height, width, paintedCells);
            }

            var aggregated = Enumerable.Range(0, 10).Select(i => (long)counts.Count(p => p.Value == i)).ToArray();
            aggregated[0] = (long)(height - 2) * (width - 2) - aggregated.Sum();

            for (int i = 0; i < aggregated.Length; i++)
            {
                yield return aggregated[i];
            }
        }

        void CheckAround(Cell cell, Dictionary<Cell, int> counts, int height, int width, Cell[] paintedCells)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                var row = cell.Row + dy;
                if (row >= 1 && row < height - 1)
                {
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        var column = cell.Column + dx;
                        if (column >= 1 && column < width - 1)
                        {
                            var nextCell = new Cell(row, column);
                            if (!counts.ContainsKey(nextCell))
                            {
                                counts[nextCell] = CheckCount(nextCell, paintedCells);
                            }
                        }
                    }
                }
            }
        }

        int CheckCount(Cell cell, Cell[] paintedCells)
        {
            var count = 0;
            for (int dy = -1; dy <= 1; dy++)
            {
                var row = cell.Row + dy;
                for (int dx = -1; dx <= 1; dx++)
                {
                    var column = cell.Column + dx;
                    if (Array.BinarySearch(paintedCells, new Cell(row, column)) >= 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        struct Cell : IEquatable<Cell>, IComparable<Cell>
        {
            public int Row { get; }
            public int Column { get; }

            public Cell(int row, int column)
            {
                Row = row;
                Column = column;
            }

            public override bool Equals(object obj)
            {
                return obj is Cell && Equals((Cell)obj);
            }

            public bool Equals(Cell other)
            {
                return Row == other.Row &&
                       Column == other.Column;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = 240067226;
                    hashCode = hashCode * -1521134295 + Row.GetHashCode();
                    hashCode = hashCode * -1521134295 + Column.GetHashCode();
                    return hashCode;
                }
            }

            public int CompareTo(Cell other)
            {
                var compared = Row.CompareTo(other.Row);
                if (compared != 0)
                {
                    return compared;
                }
                return Column.CompareTo(other.Column);
            }

            public static bool operator ==(Cell left, Cell right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Cell left, Cell right)
            {
                return !(left == right);
            }
        }
    }
}
