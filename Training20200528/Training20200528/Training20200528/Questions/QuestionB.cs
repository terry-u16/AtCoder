using Training20200528.Questions;
using Training20200528.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200528.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc104/tasks/abc104_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var dg = inputStream.ReadIntArray();
            var maxDifficulty = dg[0];
            var requiredScore = dg[1];
            var problems = new int[maxDifficulty];
            var bonuses = new int[maxDifficulty];

            for (int difficulty = 0; difficulty < maxDifficulty; difficulty++)
            {
                var pc = inputStream.ReadIntArray();
                problems[difficulty] = pc[0];
                bonuses[difficulty] = pc[1];
            }

            var minSolved = int.MaxValue;
            for (BitSet flag = BitSet.Zero; flag < BitSet.At(maxDifficulty); flag++)
            {
                var solved = 0;
                var score = 0;
                for (int difficulty = 0; difficulty < maxDifficulty; difficulty++)
                {
                    if (flag[difficulty])
                    {
                        score += (difficulty + 1) * 100 * problems[difficulty] + bonuses[difficulty];
                        solved += problems[difficulty];
                    }
                }

                for (int difficulty = maxDifficulty - 1; difficulty >= 0; difficulty--)
                {
                    if (score >= requiredScore)
                    {
                        break;
                    }

                    var scorePerQuestion = (difficulty + 1) * 100;

                    if (!flag[difficulty])
                    {
                        var toSolve = Math.Min((requiredScore - score + scorePerQuestion - 1) / scorePerQuestion, problems[difficulty] - 1);
                        solved += toSolve;
                        score += scorePerQuestion * toSolve;
                    }
                }

                if (score >= requiredScore)
                {
                    minSolved = Math.Min(minSolved, solved);
                }
            }

            yield return minSolved;
        }

        public struct BitSet : IEquatable<BitSet>
        {
            readonly uint _value;

            public BitSet(uint value)
            {
                _value = value;
            }
            public bool this[int digit]
            {
                get { return ((_value >> digit) & 1) > 0; }
            }
            public bool Any => _value > 0;
            public bool None => _value == 0;
            public BitSet SetAt(int digit, bool value) => value ? new BitSet(_value | (1u << digit)) : new BitSet(_value & ~(1u << digit));
            public BitSet Lsb() { unchecked { return new BitSet(_value & (uint)-(int)_value); } }
            public BitSet Reverse()
            {
                unchecked
                {
                    uint v = _value;
                    v = (v & 0x55555555) << 1 | (v >> 1 & 0x55555555);
                    v = (v & 0x33333333) << 2 | (v >> 2 & 0x33333333);
                    v = (v & 0x0f0f0f0f) << 4 | (v >> 4 & 0x0f0f0f0f);
                    v = (v & 0x00ff00ff) << 8 | (v >> 8 & 0x00ff00ff);
                    v = (v & 0x0000ffff) << 16 | (v >> 16 & 0x0000ffff);
                    return new BitSet(v);
                }
            }
            public int Count()
            {
                unchecked
                {
                    // Hardware Intrinsics未使用
                    uint v = _value;
                    v = (v & 0x55555555) + (v >> 1 & 0x55555555);
                    v = (v & 0x33333333) + (v >> 2 & 0x33333333);
                    v = (v & 0x0f0f0f0f) + (v >> 4 & 0x0f0f0f0f);
                    v = (v & 0x00ff00ff) + (v >> 8 & 0x00ff00ff);
                    v = (v & 0x0000ffff) + (v >> 16 & 0x0000ffff);
                    return (int)v;
                }
            }

            public static BitSet Zero => new BitSet(0);
            public static BitSet One => new BitSet(1);
            public static BitSet All => new BitSet(~0u);
            public static BitSet At(int digit) => new BitSet(1u << digit);
            public static BitSet CreateMask(int digit) => new BitSet((1u << digit) - 1);
            public static BitSet operator ++(BitSet bitSet) => new BitSet(bitSet._value + 1);
            public static BitSet operator --(BitSet bitSet) => new BitSet(bitSet._value - 1);
            public static BitSet operator ~(BitSet bitSet) => new BitSet(~bitSet._value);
            public static BitSet operator &(BitSet left, BitSet right) => new BitSet(left._value & right._value);
            public static BitSet operator |(BitSet left, BitSet right) => new BitSet(left._value | right._value);
            public static BitSet operator ^(BitSet left, BitSet right) => new BitSet(left._value ^ right._value);
            public static BitSet operator <<(BitSet bitSet, int n) => new BitSet(bitSet._value << n);
            public static BitSet operator >>(BitSet bitSet, int n) => new BitSet(bitSet._value >> n);
            public static bool operator <(BitSet left, BitSet right) => left._value < right._value;
            public static bool operator <=(BitSet left, BitSet right) => left._value <= right._value;
            public static bool operator >(BitSet left, BitSet right) => left._value > right._value;
            public static bool operator >=(BitSet left, BitSet right) => left._value >= right._value;
            public static bool operator ==(BitSet left, BitSet right) => left.Equals(right);
            public static bool operator !=(BitSet left, BitSet right) => !(left == right);
            public static implicit operator uint(BitSet bitSet) => bitSet._value;

            public override bool Equals(object obj) => obj is BitSet && Equals((BitSet)obj);
            public bool Equals(BitSet other) => _value == other._value;
            public override string ToString() => Convert.ToString(_value, 2);
            public override int GetHashCode() => _value.GetHashCode();
        }

    }
}
