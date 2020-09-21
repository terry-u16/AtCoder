using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu095.Algorithms;
using Kujikatsu095.Collections;
using Kujikatsu095.Extensions;
using Kujikatsu095.Numerics;
using Kujikatsu095.Questions;

namespace Kujikatsu095.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc157/tasks/abc157_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (people, friends, blocks) = inputStream.ReadValue<int, int, int>();
            var uf = new UnionFindTree(people);

            var friendsCount = new int[people];

            for (int i = 0; i < friends; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                uf.Unite(a, b);
                friendsCount[a]++;
                friendsCount[b]++;
            }

            var blockCounts = new int[people];

            for (int i = 0; i < blocks; i++)
            {
                var (c, d) = inputStream.ReadValue<int, int>();
                c--;
                d--;
                if (uf.IsInSameGroup(c, d))
                {
                    blockCounts[c]++;
                    blockCounts[d]++;
                }
            }

            yield return Enumerable.Range(0, people).Select(i => uf.GetGroupSizeOf(i) - friendsCount[i] - blockCounts[i] - 1).Join(' ');
        }
    }
}
