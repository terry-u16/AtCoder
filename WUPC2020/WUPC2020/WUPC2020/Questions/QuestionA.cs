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
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();
            var a = ab[0];
            var b = ab[1];

            if (a == 1)
            {
                a++;
            }

            if ((b - a + 1) % 2 == 0)
            {
                yield return "EVEN";
            }
            else
            {
                yield return "ODD";
            }
        }
    }
}
