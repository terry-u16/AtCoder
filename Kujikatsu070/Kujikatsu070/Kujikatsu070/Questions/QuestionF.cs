using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu070.Algorithms;
using Kujikatsu070.Collections;
using Kujikatsu070.Extensions;
using Kujikatsu070.Numerics;
using Kujikatsu070.Questions;

namespace Kujikatsu070.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/dwacon5th-prelims/tasks/dwacon5th_prelims_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            _ = inputStream.ReadInt();
            var ks = inputStream.ReadIntArray();

            var ds = new int[s.Length + 1];
            var ms = new int[s.Length + 1];
            for (int i = 0; i < s.Length; i++)
            {
                ds[i + 1] = ds[i] + (s[i] == 'D' ? 1 : 0);
                ms[i + 1] = ms[i] + (s[i] == 'M' ? 1 : 0);
            }

            foreach (var k in ks)
            {
                var queue = new Queue<int>();
                long dCount = 0;
                long dmCount = 0;
                long dmcCount = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if (queue.Count > 0 && queue.Peek() == i)
                    {
                        queue.Dequeue();
                        dCount--;
                        dmCount -= ms[i] - ms[i - k];
                    }

                    if (s[i] == 'D')
                    {
                        dCount++;
                        queue.Enqueue(i + k);
                    }
                    else if (s[i] == 'M')
                    {
                        dmCount += dCount;
                    }
                    else if (s[i] == 'C')
                    {
                        dmcCount += dmCount;
                    }
                }

                yield return dmcCount;
            }
        }
    }
}
