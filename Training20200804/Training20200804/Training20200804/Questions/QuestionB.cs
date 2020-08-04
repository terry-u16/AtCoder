using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200804.Algorithms;
using Training20200804.Collections;
using Training20200804.Extensions;
using Training20200804.Numerics;
using Training20200804.Questions;

namespace Training20200804.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc126/tasks/abc126_f
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (m, k) = inputStream.ReadValue<int, int>();
            var set = new HashSet<int>();

            if (k == 0)
            {
                var result = new List<int>();
                for (int i = 0; i < 1 << m; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        result.Add(i);
                    }
                }
                yield return result.Join(' ');
                yield break;
            }

            var composed1 = 0;
            for (int d = 0; d < m; d++)
            {
                var current = 1 << d;
                if ((current & k) > 0)
                {
                    set.Add(current);
                    composed1 |= current;
                }
            }

            var composed2 = 0;
            for (int i = 0; i < 1 << m; i++)
            {
                if (!set.Contains(i))
                {
                    composed2 ^= i;
                }
            }

            if (composed1 == k && composed2 == k)
            {
                var result = new List<int>();
                foreach (var i in set)
                {
                    result.Add(i);
                }
                for (int i = 0; i < 1 << m; i++)
                {
                    if (!set.Contains(i))
                    {
                        result.Add(i);
                    }
                }
                foreach (var i in set.Reverse())
                {
                    result.Add(i);
                }
                for (int i = (1 << m) - 1; i >= 0; i--)
                {
                    if (!set.Contains(i))
                    {
                        result.Add(i);
                    }
                }
                yield return result.Join(' ');
            }
            else
            {
                yield return -1;
            }
        }
    }
}
