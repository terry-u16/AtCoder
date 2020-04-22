using AtCoderBeginnerContest144.Questions;
using AtCoderBeginnerContest144.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest144.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();
            long a;

            for (a = (int)Math.Sqrt(n); a >= 1; a--)
            {
                if (n % a == 0)
                {
                    break;
                }
            }

            var b = n / a;

            yield return a + b - 2;
        }
    }
}
