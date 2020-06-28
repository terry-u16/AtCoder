using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200628.Algorithms;
using Training20200628.Collections;
using Training20200628.Extensions;
using Training20200628.Numerics;
using Training20200628.Questions;

namespace Training20200628.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc021/tasks/abc021_d
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.InitializeCombinationTable();
            var n = inputStream.ReadInt();
            var k = inputStream.ReadInt();

            yield return Modular.CombinationWithRepetition(n, k).Value;
        }
    }
}
