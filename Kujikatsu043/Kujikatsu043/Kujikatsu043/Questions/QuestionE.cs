using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu043.Algorithms;
using Kujikatsu043.Collections;
using Kujikatsu043.Extensions;
using Kujikatsu043.Numerics;
using Kujikatsu043.Questions;

namespace Kujikatsu043.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/sumitrust2019/tasks/sumitb2019_f
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var times = inputStream.ReadIntArray();
            var takahashiSpeeds = inputStream.ReadLongArray();
            var aokiSpeeds = inputStream.ReadLongArray();
            var relativeSpeeds = takahashiSpeeds.Zip(aokiSpeeds).Select(p => p.First - p.Second).ToArray();
            var relativeDistances = relativeSpeeds.Zip(times).Select(p => p.First * p.Second).ToArray();

            if (relativeDistances[0] > 0)
            {
                relativeDistances = relativeDistances.Select(d => -d).ToArray();
            }

            var cycleDiff = relativeDistances.Sum();

            if (cycleDiff < 0)
            {
                yield return 0;
            }
            else if (cycleDiff == 0)
            {
                yield return "infinity";
            }
            else
            {
                var cycles = -relativeDistances[0] / cycleDiff;

                if (-relativeDistances[0] % cycleDiff == 0)
                {
                    yield return 2 * cycles;
                }
                else
                {
                    yield return 2 * cycles + 1;
                }
            }
        }
    }
}
