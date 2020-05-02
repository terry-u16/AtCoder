using AtCoderBeginnerContest130.Questions;
using AtCoderBeginnerContest130.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest130.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadLongArray();
            var n = nk[0];
            var k = nk[1];
            var a = inputStream.ReadLongArray();

            var sum = new long[a.Length + 1];
            for (int i = 0; i < a.Length; i++)
            {
                sum[i + 1] = sum[i] + a[i];
            }

            int start = 0;
            int end = 0;
            long count = 0;

            while (end < sum.Length)
            {
                if (sum[end] - sum[start] >= k)
                {
                    count += sum.Length - end;
                    start++;
                }
                else
                {
                    end++;
                }
            }

            yield return count;
        }
    }
}
