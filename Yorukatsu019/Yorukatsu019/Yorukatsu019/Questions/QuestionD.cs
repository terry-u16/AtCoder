using Yorukatsu019.Questions;
using Yorukatsu019.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu019.Questions
{
    /// <summary>
    /// ABC130 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadLongArray();
            var n = nk[0];
            var k = nk[1];
            var a = inputStream.ReadLongArray();

            int start = 0;
            int end = 0;
            long count = 0;
            long sum = a[end];

            while (start < a.Length)
            {
                if (start <= end && sum >= k)
                {
                    count += a.Length - end;
                    sum -= a[start++];
                }
                else
                {
                    if (end < a.Length - 1)
                    {
                        sum += a[++end];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            yield return count;
        }
    }
}
