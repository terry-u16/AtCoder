using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Asakatsu20200810.Algorithms;
using Asakatsu20200810.Collections;
using Asakatsu20200810.Extensions;
using Asakatsu20200810.Numerics;
using Asakatsu20200810.Questions;

namespace Asakatsu20200810.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc005/tasks/abc005_4
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var bit = new BinaryIndexedTree2D(n, n);
            for (int i = 0; i < n; i++)
            {
                var deli = inputStream.ReadIntArray();
                for (int j = 0; j < deli.Length; j++)
                {
                    bit[i, j] = deli[j];
                }
            }

            var results = new long[n * n + 1];

            for (int height = 1; height <= n; height++)
            {
                for (int width = 1; width <= n; width++)
                {
                    var size = height * width;
                    for (int shiftRow = 0; shiftRow <= n - height; shiftRow++)
                    {
                        for (int shiftColumn = 0; shiftColumn <= n - width; shiftColumn++)
                        {
                            results[size] = Math.Max(results[size], bit.Sum(shiftRow, shiftRow + height, shiftColumn, shiftColumn + width));
                        }
                    }
                }
            }

            for (int i = 1; i < results.Length; i++)
            {
                results[i] = Math.Max(results[i], results[i - 1]);
            }

            var queries = inputStream.ReadInt();

            for (int q = 0; q < queries; q++)
            {
                var takoyaki = inputStream.ReadInt();
                yield return results[takoyaki];
            }
        }
    }
}
