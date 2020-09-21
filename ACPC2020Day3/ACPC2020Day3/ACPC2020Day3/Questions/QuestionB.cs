using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ACPC2020Day3.Extensions;
using ACPC2020Day3.Questions;

namespace ACPC2020Day3.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nq = inputStream.ReadIntArray();
            var n = nq[0];
            var q = nq[1];

            var a = inputStream.ReadLongArray();
            var prefixSub = new long[a.Length + 1];

            for (int i = 0; i < a.Length; i++)
            {
                prefixSub[i + 1] = prefixSub[i] - a[i];
            }

            for (int qi = 0; qi < q; qi++)
            {
                var lr = inputStream.ReadIntArray();
                var l = lr[0] - 1;
                var r = lr[1];

                yield return prefixSub[r] - prefixSub[l + 1] + a[l];
            }
        }
    }
}
