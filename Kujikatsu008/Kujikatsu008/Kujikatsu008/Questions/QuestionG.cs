using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu008.Algorithms;
using Kujikatsu008.Collections;
using Kujikatsu008.Extensions;
using Kujikatsu008.Numerics;
using Kujikatsu008.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu008.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc150/tasks/abc150_f
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var b = inputStream.ReadIntArray();

            //return SolveByZAlgorithm(a, b);
            return SolveByMP(a, b);
        }

        private static (int[], int[]) GetDiffs(int[] a, int[] b)
        {
            var diffA = new int[a.Length];
            var diffB = new int[b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                diffA[i] = a[i] ^ a[(i + 1) % a.Length];
                diffB[i] = b[i] ^ b[(i + 1) % b.Length];
            }
            return (diffA, diffB);
        }

        IEnumerable<string> SolveByZAlgorithm(int[] a, int[] b)
        {
            var (diffA, diffB) = GetDiffs(a, b);

            var concat = diffB.Concat(diffA).Concat(diffA).ToArray();
            var length = StringAlgorithms.ZAlgorithm<int>(concat.AsSpan()).AsSpan()[a.Length..(a.Length * 2)];

            var answers = new Queue<string>();

            for (int i = 0; i < length.Length; i++)
            {
                if (length[i] >= a.Length)
                {
                    answers.Enqueue($"{i} {a[i] ^ b[0]}");
                }
            }

            return answers;
        }

        IEnumerable<string> SolveByMP(int[] a, int[] b)
        {
            var (diffA, diffB) = GetDiffs(a, b);

            var mp = new MorrisPratt<int>(diffA);
            var matches = mp.FindAllMatchingIndexIn(diffB.Concat(diffB.Take(diffB.Length - 1)).ToArray());

            foreach (var match in matches.Select(i => (a.Length - i) % a.Length).OrderBy(i => i))
            {
                yield return $"{match} {a[match] ^ b[0]}";
            }
        }

        /// <summary>
        /// MP法（文字列検索アルゴリズム）
        /// </summary>
        public class MorrisPratt<T> where T : IEquatable<T>
        {
            readonly T[] _searchSequence;
            readonly int[] _matchLength;

            public ReadOnlySpan<T> SearchSequence => _searchSequence.AsSpan();

            /// <summary>
            /// 検索データ列の前処理を行います。
            /// </summary>
            /// <param name="searchSequence">検索データ列</param>
            public MorrisPratt(ReadOnlySpan<T> searchSequence)
            {
                _searchSequence = searchSequence.ToArray();
                _matchLength = new int[_searchSequence.Length + 1];
                _matchLength[0] = -1;
                int j = -1;
                for (int i = 0; i < _searchSequence.Length; i++)
                {
                    while (j != -1 && !_searchSequence[j].Equals(_searchSequence[i]))
                    {
                        j = _matchLength[j];
                    }
                    j++;
                    _matchLength[i + 1] = j;
                }
            }

            /// <summary>
            /// 与えられた対象データ列の部分列のうち、検索データ列にマッチする部分列の開始インデックスを取得します。
            /// </summary>
            /// <param name="targetSequence">検索対象データ列</param>
            /// <returns></returns>
            public List<int> FindAllMatchingIndexIn(ReadOnlySpan<T> targetSequence)
            {
                var results = new List<int>();
                int j = 0;
                for (int i = 0; i < targetSequence.Length; i++)
                {
                    while (j != -1 && !_searchSequence[j].Equals(targetSequence[i]))
                    {
                        j = _matchLength[j];
                    }
                    j++;
                    if (j == _searchSequence.Length)
                    {
                        results.Add(i - j + 1);
                        j = _matchLength[j];
                    }
                }
                return results;
            }
        }
    }
}
