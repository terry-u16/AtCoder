using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu024.Algorithms;
using Kujikatsu024.Collections;
using Kujikatsu024.Extensions;
using Kujikatsu024.Numerics;
using Kujikatsu024.Questions;

namespace Kujikatsu024.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc126/tasks/abc126_e
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m) = inputStream.ReadValue<int, int>();
            var unionFind = new UnionFindTree(n);
            for (int i = 0; i < m; i++)
            {
                var (x, y, _) = inputStream.ReadValue<int, int, int>();
                x--;
                y--;
                unionFind.Unite(x, y);
            }

            yield return unionFind.Groups;
        }
    }
}
