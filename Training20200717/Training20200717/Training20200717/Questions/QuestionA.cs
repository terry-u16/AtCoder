using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200717.Algorithms;
using Training20200717.Collections;
using Training20200717.Extensions;
using Training20200717.Numerics;
using Training20200717.Questions;

namespace Training20200717.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc006/tasks/abc006_3
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m) = inputStream.ReadValue<long, long>();

            for (long olds = 0; olds <= n; olds++)
            {
                var remainLegs = m - 3 * olds;
                var remainPeople = n - olds;
                if (remainLegs < 0)
                {
                    break;
                }

                if (remainLegs % 2 == 0 && remainLegs >= remainPeople * 2 && remainLegs <= remainPeople * 4)
                {
                    var adults = 2 * remainPeople - remainLegs / 2;
                    var babies = remainPeople - adults;
                    yield return $"{adults} {olds} {babies}";
                    yield break;
                }
            }

            yield return "-1 -1 -1";
        }
    }
}
