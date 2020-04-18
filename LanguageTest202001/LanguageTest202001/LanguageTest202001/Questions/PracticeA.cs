using LanguageTest202001.Algorithms;
using LanguageTest202001.Collections;
using LanguageTest202001.Questions;
using LanguageTest202001.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LanguageTest202001.Questions
{
    public class PracticeA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var a = inputStream.ReadInt();
            var (b, c) = inputStream.ReadValue<int, int>();
            var s = inputStream.ReadLine();
            var d = new int[] { 1, 2, 3, 4, 5 };
            foreach (var element in d.AsSpan()[1..^1])
            {

            }
            yield return $"{a + b + c} {s}";
        }
    }
}
