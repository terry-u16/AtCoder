using AtcoderBeginnerContest160.Questions;
using AtcoderBeginnerContest160.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtcoderBeginnerContest160.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        enum Color
        {
            Red = 0,
            Green = 1,
            None = 2
        }

        struct Apple : IComparable<Apple>
        {
            public int Value { get; set; }
            public Color Color { get; set; }

            public int CompareTo(Apple other)
            {
                var diff = Value - other.Value;
                if (diff != 0)
                {
                    return diff;
                }
                else
                {
                    return (int)Color - (int)other.Color;
                }
            }

            public override string ToString() => $"{Color}:{Value}";
        }

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var xyabc = inputStream.ReadIntArray();
            var x = xyabc[0];
            var y = xyabc[1];
            var p = inputStream.ReadIntArray();
            var q = inputStream.ReadIntArray();
            var r = inputStream.ReadIntArray();
            var whiteApples = r;  // alias

            var apples = new Apple[x + y];
            Array.Sort(p);
            Array.Reverse(p);   // 降順
            Array.Sort(q);
            Array.Reverse(q);   // 降順
            Array.Sort(r);
            Array.Reverse(r);   // 降順

            for (int i = 0; i < x; i++)
            {
                apples[i] = new Apple { Value = p[i], Color = Color.Red };
            }

            for (int i = 0; i < y; i++)
            {
                apples[i + x] = new Apple { Value = q[i], Color = Color.Green };
            }

            Array.Sort(apples);   // 昇順

            int whiteIndex = 0;
            for (int i = 0; i < apples.Length; i++)
            {
                if (apples[i].Value < whiteApples[whiteIndex])
                {
                    apples[i] = new Apple { Value = whiteApples[whiteIndex], Color = Color.None };
                    whiteIndex++;
                }
                if (whiteIndex >= whiteApples.Length)
                {
                    break;
                }
            }

            long total = 0;
            for (int i = 0; i < apples.Length; i++)
            {
                total += apples[i].Value;
            }
            yield return total;
        }
    }
}
