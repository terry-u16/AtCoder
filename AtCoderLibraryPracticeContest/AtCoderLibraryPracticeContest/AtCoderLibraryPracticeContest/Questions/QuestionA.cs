using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderLibraryPracticeContest.Extensions;
using AtCoderLibraryPracticeContest.Questions;
using AtCoder;

namespace AtCoderLibraryPracticeContest.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/practice2/tasks/practice2_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, queries) = inputStream.ReadValue<int, int>();
            var dsu = new DSU(n);

            for (int q = 0; q < queries; q++)
            {
                var (t, u, v) = inputStream.ReadValue<int, int, int>();
                if (t == 0)
                {
                    dsu.Merge(u, v);
                }
                else
                {
                    yield return dsu.Same(u, v) ? 1 : 0;
                }
            }
        }
    }
}
