using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu039.Algorithms;
using Kujikatsu039.Collections;
using Kujikatsu039.Extensions;
using Kujikatsu039.Numerics;
using Kujikatsu039.Questions;

namespace Kujikatsu039.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc011/tasks/agc011_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadIntArray();
            var sizes = inputStream.ReadLongArray();
            Array.Sort(sizes);

            var last = -1;
            long currentSize = 0;
            for (int i = 0; i < sizes.Length; i++)
            {
                if (currentSize * 2 < sizes[i])
                {
                    last = i;
                }
                currentSize += sizes[i];
            }

            yield return sizes.Length - last;
        }
    }
}
