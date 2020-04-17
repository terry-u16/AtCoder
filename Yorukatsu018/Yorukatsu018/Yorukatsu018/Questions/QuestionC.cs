using Yorukatsu018.Questions;
using Yorukatsu018.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu018.Questions
{
    /// <summary>
    /// ABC089 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var marchPeople = new Dictionary<char, int>();
            var march = new[] { 'M', 'A', 'R', 'C', 'H' };

            foreach (var c in march)
            {
                marchPeople.Add(c, 0);
            }

            for (int i = 0; i < n; i++)
            {
                var s = inputStream.ReadLine();
                if (march.Any(c => c == s[0]))
                {
                    marchPeople[s[0]] += 1;
                }
            }

            var total = 0L;

            for (int i = 0; i < march.Length; i++)
            {
                for (int j = i + 1; j < march.Length; j++)
                {
                    for (int k = j + 1; k < march.Length; k++)
                    {
                        total += GetCombination(marchPeople[march[i]], marchPeople[march[j]], marchPeople[march[k]]);
                    }
                }
            }

            yield return total;
        }

        private long GetCombination(long a, long b, long c) => a * b * c;
    }
}
