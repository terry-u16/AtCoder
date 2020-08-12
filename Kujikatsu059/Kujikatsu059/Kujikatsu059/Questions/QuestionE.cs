using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu059.Algorithms;
using Kujikatsu059.Collections;
using Kujikatsu059.Extensions;
using Kujikatsu059.Numerics;
using Kujikatsu059.Questions;

namespace Kujikatsu059.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var distances = new int[height, width].SetAll((i, j) => 1 << 28);
            var todo = new Queue<(int, int)>();
            var diffs = new (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            for (int row = 0; row < height; row++)
            {
                var a = inputStream.ReadLine();
                for (int column = 0; column < width; column++)
                {
                    if (a[column] == '#')
                    {
                        todo.Enqueue((row, column));
                        distances[row, column] = 0;
                    }
                }
            }

            while (todo.Count > 0)
            {
                var (row, column) = todo.Dequeue();

                foreach (var diff in diffs)
                {
                    var nextRow = row + diff.dr;
                    var nextColumn = column + diff.dc;
                    if (unchecked((uint)nextRow < height && (uint)nextColumn < width) && distances[nextRow, nextColumn] == 1 << 28)
                    {
                        distances[nextRow, nextColumn] = distances[row, column] + 1;
                        todo.Enqueue((nextRow, nextColumn));
                    }
                }
            }

            var max = 0;
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    max = Math.Max(max, distances[row, column]);
                }
            }

            yield return max;
        }
    }
}
