using PAST002.Algorithms;
using PAST002.Collections;
using PAST002.Questions;
using PAST002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAST002.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var rows = inputStream.ReadInt();
            var map = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                map[row] = inputStream.ReadLine().ToCharArray();
            }

            for (int row = rows - 2; row >= 0; row--)
            {
                for (int column = 1; column < 2 * rows - 2; column++)
                {
                    if (map[row][column] == '#' && (map[row + 1][column - 1] == 'X' || map[row + 1][column] == 'X' || map[row + 1][column + 1] == 'X'))
                    {
                        map[row][column] = 'X';
                    }
                }
            }

            foreach (var row in map)
            {
                yield return string.Concat(row);
            }
        }

        readonly struct Point
        {
            public int Row { get; }
            public int Column { get; }

            public Point(int row, int column)
            {
                Row = row;
                Column = column;
            }

            public (int row, int column) Deconstruct() => (Row, Column);
        }
    }
}
