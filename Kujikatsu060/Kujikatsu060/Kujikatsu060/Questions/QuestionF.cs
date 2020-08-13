using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu060.Algorithms;
using Kujikatsu060.Collections;
using Kujikatsu060.Extensions;
using Kujikatsu060.Numerics;
using Kujikatsu060.Questions;

namespace Kujikatsu060.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc026/tasks/agc026_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (initial, buy, threshold, fill) = inputStream.ReadValue<long, long, long, long>();

                if (initial < buy)
                {
                    yield return "No";
                }
                else if (buy > fill)
                {
                    yield return "No";
                }
                else if (buy <= threshold)
                {
                    yield return "Yes";
                }
                else
                {
                    var gcd = NumericalAlgorithms.Gcd(buy, fill);
                    if (buy - gcd + initial % gcd > threshold)
                    {
                        yield return "No";
                    }
                    else
                    {
                        yield return "Yes";
                    }
                }
            }
        }
    }
}
