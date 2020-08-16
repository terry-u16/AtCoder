using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200723.Algorithms;
using Training20200723.Collections;
using Training20200723.Extensions;
using Training20200723.Numerics;
using Training20200723.Questions;
using Training20200723.Graphs;

namespace Training20200723.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc041/tasks/abc041_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (rabbits, statements) = inputStream.ReadValue<int, int>();
            var counts = new long[1 << rabbits];
            var ngSets = new bool[rabbits, rabbits];

            for (int i = 0; i < statements; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                x--;
                y--;
                ngSets[y, x] = true;
            }

            counts[0] = 1;

            for (var finished = BitSet.One; finished < (1 << rabbits); finished++)
            {
                for (int remove = 0; remove < rabbits; remove++)
                {
                    if (!finished[remove])
                    {
                        continue;
                    }

                    var ok = true;

                    for (int notFinished = 0; notFinished < rabbits; notFinished++)
                    {
                        if (!finished[notFinished] && ngSets[notFinished, remove])
                        {
                            ok = false;
                            break;
                        }
                    }

                    if (ok)
                    {
                        counts[finished] += counts[finished ^ (1 << remove)];
                    }
                }
            }

            yield return counts[(1 << rabbits) - 1];
        }
    }
}
