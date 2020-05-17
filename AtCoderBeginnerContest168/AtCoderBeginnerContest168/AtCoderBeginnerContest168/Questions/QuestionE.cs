using AtCoderBeginnerContest168.Algorithms;
using AtCoderBeginnerContest168.Collections;
using AtCoderBeginnerContest168.Questions;
using AtCoderBeginnerContest168.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace AtCoderBeginnerContest168.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var sardinesCount = inputStream.ReadInt();
            var sardinesAB = new Dictionary<decimal, int>();
            var sardinesMinusBA = new Dictionary<decimal, int>();
            var one = new Modular(1);
            var two = new Modular(2);

            for (int i = 0; i < sardinesCount; i++)
            {
                var (a, b) = inputStream.ReadValue<long, long>();
                var ab = (decimal)a / b;
                var minusBA = (decimal)-b / a;
                if (sardinesAB.ContainsKey(ab))
                {
                    sardinesAB[ab]++;
                }
                else
                {
                    sardinesAB[ab] = 1;
                }

                if (sardinesMinusBA.ContainsKey(minusBA))
                {
                    sardinesMinusBA[minusBA]++;
                }
                else
                {
                    sardinesMinusBA[minusBA] = 1;
                }
            }

            var selected = 0;

            var list = new List<Modular>();
            var count = 0;

            foreach (var (ab, abCount) in sardinesAB.OrderBy(p => p.Key).Where(p => p.Key >= 0))
            {
                selected += abCount;
                if (ab != 0)
                {
                    if (sardinesMinusBA.ContainsKey(ab))
                    {
                        var minusBACount = sardinesMinusBA[ab];
                        list.Add(new Modular(abCount + minusBACount));
                        count += abCount + minusBACount;
                    }
                }
                else
                {
                    list.Add(new Modular(abCount));
                    count += abCount;
                }
            }

            var total = Modular.Pow(two, sardinesCount - count);

            foreach (var a in list)
            {
                total *= a;
            }

            yield return total.Value - 1;
        }

        struct Sardine : IComparable<Sardine>
        {
            public decimal AB => (decimal)_a / _b;
            public decimal BA => (decimal)_b / _a;
            private long _a;
            private long _b;

            public Sardine(long a, long b)
            {
                _a = a;
                _b = b;
            }

            public int CompareTo([AllowNull] Sardine other) => AB.CompareTo(other.AB);
        }
    }
}
