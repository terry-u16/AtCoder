using AtCoderBeginnerContest151.Questions;
using AtCoderBeginnerContest151.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest151.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];

            var ac = new bool[n];
            var wa = new int[n];

            for (int i = 0; i < m; i++)
            {
                var ps = inputStream.ReadStringArray();
                var p = int.Parse(ps[0]) - 1;
                var s = ps[1];

                if (s == "AC")
                {
                    ac[p] = true;
                }
                else if (!ac[p])    // AC済みでない
                {
                    wa[p]++;
                }
            }



            yield return $"{ac.Count(a => a)} {ac.Zip(wa, (a, w) => new { a, w }).Where(p => p.a).Sum(p => p.w)}";
        }
    }
}
