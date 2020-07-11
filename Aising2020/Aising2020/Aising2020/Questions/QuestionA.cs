using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aising2020.Algorithms;
using Aising2020.Collections;
using Aising2020.Extensions;
using Aising2020.Numerics;
using Aising2020.Questions;

namespace Aising2020.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (l, r, d) = inputStream.ReadValue<int, int, int>();
            var count = 0;
            for (int i = l; i <= r; i++)
            {
                if (i % d == 0)
                {
                    count++;
                }
            }

            yield return count;
        }
    }
}
