using AtCoderBeginnerContest146.Questions;
using AtCoderBeginnerContest146.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest146.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];
            var a = inputStream.ReadIntArray();

            var cumulativeSums = new int[n];
            var cumulativeSumsCount = new int[k];

            var sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum = (sum + a[i]) % k;
                cumulativeSums[i] = sum;
                cumulativeSumsCount[sum]++;
            }

            throw new NotImplementedException();
        }
    }
}
