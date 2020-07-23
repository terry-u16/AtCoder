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
    /// https://atcoder.jp/contests/donuts-2015/tasks/donuts_2015_3
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var heights = inputStream.ReadIntArray();
            var visibles = new Stack<int>();

            foreach (var height in heights)
            {
                yield return visibles.Count;
                while (visibles.Count > 0 && visibles.Peek() < height)
                {
                    visibles.Pop();
                }

                visibles.Push(height);
            }
        }
    }
}
