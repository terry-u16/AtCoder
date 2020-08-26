using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu073.Algorithms;
using Kujikatsu073.Collections;
using Kujikatsu073.Extensions;
using Kujikatsu073.Numerics;
using Kujikatsu073.Questions;

namespace Kujikatsu073.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/tenka1-2017/tasks/tenka1_2017_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var seisuus = new Seisuu[n];
            for (int i = 0; i < seisuus.Length; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                seisuus[i] = new Seisuu(a, b);
            }

            var max = Buy(k, seisuus);

            for (int i = 1; i < 32; i++)
            {
                var mask = unchecked(0x7FFFFFFF << i);
                var restriction = k & mask;
                restriction -= 1;
                if (restriction >= 0)
                {
                    max = Math.Max(max, Buy(restriction, seisuus));
                }
            }

            yield return max;
        }

        long Buy(int k, Seisuu[] seisuus)
        {
            var value = 0L;

            foreach (var seisuu in seisuus)
            {
                if ((k | seisuu.Integer) == k)
                {
                    value += seisuu.Value;
                }
            }

            return value;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Seisuu
        {
            public int Integer { get; }
            public int Value { get; }

            public Seisuu(int integer, int value)
            {
                Integer = integer;
                Value = value;
            }

            public void Deconstruct(out int integer, out int value) => (integer, value) = (Integer, Value);
            public override string ToString() => $"{nameof(Integer)}: {Integer}, {nameof(Value)}: {Value}";
        }
    }
}
