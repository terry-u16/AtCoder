using Yorukatsu036.Questions;
using Yorukatsu036.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu036.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];

            if (k > (n - 1) * (n - 2) / 2)
            {
                yield return -1;
            }
            else
            {
                var edges = n - 1 + ((n - 1) * (n - 2) / 2 - k);
                yield return edges;

                var count = 0;
                for (int i = 1; i < n; i++)
                {
                    for (int j = i + 1; j <= n; j++)
                    {
                        yield return $"{i} {j}";
                        if (++count == edges)
                        {
                            yield break;
                        }
                    }
                }
            }
        }
    }
}
