using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu025.Algorithms;
using Kujikatsu025.Collections;
using Kujikatsu025.Extensions;
using Kujikatsu025.Numerics;
using Kujikatsu025.Questions;

namespace Kujikatsu025.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc085/tasks/abc085_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, y) = inputStream.ReadValue<int, int>();

            for (int ichiman = 0; ichiman <= n; ichiman++)
            {
                for (int gosen = 0; gosen <= n; gosen++)
                {
                    var sen = n - ichiman - gosen;
                    if (sen < 0)
                    {
                        continue;
                    }
                    var total = 10000 * ichiman + 5000 * gosen + 1000 * sen;
                    if (total == y)
                    {
                        yield return $"{ichiman} {gosen} {sen}";
                        yield break;
                    }
                }
            }

            yield return "-1 -1 -1";
        }
    }
}
