using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu022.Algorithms;
using Kujikatsu022.Collections;
using Kujikatsu022.Extensions;
using Kujikatsu022.Numerics;
using Kujikatsu022.Questions;

namespace Kujikatsu022.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            const int NONE = 0;
            const int A = 1;
            const int C = 2;
            const int G = 3;
            const int T = 4;
            const int MAX = 5;

            var counts = new Modular[n + 1, MAX, MAX, MAX];
            counts[0, NONE, NONE, NONE] = Modular.One;

            for (int i = 0; i < n; i++)
            {
                for (int pre3 = NONE; pre3 < MAX; pre3++)
                {
                    for (int pre2 = NONE; pre2 < MAX; pre2++)
                    {
                        for (int pre = NONE; pre < MAX; pre++)
                        {
                            for (int current = A; current < MAX; current++)
                            {
                                if (current == C && ((pre3 == A && pre == G) || (pre2 == A && pre == G) || (pre3 == A && pre2 == G) || (pre2 == G && pre == A)))
                                {
                                    continue;
                                }
                                else if (current == G && pre2 == A && pre == C)
                                {
                                    continue;
                                }

                                counts[i + 1, current, pre, pre2] += counts[i, pre, pre2, pre3];
                            }
                        }
                    }
                }
            }

            var total = Modular.Zero;
            for (int pre2 = NONE; pre2 < MAX; pre2++)
            {
                for (int pre = NONE; pre < MAX; pre++)
                {
                    for (int current = A; current < MAX; current++)
                    {
                        total += counts[n, current, pre, pre2];
                    }
                }
            }
            yield return total.Value;
        }
    }
}
