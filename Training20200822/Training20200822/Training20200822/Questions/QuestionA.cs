using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200822.Algorithms;
using Training20200822.Collections;
using Training20200822.Extensions;
using Training20200822.Numerics;
using Training20200822.Questions;

namespace Training20200822.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc059/tasks/abc059_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (s, t, u) = inputStream.ReadValue<string, string, string>();
            yield return (s.Substring(0, 1) + t.Substring(0, 1) + u.Substring(0, 1)).ToUpper();
        }
    }
}
