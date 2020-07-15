using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu031.Algorithms;
using Kujikatsu031.Collections;
using Kujikatsu031.Extensions;
using Kujikatsu031.Numerics;
using Kujikatsu031.Questions;

namespace Kujikatsu031.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc122/tasks/abc122_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var b = inputStream.ReadLine()[0];

            var answer = b switch
            {
                'A' => 'T',
                'T' => 'A',
                'G' => 'C',
                'C' => 'G',
                _ => '_'
            };
            yield return answer;
        }
    }
}
