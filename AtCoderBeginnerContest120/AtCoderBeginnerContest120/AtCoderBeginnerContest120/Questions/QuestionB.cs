using AtCoderBeginnerContest120.Questions;
using AtCoderBeginnerContest120.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest120.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abk = inputStream.ReadIntArray();
            var k = abk[2];

            var aDiv = new HashSet<int>(GetDivisiors(abk[0]));
            var bDiv = new HashSet<int>(GetDivisiors(abk[1]));

            aDiv.IntersectWith(bDiv);
            yield return aDiv.OrderByDescending(i => i).Skip(k - 1).First();
        }

        IEnumerable<int> GetDivisiors(int n)
        {
            for (int div = 1; div * div <= n; div++)
            {
                if (n % div == 0)
                {
                    yield return div;
                    if (div * div != n)
                    {
                        yield return n / div;
                    }
                }
            }
        }
    }
}
