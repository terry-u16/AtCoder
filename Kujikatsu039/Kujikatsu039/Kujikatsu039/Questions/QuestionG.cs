using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu039.Algorithms;
using Kujikatsu039.Collections;
using Kujikatsu039.Extensions;
using Kujikatsu039.Numerics;
using Kujikatsu039.Questions;
using System.Collections.Immutable;

namespace Kujikatsu039.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc081/tasks/arc081_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var candidates = new Queue<StringAndCursor>();

            for (var c = 'a'; c <= 'z'; c++)
            {
                candidates.Enqueue(new StringAndCursor(ImmutableList.Create(c), -1));
            }

            while (true)
            {
                var (candidate, lastCursor) = candidates.Dequeue();
                var cursor = GetLastCursor(s, candidate[^1], lastCursor);

                if (cursor < s.Length)
                {
                    for (var c = 'a'; c <= 'z'; c++)
                    {
                        candidates.Enqueue(new StringAndCursor(candidate.Add(c), cursor));
                    }
                }
                else
                {
                    yield return candidate.Join();
                    yield break;
                }
            }
        }

        int GetLastCursor(string s, char candidateLast, int lastCursor)
        {
            for (int cursor = lastCursor + 1; cursor < s.Length; cursor++)
            {
                if (s[cursor] == candidateLast)
                {
                    return cursor;
                }
            }
            return s.Length;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct StringAndCursor
        {
            public ImmutableList<char> String { get; }
            public int Cursor { get; }

            public StringAndCursor(ImmutableList<char> s, int cursor)
            {
                String = s;
                Cursor = cursor;
            }

            public void Deconstruct(out ImmutableList<char> s, out int cursor) => (s, cursor) = (String, Cursor);
            public override string ToString() => $"{nameof(String)}: {String}, {nameof(Cursor)}: {Cursor}";
        }
    }
}
