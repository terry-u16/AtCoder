using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest171.Algorithms;
using AtCoderBeginnerContest171.Collections;
using AtCoderBeginnerContest171.Extensions;
using AtCoderBeginnerContest171.Numerics;
using AtCoderBeginnerContest171.Questions;

namespace AtCoderBeginnerContest171.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var rewrite = new int[100001];
            foreach (var ai in a)
            {
                rewrite[ai]++;
            }

            long sum = a.Sum(i => (long)i);

            var queries = inputStream.ReadInt();
            for (int q = 0; q < queries; q++)
            {
                var (b, c) = inputStream.ReadValue<int, int>();
                sum += (long)(c - b) * rewrite[b];
                rewrite[c] += rewrite[b];
                rewrite[b] = 0;

                yield return sum;
            }
        }
    }
}
