using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu059.Algorithms;
using Kujikatsu059.Collections;
using Kujikatsu059.Extensions;
using Kujikatsu059.Numerics;
using Kujikatsu059.Questions;

namespace Kujikatsu059.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/m-solutions2020/tasks/m_solutions2020_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var prices = inputStream.ReadIntArray();
            long wallet = 1000;
            long stocks = 0;

            for (int i = 0; i + 1 < prices.Length; i++)
            {
                wallet += stocks * prices[i];
                stocks = 0;
                if (prices[i] < prices[i + 1])
                {
                    stocks += wallet / prices[i];
                    wallet -= stocks * prices[i];
                }
            }

            wallet += stocks * prices[^1];
            yield return wallet;
        }
    }
}
