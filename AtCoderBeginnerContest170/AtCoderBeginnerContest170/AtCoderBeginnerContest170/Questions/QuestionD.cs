using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest170.Algorithms;
using AtCoderBeginnerContest170.Collections;
using AtCoderBeginnerContest170.Extensions;
using AtCoderBeginnerContest170.Numerics;
using AtCoderBeginnerContest170.Questions;

namespace AtCoderBeginnerContest170.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var duplicated = new HashSet<int>(a.GroupBy(i => i).Where(g => g.Count() > 1).Select(g => g.Key));

            a = a.Distinct().ToArray();

            Array.Sort(a);
            const int max = 1_000_000;

            var deleted = new bool[max + 1];
            foreach (var ai in a)
            {
                if (!deleted[ai])
                {
                    for (int i = 2; i * ai <= max; i++)
                    {
                        deleted[i * ai] = true;
                    }
                }
            }

            var count = a.Count(i => !duplicated.Contains(i) && !deleted[i]);

            yield return count;
        }
    }
}
