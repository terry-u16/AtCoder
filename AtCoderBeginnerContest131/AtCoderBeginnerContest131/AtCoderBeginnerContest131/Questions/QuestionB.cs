using AtCoderBeginnerContest131.Questions;
using AtCoderBeginnerContest131.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest131.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nl = inputStream.ReadIntArray();
            var n = nl[0];
            var l = nl[1];

            var originalTaste = Enumerable.Range(0, n).Sum(i => l + i);

            var nearest = 1 << 30;
            for (int i = 0; i < n; i++)
            {
                var taste = Enumerable.Range(0, n).Where(m => m != i).Sum(m => l + m);
                if (Math.Abs(originalTaste - taste) < Math.Abs(originalTaste - nearest))
                {
                    nearest = taste;
                }
            }

            yield return nearest;
        }
    }
}
