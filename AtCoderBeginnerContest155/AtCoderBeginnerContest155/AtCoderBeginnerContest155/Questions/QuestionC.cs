using AtCoderBeginnerContest155.Questions;
using AtCoderBeginnerContest155.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest155.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var votes = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var s = inputStream.ReadLine();

                if (votes.ContainsKey(s))
                {
                    votes[s] += 1;
                }
                else
                {
                    votes.Add(s, 1);
                }
            }

            var max = votes.Max(p => p.Value);
            var elected = votes.Where(p => p.Value == max).Select(p => p.Key).ToArray();
            Array.Sort(elected, StringComparer.Ordinal);
            return elected;
        }
    }
}
