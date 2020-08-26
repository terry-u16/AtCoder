using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ForciaVirtualContest014.Algorithms;
using ForciaVirtualContest014.Collections;
using ForciaVirtualContest014.Extensions;
using ForciaVirtualContest014.Numerics;
using ForciaVirtualContest014.Questions;

namespace ForciaVirtualContest014.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc005/tasks/agc005_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            Array.Sort(a);
            var min = a[0];
            var minCount = a.Count(ai => ai == min);

            if (minCount <= 2)
            {
                if (!CheckDiffOne(a) || !CheckBothEdge(a, min))
                {
                    yield return "Impossible";
                }
                else
                {
                    var distinctCount = a.Distinct().Count();

                    if (minCount == 1 && distinctCount == min + 1)
                    {
                        yield return "Possible";
                    }
                    else if (minCount == 2 && distinctCount == min)
                    {
                        yield return "Possible";
                    }
                    else
                    {
                        yield return "Impossible";
                    }
                }
            }
            else
            {
                yield return "Impossible";
            }
        }

        bool CheckDiffOne(int[] a)
        {
            for (int i = 0; i + 1 < a.Length; i++)
            {
                if (a[i + 1] - a[i] > 1)
                {
                    return false;
                }
            }
            return true;
        }

        bool CheckBothEdge(int[] a, int min)
        {
            var count = new int[101];
            foreach (var ai in a)
            {
                count[ai]++;
            }

            for (int i = 0; i < count.Length; i++)
            {
                if (i != min && count[i] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
