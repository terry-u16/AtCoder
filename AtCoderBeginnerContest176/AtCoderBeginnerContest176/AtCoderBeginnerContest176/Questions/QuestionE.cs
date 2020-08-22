using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest176.Algorithms;
using AtCoderBeginnerContest176.Collections;
using AtCoderBeginnerContest176.Extensions;
using AtCoderBeginnerContest176.Numerics;
using AtCoderBeginnerContest176.Questions;

namespace AtCoderBeginnerContest176.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, objectiveCount) = inputStream.ReadValue<int, int, int>();
            var rowCounts = new int[height];
            var columnCounts = new int[width];
            var targets = new HashSet<(int, int)>();

            for (int i = 0; i < objectiveCount; i++)
            {
                var (row, column) = inputStream.ReadValue<int, int>();
                row--;
                column--;
                rowCounts[row]++;
                columnCounts[column]++;
                targets.Add((row, column));
            }

            var maxRows = new List<int>();
            var maxRowCount = 0;
            var maxColumns = new List<int>();
            var maxColumnCount = 0;

            for (int i = 0; i < rowCounts.Length; i++)
            {
                if (rowCounts[i] >= maxRowCount)
                {
                    if (rowCounts[i] > maxRowCount)
                    {
                        maxRows.Clear();
                    }

                    maxRowCount = rowCounts[i];
                    maxRows.Add(i);
                }
            }

            for (int i = 0; i < columnCounts.Length; i++)
            {
                if (columnCounts[i] >= maxColumnCount)
                {
                    if (columnCounts[i] > maxColumnCount)
                    {
                        maxColumns.Clear();
                    }

                    maxColumnCount = columnCounts[i];
                    maxColumns.Add(i);
                }
            }

            foreach (var row in maxRows)
            {
                foreach (var column in maxColumns)
                {
                    if (!targets.Contains((row, column)))
                    {
                        yield return maxRowCount + maxColumnCount;
                        yield break;
                    }
                }
            }

            yield return maxRowCount + maxColumnCount - 1;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Bomb
        {
            public int Row { get; }
            public int Column { get; }

            public Bomb(int row, int column)
            {
                Row = row;
                Column = column;
            }

            public void Deconstruct(out int row, out int column) => (row, column) = (Row, Column);
            public override string ToString() => $"{nameof(Row)}: {Row}, {nameof(Column)}: {Column}";
        }
    }
}
