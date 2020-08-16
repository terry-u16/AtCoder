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
    /// https://atcoder.jp/contests/arc033/tasks/arc033_3
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var bit = new BinaryIndexedTree(2000001);
            var queries = inputStream.ReadInt();
            for (int q = 0; q < queries; q++)
            {
                var (type, x) = inputStream.ReadValue<int, int>();
                if (type == 1)
                {
                    bit[x]++;
                }
                else
                {
                    var index = bit.GetLowerBound(x);
                    bit[index]--;
                    yield return index;
                }
            }
        }
    }
}
