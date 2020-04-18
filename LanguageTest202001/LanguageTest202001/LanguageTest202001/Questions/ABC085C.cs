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
    public class ABC085C : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, y) = inputStream.ReadValue<int, int>();

            for (int bill10000 = 0; bill10000 <= n; bill10000++)
            {
                for (int bill5000 = 0; bill10000 + bill5000 <= n; bill5000++)
                {
                    var bill1000 = n - (bill10000 + bill5000);
                    if (bill10000 * 10000 + bill5000 * 5000 + bill1000 * 1000 == y)
                    {
                        yield return $"{bill10000} {bill5000} {bill1000}";
                        yield break;
                    }
                }
            }

            yield return "-1 -1 -1";
        }
    }
}
