using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Training20200620.Algorithms;
using Training20200620.Collections;
using Training20200620.Extensions;
using Training20200620.Numerics;
using Training20200620.Questions;

namespace Training20200620.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc029/tasks/agc029_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var counter = new Counter<int>();
            foreach (var ai in a)
            {
                counter[ai]++;
            }

            var removed = new Counter<int>();
            long pairs = 0;
            foreach (var (value, count) in counter.OrderByDescending(p => p.key))
            {
                var c = count - removed[value];
                var other = GetOther(value);
                if (value != other)
                {
                    var currentPairs = Math.Min(c, counter[other] - removed[other]);
                    removed[other] += currentPairs;
                    pairs += currentPairs;
                }
                else
                {
                    pairs += c / 2;
                }
            }

            yield return pairs;
        }

        int GetOther(int n)
        {
            var count = 0;
            var i = n;
            while (i > 1)
            {
                i >>= 1;
                count++;
            }
            return (1 << (count + 1)) - n;
        }
    }
}
