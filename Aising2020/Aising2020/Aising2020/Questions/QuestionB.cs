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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                var number = i + 1;
                if (number % 2 == 1 && a[i] % 2 == 1)
                {
                    count++;
                }
            }
            yield return count;
        }
    }
}
