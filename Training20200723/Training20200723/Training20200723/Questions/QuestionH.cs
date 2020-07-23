using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200723.Algorithms;
using Training20200723.Collections;
using Training20200723.Extensions;
using Training20200723.Numerics;
using Training20200723.Questions;

namespace Training20200723.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2014-qualb/tasks/code_festival_qualB_d
    /// </summary>
    public class QuestionH : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var height = new int[n + 2];
            height[0] = int.MaxValue;
            height[n + 1] = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                height[i + 1] = inputStream.ReadInt();
            }

            var count = new int[n + 2];
            var leftStack = new Stack<IndexAndHeight>();
            var rightStack = new Stack<IndexAndHeight>();

            for (int i = 0; i < height.Length; i++)
            {
                while (leftStack.Count > 0 && leftStack.Peek().Height < height[i])
                {
                    var last = leftStack.Pop();
                    count[last.Index] += i - last.Index - 1;
                }

                leftStack.Push(new IndexAndHeight(i, height[i]));
            }

            for (int i = height.Length - 1; i >= 0; i--)
            {
                while (rightStack.Count > 0 && rightStack.Peek().Height < height[i])
                {
                    var last = rightStack.Pop();
                    count[last.Index] += last.Index - i - 1;
                }

                rightStack.Push(new IndexAndHeight(i, height[i]));
            }

            for (int i = 1; i <= n; i++)
            {
                yield return count[i];
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct IndexAndHeight
        {
            public int Index { get; }
            public int Height { get; }

            public IndexAndHeight(int index, int height)
            {
                Index = index;
                Height = height;
            }

            public void Deconstruct(out int index, out int height) => (index, height) = (Index, Height);
            public override string ToString() => $"{nameof(Index)}: {Index}, {nameof(Height)}: {Height}";
        }
    }
}
