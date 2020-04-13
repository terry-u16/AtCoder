using EducationalDPContest.Questions;
using EducationalDPContest.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalDPContest.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();

            var dpLongest = new int[s.Length + 1, t.Length + 1];

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= t.Length; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        UpdateWhenLarge(ref dpLongest[i, j], dpLongest[i - 1, j - 1] + 1);
                    }

                    UpdateWhenLarge(ref dpLongest[i, j], dpLongest[i - 1, j]);
                    UpdateWhenLarge(ref dpLongest[i, j], dpLongest[i, j - 1]);
                }
            }

            var result = new LinkedList<char>();

            int k = s.Length;
            int l = t.Length;

            while (k > 0 && l > 0)
            {
                if (dpLongest[k, l] == dpLongest[k - 1, l])
                {
                    k--;
                }
                else if (dpLongest[k, l] == dpLongest[k, l - 1])
                {
                    l--;
                }
                else
                {
                    k--;
                    l--;
                    result.AddFirst(s[k]);
                }
            }

            yield return string.Concat(result);
        }
    }
}
