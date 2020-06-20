using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderGrandContest046.Algorithms;
using AtCoderGrandContest046.Collections;
using AtCoderGrandContest046.Extensions;
using AtCoderGrandContest046.Numerics;
using AtCoderGrandContest046.Questions;

namespace AtCoderGrandContest046.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int mod = 998244353;
            var (initialHeight, initialWidth, lastHeight, lastWidth) = inputStream.ReadValue<int, int, int, int>();
            var counts = new Modular[lastHeight + 1, lastWidth + 1].SetAll((r, c) => new Modular(0, mod));
            var minuses = new Modular[lastHeight + 1, lastWidth + 1].SetAll((r, c) => new Modular(0, mod));

            counts[initialHeight + 1, initialWidth] = new Modular(initialWidth, mod);
            counts[initialHeight, initialWidth + 1] = new Modular(initialHeight, mod);

            for (int row = initialHeight + 1; row <= lastHeight; row++)
            {
                for (int column = initialWidth + 1; column <= lastWidth; column++)
                {
                    var add = new Modular(row, mod) * counts[row, column - 1] + new Modular(column, mod) * counts[row - 1, column];
                    counts[row, column] = add;
                }
            }

            yield return counts[lastHeight, lastWidth].Value;
        }
    }
}
