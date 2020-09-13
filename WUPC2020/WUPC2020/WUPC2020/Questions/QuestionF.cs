using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WUPC2020.Extensions;
using WUPC2020.Questions;

namespace WUPC2020.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();
            long max = long.MinValue;

            for (int jumps = 0; (1L << jumps) <= n; jumps++)
            {
                var pow = 1L << jumps;
                var last2 = 0L;
                var last1 = n / pow * pow;
                var coins = last1;

                for (int j = 0; j < jumps; j++)
                {
                    var med = Math.Abs(last1 - last2) / 2 + Math.Min(last1, last2);
                    coins += med;
                    last2 = last1;
                    last1 = med;
                }

                max = Math.Max(max, coins);
            }

            yield return max;
        }
    }
}
