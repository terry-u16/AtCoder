using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200713.Algorithms;
using Training20200713.Collections;
using Training20200713.Extensions;
using Training20200713.Numerics;
using Training20200713.Questions;

namespace Training20200713.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc073/tasks/abc073_c
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var set = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                var a = inputStream.ReadInt();
                if (!set.Add(a))
                {
                    set.Remove(a);
                }
            }
            yield return set.Count;
        }
    }
}
