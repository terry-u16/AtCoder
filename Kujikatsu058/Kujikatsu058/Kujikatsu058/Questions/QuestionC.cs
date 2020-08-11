using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu058.Algorithms;
using Kujikatsu058.Collections;
using Kujikatsu058.Extensions;
using Kujikatsu058.Numerics;
using Kujikatsu058.Questions;

namespace Kujikatsu058.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc136/tasks/abc136_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var groups = new int[s.Length];
            var currentGroup = 0;
            bool descending = true;
            var bottoms = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (descending)
                {
                    if (s[i] == 'L')
                    {
                        bottoms.Add(i - 1);
                        bottoms.Add(i);
                        descending = false;
                    }
                }
                else
                {
                    if (s[i] == 'R')
                    {
                        currentGroup++;
                        descending = true;
                    }
                }

                groups[i] = currentGroup;
            }

            var results = new int[s.Length];
            foreach (var bottom in bottoms)
            {
                var group = groups[bottom];

                for (int i = bottom; i >= 0 && groups[i] == group; i -= 2)
                {
                    results[bottom]++;
                }

                for (int i = bottom + 2; i < groups.Length && groups[i] == group; i += 2)
                {
                    results[bottom]++;
                }
            }

            yield return results.Join(' ');
        }
    }
}
