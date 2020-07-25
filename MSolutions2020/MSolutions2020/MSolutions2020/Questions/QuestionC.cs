using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MSolutions2020.Algorithms;
using MSolutions2020.Collections;
using MSolutions2020.Extensions;
using MSolutions2020.Numerics;
using MSolutions2020.Questions;

namespace MSolutions2020.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();
            for (int i = k; i < a.Length; i++)
            {
                yield return a[i - k] < a[i] ? "Yes" : "No";
            }
        }
    }
}
