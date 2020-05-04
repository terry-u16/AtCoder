using Yorukatsu031.Questions;
using Yorukatsu031.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu031.Questions
{
    /// <summary>
    /// ABC051 B
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ks = inputStream.ReadIntArray();
            var k = ks[0];
            var s = ks[1];

            int count = 0;
            for (int x = 0; x <= k; x++)
            {
                for (int y = 0; y <= k; y++)
                {
                    var z = s - (x + y);
                    if (z >= 0 && z <= k)
                    {
                        count++;
                    }
                }
            }

            yield return count;
        }
    }
}
