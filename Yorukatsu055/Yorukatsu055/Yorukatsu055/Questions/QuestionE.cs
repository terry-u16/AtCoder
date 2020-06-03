using Yorukatsu055.Questions;
using Yorukatsu055.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu055.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc089/tasks/abc089_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hwd = inputStream.ReadIntArray();
            var height = hwd[0];
            var width = hwd[1];
            var d = hwd[2];

            var positions = new Position[height * width];

            for (int row = 0; row < height; row++)
            {
                var r = inputStream.ReadIntArray();
                for (int column = 0; column < width; column++)
                {
                    positions[r[column] - 1] = new Position(row, column);
                }
            }

            var sum = new int[(positions.Length + d - 1) / d, d];

            for (int i = 0; i + d < positions.Length; i++)
            {
                sum[i / d + 1, i % d] = positions[i].GetDistanceTo(positions[i + d]);
            }

            for (int i = 0; i + 1 < sum.GetLength(0); i++)
            {
                for (int j = 0; j < sum.GetLength(1); j++)
                {
                    sum[i + 1, j] += sum[i, j];
                }
            }

            var queries = inputStream.ReadInt();
            for (int q = 0; q < queries; q++)
            {
                var lr = inputStream.ReadIntArray();
                var l = lr[0] - 1;
                var r = lr[1] - 1;
                var mod = l % d;
                yield return sum[r / d, mod] - sum[l / d, mod];
            }
        }

        struct Position
        {
            public int X { get; }
            public int Y { get; }

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int GetDistanceTo(Position to) => Math.Abs(X - to.X) + Math.Abs(Y - to.Y);
        }
    }
}
