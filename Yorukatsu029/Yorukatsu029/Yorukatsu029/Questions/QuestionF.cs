using Yorukatsu029.Questions;
using Yorukatsu029.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu029.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nab = inputStream.ReadIntArray();
            var n = nab[0];
            var a = nab[1];
            var b = nab[2];
            var values = inputStream.ReadLongArray();

            var totalValues = new ValueAndCount[n + 1, b + 1];
            totalValues[0, 0] = new ValueAndCount(0, 1);

            for (int candidate = 1; candidate <= n; candidate++)
            {
                for (int selected = 0; selected <= b; selected++)
                {
                    // 選ばない
                    totalValues[candidate, selected] = totalValues[candidate - 1, selected];

                    if (selected > 0)
                    {
                        // 選ぶ
                        var previous = totalValues[candidate - 1, selected - 1];
                        var current = new ValueAndCount(previous.Value + values[candidate - 1], previous.Count);
                        var compare = current.CompareTo(totalValues[candidate, selected]);

                        if (compare > 0)
                        {
                            totalValues[candidate, selected] = new ValueAndCount(current.Value, previous.Count);
                        }
                        else if (compare == 0)
                        {
                            totalValues[candidate, selected] = new ValueAndCount(current.Value, totalValues[candidate, selected].Count + previous.Count);
                        }
                    }
                }
            }

            decimal maxAverage = decimal.MinValue;
            long count = 0;

            for (int selected = a; selected <= b; selected++)
            {
                var current = totalValues[n, selected];
                var average = (decimal)current.Value / selected;
                if (average.CompareTo(maxAverage) > 0)
                {
                    maxAverage = average;
                    count = current.Count;
                }
                else if (average.CompareTo(maxAverage) == 0)
                {
                    count += current.Count;
                }
            }

            yield return maxAverage;
            yield return count;
        }

        struct ValueAndCount : IComparable<ValueAndCount>
        {
            public long Value { get; }
            public long Count { get; }

            public ValueAndCount(long value, long count)
            {
                Value = value;
                Count = count;
            }

            public int CompareTo(ValueAndCount other) => Value.CompareTo(other.Value);

            public override string ToString() => $"Value:{Value}, Count:{Count}";
        }
    }
}
