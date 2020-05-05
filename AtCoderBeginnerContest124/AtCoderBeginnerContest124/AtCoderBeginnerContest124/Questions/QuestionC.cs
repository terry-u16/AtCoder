using AtCoderBeginnerContest124.Questions;
using AtCoderBeginnerContest124.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest124.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine().Select(i => i - '0').ToArray();

            var beginZero = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != i % 2)
                {
                    beginZero++;
                }
            }

            var beginOne = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != (i + 1) % 2)
                {
                    beginOne++;
                }
            }

            yield return Math.Min(beginZero, beginOne);
        }
    }
}
