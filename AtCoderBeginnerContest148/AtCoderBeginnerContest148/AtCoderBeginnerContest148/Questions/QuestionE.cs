using AtCoderBeginnerContest148.Questions;
using AtCoderBeginnerContest148.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest148.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();

            if (n % 2 == 0)
            {
                long count = 0;
                n = n / 2;
                for (int i = 1; i <= 27; i++)
                {
                    var frac = Enumerable.Repeat(5L, i).Aggregate((a, b) => a * b);
                    count += n / frac;
                }
                yield return count;
            }
            else
            {
                yield return 0;
            }
        }
    }
}
