using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200729.Algorithms;
using Training20200729.Collections;
using Training20200729.Extensions;
using Training20200729.Numerics;
using Training20200729.Questions;

namespace Training20200729.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-formula-2014-quala/tasks/code_formula_2014_qualA_c
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int Max = 1000000;
            var (competitionCount, capacity) = inputStream.ReadValue<int, int>();

            var finals = new bool[Max];
            var highest = Enumerable.Repeat(int.MaxValue, Max).ToArray();
            var people = Enumerable.Repeat(0, capacity).Select(_ => new List<int>()).ToArray();

            for (int i = 1; i <= competitionCount; i++)
            {
                var a = inputStream.ReadIntArray();
                var fixes = new List<int>();
                var remaining = competitionCount - i;
                for (int j = 0; j < a.Length; j++)
                {
                    if (highest[a[j]] > j)
                    {
                        if (highest[a[j]] < people.Length)
                        {
                            people[highest[a[j]]].Remove(a[j]);
                        }

                        highest[a[j]] = j;
                        people[highest[a[j]]].Add(a[j]);
                    }
                }

                var prize = 0;
                bool bk = false;
                foreach (var list in people)
                {
                    foreach (var p in list)
                    {
                        prize++;
                        if (prize + remaining * highest[p] > capacity)
                        {
                            bk = true;
                            break;
                        }

                        if (!finals[p])
                        {
                            finals[p] = true;
                            fixes.Add(p);
                        }
                    }
                    if (bk)
                    {
                        break;
                    }
                }

                yield return fixes.OrderBy(f => f).Join(' ');
            }
        }
    }
}
