using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200906.Algorithms;
using Training20200906.Collections;
using Training20200906.Extensions;
using Training20200906.Numerics;
using Training20200906.Questions;

namespace Training20200906.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc047/tasks/abc047_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadIntArray();

            Array.Sort(abc);

            if (abc[0] + abc[1] == abc[2])
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }
    }
}
