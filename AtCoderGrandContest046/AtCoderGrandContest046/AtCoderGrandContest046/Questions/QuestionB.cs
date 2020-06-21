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
            Modular.Mod = 998244353;
            var (initialHeight, initialWidth, lastHeight, lastWidth) = inputStream.ReadValue<int, int, int, int>();
            var counts = new Modular[lastHeight + 1, lastWidth + 1];
            var minuses = new Modular[lastHeight + 1, lastWidth + 1];

            counts[initialHeight, initialWidth] = Modular.One;

            for (int row = initialHeight; row <= lastHeight; row++)
            {
                for (int column = initialWidth; column <= lastWidth; column++)
                {
                    if (row == initialHeight && column == initialWidth)
                    {
                        continue;
                    }

                    counts[row, column] = row * counts[row, column - 1] + column * counts[row - 1, column]
                        - (row - 1) * (column - 1) * counts[row - 1, column - 1];
                }
            }

            yield return counts[lastHeight, lastWidth].Value;
        }
    }
}
