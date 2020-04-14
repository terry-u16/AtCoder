using AtCoderBeginnerContest152.Questions;
using AtCoderBeginnerContest152.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest152.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var counts = new int[9, 9];

            for (int i = 1; i <= n; i++)
            {
                var top = GetTopDigit(i);
                var bottom = i % 10;
                if (top > 0 && bottom > 0)
                {
                    counts[top - 1, bottom - 1]++;
                }
            }

            var count = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    count += counts[i, j] * counts[j, i];
                }
            }

            yield return count;
        }

        int GetTopDigit(int n)
        {
            while (n >= 10)
            {
                n /= 10;
            }
            return n;
        }
    }
}
