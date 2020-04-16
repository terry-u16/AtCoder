using AtCoderBeginnerContest150.Questions;
using AtCoderBeginnerContest150.Extensions;
using AtCoderBeginnerContest150.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest150.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var permutation = Enumerable.Range(1, n).ToArray();
            var p = inputStream.ReadIntArray();
            var q = inputStream.ReadIntArray();

            var a = 0;
            var b = 0;
            var count = 0;

            foreach (var perm in BasicAlgorithms.GetPermutations(permutation, true))
            {
                if (perm.SequenceEqual(p))
                {
                    a = count;
                }
                if (perm.SequenceEqual(q))
                {
                    b = count;
                }
                count++;
            }

            yield return Math.Abs(a - b);
        }
    }
}
