using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderGrandContest047.Algorithms;
using AtCoderGrandContest047.Collections;
using AtCoderGrandContest047.Extensions;
using AtCoderGrandContest047.Numerics;
using AtCoderGrandContest047.Questions;

namespace AtCoderGrandContest047.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = new string[n];
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = inputStream.ReadLine().Reverse().Join();
            }

            Array.Sort(s, (l, r) => l.Length - r.Length);

            long result = 0;
            var lastCharFlags = new Dictionary<(ulong, ulong), int>();

            foreach (var si in s)
            {
                var rollingHash = new RollingHash(si);
                int flag = 0;
                for (int length = si.Length - 1; length >= 0; length--)
                {
                    flag |= 1 << (si[length] - 'a');
                    var hash = rollingHash[..length];
                    if (lastCharFlags.ContainsKey(hash))
                    {
                        result += PopCount(flag & lastCharFlags[hash]);
                    }
                }

                var prefixHash = rollingHash[..(si.Length - 1)];
                if (lastCharFlags.ContainsKey(prefixHash))
                {
                    lastCharFlags[prefixHash] |= 1 << (si[^1] - 'a');
                }
                else
                {
                    lastCharFlags[prefixHash] = 1 << (si[^1] - 'a');
                }
            }

            yield return result;
        }

        int PopCount(int n)
        {
            var result = 0;
            while (n > 0)
            {
                result += n & 1;
                n >>= 1;
            }
            return result;
        }

        /// <summary>
        /// 参考: https://qiita.com/keymoon/items/11fac5627672a6d6a9f6
        /// ジェネリクスに対応させるにはGetHashCode()を足していく？実装によっては重そうなのでとりあえずパス。
        /// </summary>
        class RollingHash
        {
            const ulong Mask30 = (1UL << 30) - 1;
            const ulong Mask31 = (1UL << 31) - 1;
            const ulong Mod = (1UL << 61) - 1;
            const ulong Positivizer = Mod * ((1UL << 3) - 1);   // 引き算する前に足すことでmodが負になることを防ぐやつ
            static readonly uint base1;
            static readonly uint base2;
            static readonly List<ulong> pow1;
            static readonly List<ulong> pow2;

            static RollingHash()
            {
                var random = new Random();
                base1 = (uint)random.Next(129, int.MaxValue >> 2);
                base2 = (uint)random.Next(int.MaxValue >> 2, int.MaxValue); // 32bit目は0にしておく
                pow1 = new List<ulong>() { 1 };
                pow2 = new List<ulong>() { 1 };
            }

            ulong[] hash1;
            ulong[] hash2;
            public string RowString { get; }
            public int Length => RowString.Length;

            public RollingHash(string s)
            {
                RowString = s;
                hash1 = new ulong[s.Length + 1];
                hash2 = new ulong[s.Length + 1];

                for (int i = pow1.Count; i < s.Length + 1; i++)
                {
                    pow1.Add(CalculateModular(Multiply(pow1[i - 1], base1)));
                    pow2.Add(CalculateModular(Multiply(pow2[i - 1], base2)));
                }

                for (int i = 0; i < s.Length; i++)
                {
                    hash1[i + 1] = CalculateModular(Multiply(hash1[i], base1) + s[i]);
                    hash2[i + 1] = CalculateModular(Multiply(hash2[i], base2) + s[i]);
                }
            }

            public (ulong, ulong) this[Range range]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    var (offset, length) = range.GetOffsetAndLength(Length);
                    return Slice(offset, length);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (ulong, ulong) Slice(int begin, int length)
            {
                var result1 = CalculateModular(hash1[begin + length] + Positivizer - Multiply(hash1[begin], pow1[length]));
                var result2 = CalculateModular(hash2[begin + length] + Positivizer - Multiply(hash2[begin], pow2[length]));
                return (result1, result2);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ulong Multiply(ulong l, ulong r)
            {
                var lu = l >> 31;
                var ll = l & Mask31;
                var ru = r >> 31;
                var rl = r & Mask31;
                var mid = ll * ru + lu * rl;
                return ((lu * ru) << 1) + ll * rl + ((mid & Mask30) << 31) + (mid >> 30);   // a * 2^61 ≡ a (mod 2^61 - 1)を使う
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ulong Multiply(ulong l, uint r)
            {
                var lu = l >> 31;
                var mid = lu * r;
                return (l & Mask31) * r + ((mid & Mask30) << 31) + (mid >> 30); // rの32bit目は0としている
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ulong CalculateModular(ulong value)
            {
                value = (value & Mod) + (value >> 61);
                if (value >= Mod)
                {
                    value -= Mod;
                }
                return value;
            }

            public override string ToString() => RowString;
        }
    }
}
