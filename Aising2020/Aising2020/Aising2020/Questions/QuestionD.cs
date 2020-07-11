using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aising2020.Algorithms;
using Aising2020.Collections;
using Aising2020.Extensions;
using Aising2020.Numerics;
using Aising2020.Questions;
using System.Collections;

namespace Aising2020.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var x = inputStream.ReadLine();
            var firstPopCount = x.Count(c => c == '1');

            var lessPopCount = firstPopCount - 1;
            var morePopCount = firstPopCount + 1;
            bool lessIsZero = false;

            if (lessPopCount == -1)
            {
                lessPopCount = 100;
            }
            else if (lessPopCount == 0)
            {
                lessIsZero = true;
                lessPopCount = 1;
            }

            var lessMods = new int[n];
            var moreMods = new int[n];

            var less = 1 % lessPopCount;
            var more = 1 % morePopCount;
            lessMods[^1] = less;
            moreMods[^1] = more;
            for (int i = 1; i < n; i++)
            {
                less = (less << 1) % lessPopCount;
                more = (more << 1) % morePopCount;
                lessMods[^(i + 1)] = less;
                moreMods[^(i + 1)] = more;
            }

            var lessModBase = 0;
            var moreModBase = 0;
            for (int i = 0; i < n; i++)
            {
                if (x[i] == '1')
                {
                    lessModBase = (lessModBase + lessMods[i]) % lessPopCount;
                    moreModBase = (moreModBase + moreMods[i]) % morePopCount;
                }
            }

            var first = new int[n];
            for (int i = 0; i < first.Length; i++)
            {
                if (x[i] == '1')
                {
                    if (!lessIsZero)
                    {
                        first[i] = (lessModBase - lessMods[i] + lessPopCount) % lessPopCount;
                    }
                    else
                    {
                        first[i] = -1;
                    }
                }
                else
                {
                    first[i] = (moreModBase + moreMods[i]) % morePopCount;
                }
            }

            for (int i = 0; i < first.Length; i++)
            {
                if (lessIsZero && x[i] == '1')
                {
                    yield return 0;
                }
                else
                {
                    yield return Operate(first[i]) + 1;
                }
            }
        }

        int Operate(int x)
        {
            if (x == 0)
            {
                return 0;
            }
            else
            {
                var current = x;
                var popCount = 0;
                while (current > 0)
                {
                    if ((current & 1) > 0)
                    {
                        popCount++;
                    }
                    current >>= 1;
                }
                return Operate(x % popCount) + 1;
            }
        }
    }
}
