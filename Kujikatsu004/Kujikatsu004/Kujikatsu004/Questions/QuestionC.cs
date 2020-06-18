using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Kujikatsu004.Algorithms;
using Kujikatsu004.Collections;
using Kujikatsu004.Extensions;
using Kujikatsu004.Numerics;
using Kujikatsu004.Questions;

namespace Kujikatsu004.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc047/tasks/abc047_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (width, height, n) = inputStream.ReadValue<int, int, int>();
            var isBlack = new bool[width, height];

            for (int i = 0; i < n; i++)
            {
                var (xi, yi, a) = inputStream.ReadValue<int, int, int>();
                Func<int, int, bool> predicate = a switch
                {
                    1 => (x, y) => x < xi,
                    2 => (x, y) => x >= xi,
                    3 => (x, y) => y < yi,
                    4 => (x, y) => y >= yi,
                    _ => (x, y) => false
                };
                Paint(isBlack, predicate);
            }

            var area = 0;
            for (int x = 0; x < isBlack.GetLength(0); x++)
            {
                for (int y = 0; y < isBlack.GetLength(1); y++)
                {
                    area += isBlack[x, y] ? 0 : 1;
                }
            }

            yield return area;
        }

        void Paint(bool[,] isBlack, Func<int, int, bool> predicate)
        {
            for (int x = 0; x < isBlack.GetLength(0); x++)
            {
                for (int y = 0; y < isBlack.GetLength(1); y++)
                {
                    isBlack[x, y] |= predicate(x, y);
                }
            }
        }
    }
}
