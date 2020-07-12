using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu028.Algorithms;
using Kujikatsu028.Collections;
using Kujikatsu028.Extensions;
using Kujikatsu028.Numerics;
using Kujikatsu028.Questions;

namespace Kujikatsu028.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var counts = new int[10, 10];

            for (int i = 1; i <= n; i++)
            {
                var top = i.ToString()[0] - '0';
                var bottom = i % 10;
                counts[top, bottom]++;
            }

            long count = 0;
            for (int beginA = 0; beginA < 10; beginA++)
            {
                for (int endA = 0; endA < 10; endA++)
                {
                    count += (long)counts[beginA, endA] * counts[endA, beginA];
                }
            }

            yield return count;
        }
    }
}
