using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu102.Algorithms;
using Kujikatsu102.Collections;
using Kujikatsu102.Numerics;
using Kujikatsu102.Questions;

namespace Kujikatsu102.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc158/tasks/abc158_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var deque = new Deque<char>(io.ReadString());
            var queries = io.ReadInt();
            var reversed = false;

            for (int i = 0; i < queries; i++)
            {
                var type = io.ReadInt();

                if (type == 1)
                {
                    reversed ^= true;
                }
                else
                {
                    var first = io.ReadInt() == 1;
                    var c = io.ReadString()[0];

                    if (first ^ reversed)
                    {
                        deque.EnqueueFirst(c);
                    }
                    else
                    {
                        deque.EnqueueLast(c);
                    }
                }
            }

            var toAdd = reversed ? deque.Reverse() : deque;

            io.WriteLine(string.Concat(toAdd));
        }
    }
}
