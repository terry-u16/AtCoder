using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WUPC2020.Extensions;
using WUPC2020.Questions;

namespace WUPC2020.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var b = new int[n];

            var index = 0;

            if (a.Length % 2 == 1)
            {
                var prod = a[0] * a[1] * a[2];
                b[0] = prod / a[0];
                b[1] = prod / a[1];
                b[2] = prod / a[2] * -2;
                index = 3;
            }

            for (int i = index; i + 1 < a.Length; i += 2)
            {
                var prod = a[i] * a[i + 1];
                b[i] = prod / a[i];
                b[i + 1] = -prod / a[i + 1];
            }

            yield return b.Join(" ");
        }
    }
}
