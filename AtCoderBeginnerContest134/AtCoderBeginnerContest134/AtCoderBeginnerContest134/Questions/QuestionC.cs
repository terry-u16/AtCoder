using AtCoderBeginnerContest134.Questions;
using AtCoderBeginnerContest134.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest134.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = new int[n + 2];

            for (int i = 1; i <= n; i++)
            {
                a[i] = inputStream.ReadInt();
            }

            var leftMax = new int[n + 2];
            var rightMax = new int[n + 2];

            for (int i = 1; i <= n; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], a[i]);
            }

            for (int i = n; i >= 1; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], a[i]);
            }

            for (int i = 1; i <= n; i++)
            {
                yield return Math.Max(leftMax[i - 1], rightMax[i + 1]);
            }
        }
    }
}
