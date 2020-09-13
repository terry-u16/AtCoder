using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu085.Algorithms;
using Kujikatsu085.Collections;
using Kujikatsu085.Extensions;
using Kujikatsu085.Numerics;
using Kujikatsu085.Questions;

namespace Kujikatsu085.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var l = inputStream.ReadLine().Select(c => c == '1').ToArray();
            var counts = new Modular[l.Length + 1, 2];
            const int Equal = 0;
            const int Less = 1;
            counts[0, Equal] = 1;

            for (int i = 0; i < l.Length; i++)
            {
                if (l[i])
                {
                    counts[i + 1, Equal] += counts[i, Equal] * 2;
                    counts[i + 1, Less] += counts[i, Equal];
                    counts[i + 1, Less] += counts[i, Less] * 3;
                }
                else
                {
                    counts[i + 1, Equal] += counts[i, Equal];
                    counts[i + 1, Less] += counts[i, Less] * 3;
                }
            }

            yield return counts[l.Length, Equal] + counts[l.Length, Less];
        }
    }
}
