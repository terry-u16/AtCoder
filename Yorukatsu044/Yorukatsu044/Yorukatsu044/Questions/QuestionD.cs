using Yorukatsu044.Questions;
using Yorukatsu044.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu044.Questions
{
    /// <summary>
    /// ABC112 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];
            var divisiors = GetDivisiors(m);

            yield return divisiors.Where(div => (long)div * n <= m).Max();
        }

        IEnumerable<int> GetDivisiors(int n)
        {
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    var another = n / i;
                    if (another != i)
                    {
                        yield return another;
                    }
                }
            }
        }
    }
}
