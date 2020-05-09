using AtCoderBeginnerContest122.Questions;
using AtCoderBeginnerContest122.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest122.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nq = inputStream.ReadIntArray();
            var queries = nq[1];
            var s = " " + inputStream.ReadLine();

            var count = new int[s.Length];

            for (int i = 1; i < s.Length; i++)
            {
                count[i] = count[i - 1];
                var isAC = s[i - 1] == 'A' && s[i] == 'C';
                if (isAC)
                {
                    count[i]++;
                }
            }

            for (int q = 0; q < queries; q++)
            {
                var lr = inputStream.ReadIntArray();
                var l = lr[0];
                var r = lr[1];
                yield return count[r] - count[l];
            }
        }
    }
}
