using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PAST003.Algorithms;
using PAST003.Collections;
using PAST003.Extensions;
using PAST003.Numerics;
using PAST003.Questions;

namespace PAST003.Questions
{
    public class QuestionI : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var queries = inputStream.ReadInt();

            const int row = 0;
            const int column = 1;
            const int normal = 0;
            const int inverted = 1;
            var indices = Enumerable.Repeat(0, 2).Select(_ => Enumerable.Range(0, n).ToArray()).ToArray();
            var transposed = normal;

            for (int i = 0; i < queries; i++)
            {
                var query = inputStream.ReadIntArray();
                if (query[0] <= 2)
                {
                    var current = indices[(query[0] - 1) ^ row ^ transposed];
                    var a = query[1] - 1;
                    var b = query[2] - 1;
                    Swap(ref current[a], ref current[b]);
                }
                else if (query[0] == 3)
                {
                    transposed ^= 1;
                }
                else
                {
                    var a = query[1] - 1;
                    var b = query[2] - 1;
                    var currentRow = indices[row ^ transposed][a];
                    var currentColumn = indices[column ^ transposed][b];
                    if (transposed == inverted)
                    {
                        Swap(ref currentRow, ref currentColumn);
                    }
                    yield return GetNumber(currentRow, currentColumn, n);
                }
            }
        }

        void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        long GetNumber(int row, int column, int n) => (long)n * row + column;
    }
}
