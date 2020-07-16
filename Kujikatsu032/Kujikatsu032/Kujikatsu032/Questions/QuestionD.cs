using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu032.Algorithms;
using Kujikatsu032.Collections;
using Kujikatsu032.Extensions;
using Kujikatsu032.Numerics;
using Kujikatsu032.Questions;

namespace Kujikatsu032.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc161/tasks/abc161_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();
            var lunluns = new Queue<long>();
            for (int i = 1; i < 10; i++)
            {
                lunluns.Enqueue(i);
            }

            var count = 0;
            while (true)
            {
                count++;
                var lunlun = lunluns.Dequeue();
                if (count == k)
                {
                    yield return lunlun;
                    yield break;
                }

                var mod = lunlun % 10;
                if (mod > 0)
                {
                    lunluns.Enqueue(lunlun * 10 + mod - 1);
                }

                lunluns.Enqueue(lunlun * 10 + mod);

                if (mod < 9)
                {
                    lunluns.Enqueue(lunlun * 10 + mod + 1);
                }
            }
        }
    }
}
