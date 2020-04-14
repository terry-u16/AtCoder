using AtCoderBeginnerContest153.Questions;
using AtCoderBeginnerContest153.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest153.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hn = inputStream.ReadIntArray();
            var h = hn[0];
            var n = hn[1];

            var magics = new Magic[n];
            for (int i = 0; i < magics.Length; i++)
            {
                var ab = inputStream.ReadIntArray();
                magics[i] = new Magic(ab[0], ab[1]);
            }

            var dpMinMP = Enumerable.Repeat(long.MaxValue >> 4, h + magics.Max(m => m.Attack)).ToArray();   // オーバーキルの可能性あり
            dpMinMP[0] = 0; // init

            for (int totalDamage = 1; totalDamage < dpMinMP.Length; totalDamage++)
            {
                foreach (var magic in magics)
                {
                    var previousTotalDamage = totalDamage - magic.Attack;

                    if (previousTotalDamage >= 0)
                    {
                        UpdateWhenSmall(ref dpMinMP[totalDamage], dpMinMP[previousTotalDamage] + magic.MP);
                    }
                }
            }

            var minMP = long.MaxValue;
            for (int i = h; i < dpMinMP.Length; i++)
            {
                if (dpMinMP[i] < minMP)
                {
                    minMP = dpMinMP[i];
                }
            }

            yield return minMP;
        }

        protected void UpdateWhenSmall<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) < 0)
            {
                value = other;
            }
        }

        protected void UpdateWhenLarge<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) > 0)
            {
                value = other;
            }
        }
    }

    public struct Magic
    {
        public int Attack { get; }
        public int MP { get; }

        public Magic(int attack, int mp)
        {
            Attack = attack;
            MP = mp;
        }
    }
}
