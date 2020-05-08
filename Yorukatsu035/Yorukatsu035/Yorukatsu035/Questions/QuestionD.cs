using Yorukatsu035.Questions;
using Yorukatsu035.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu035.Questions
{
    /// <summary>
    /// ABC153 E
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hn = inputStream.ReadIntArray();
            var hp = hn[0];
            var magicVariation = hn[1];

            var magics = new Magic[magicVariation];

            for (int i = 0; i < magicVariation; i++)
            {
                var ab = inputStream.ReadIntArray();
                var attack = ab[0];
                var mp = ab[1];

                magics[i] = new Magic(attack, mp);
            }

            var mps = new long[hp + 10000];
            for (int i = 1; i < mps.Length; i++)
            {
                mps[i] = 1L << 50;
            }

            for (int damage = 1; damage < mps.Length; damage++)
            {
                foreach (var magic in magics)
                {
                    var lastHP = damage - magic.Attack;
                    if (lastHP >= 0)
                    {
                        UpdateWhenSmall(ref mps[damage], mps[lastHP] + magic.MP);
                    }
                }
            }

            yield return mps.Skip(hp).Min();
        }

        public static void UpdateWhenSmall<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) < 0)
            {
                value = other;
            }
        }


        struct Magic
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
}
