using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu094.Algorithms;
using Kujikatsu094.Collections;
using Kujikatsu094.Extensions;
using Kujikatsu094.Numerics;
using Kujikatsu094.Questions;

namespace Kujikatsu094.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc046/tasks/agc046_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadInt();
            var deg = 0;
            var count = 0;

            while (true)
            {
                count++;
                deg += x;

                if (deg % 360 == 0)
                {
                    yield return count;
                    yield break;
                }
            }
        }
    }
}
