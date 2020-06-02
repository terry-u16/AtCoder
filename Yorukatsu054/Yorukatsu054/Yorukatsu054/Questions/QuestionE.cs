using Yorukatsu054.Questions;
using Yorukatsu054.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu054.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc086/tasks/arc086_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();

            var count = 0;
            var ops = new Queue<Operation>(2 * n);

            while (!Completed(a))
            {
                count++;
                ops.Enqueue(Add(a));
            }

            yield return count;
            foreach (var op in ops)
            {
                yield return op;
            }
        }

        bool Completed(long[] a)
        {
            for (int i = 0; i + 1 < a.Length; i++)
            {
                if (a[i] > a[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        int SearchMaxAbsIndex(long[] a)
        {
            long maxAbs = -1;
            int maxAbsIndex = -1;
            for (int i = 0; i < a.Length; i++)
            {
                if (Math.Abs(a[i]) > maxAbs)
                {
                    maxAbs = Math.Abs(a[i]);
                    maxAbsIndex = i;
                }
            }

            return maxAbsIndex;
        }

        Operation Add(long[] a)
        {
            var fromIndex = SearchMaxAbsIndex(a);
            long added = a[fromIndex];

            if (added > 0)
            {
                for (int toIndex = 1; toIndex < a.Length; toIndex++)
                {
                    if (a[toIndex - 1] > a[toIndex])
                    {
                        a[toIndex] += added;
                        return new Operation(fromIndex + 1, toIndex + 1);
                    }
                }
            }
            else
            {
                for (int toIndex = a.Length - 2; toIndex >= 0; toIndex--)
                {
                    if (a[toIndex] > a[toIndex + 1])
                    {
                        a[toIndex] += added;
                        return new Operation(fromIndex + 1, toIndex + 1);
                    }
                }
            }

            throw new Exception();
        }

        struct Operation
        {
            public int From { get; }
            public int To { get; }

            public Operation(int from, int to)
            {
                From = from;
                To = to;
            }

            public override string ToString() => $"{From} {To}";
        }
    }
}
