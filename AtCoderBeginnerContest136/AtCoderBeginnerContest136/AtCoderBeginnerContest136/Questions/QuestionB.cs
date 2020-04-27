using AtCoderBeginnerContest136.Questions;
using AtCoderBeginnerContest136.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest136.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            yield return Enumerable.Range(1, n).Count(i => GetDigitCount(i) % 2 == 1);
        }

        int GetDigitCount(int n)
        {
            var digit = 1;
            while (n >= 10)
            {
                n /= 10;
                digit++;
            }
            return digit;
        }
    }
}
