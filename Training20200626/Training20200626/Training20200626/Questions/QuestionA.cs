using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200626.Algorithms;
using Training20200626.Collections;
using Training20200626.Extensions;
using Training20200626.Numerics;
using Training20200626.Questions;

namespace Training20200626.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc115/tasks/abc115_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var d = inputStream.ReadInt();
            var result = d switch
            {
                22 => "Christmas Eve Eve Eve",
                23 => "Christmas Eve Eve",
                24 => "Christmas Eve",
                25 => "Christmas",
                _ => "",
            };
            yield return result;
        }
    }
}
