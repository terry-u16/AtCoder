using Kujikatsu002.Questions;
using Kujikatsu002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu002.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nq = inputStream.ReadIntArray();
            var n = nq[0];
            var queries = nq[1];

            var s = inputStream.ReadLine();
            var left = new int[n + 1];
            var right = new int[n + 1];

            for (int i = 0; i + 1 < s.Length; i++)
            {
                if (s[i] == 'A' && s[i + 1] == 'C')
                {
                    left[i + 1]++;
                    right[i + 2]++;
                }
            }

            for (int i = 0; i + 1 < left.Length; i++)
            {
                left[i + 1] += left[i];
                right[i + 1] += right[i];
            }

            for (int q = 0; q < queries; q++)
            {
                var lr = inputStream.ReadIntArray();
                var l = lr[0];
                var r = lr[1];
                yield return right[r] - left[l - 1];
            }
        }
    }
}
