using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PAST003.Algorithms;
using PAST003.Collections;
using PAST003.Extensions;
using PAST003.Numerics;
using PAST003.Questions;

namespace PAST003.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var charSet = Enumerable.Range(0, n).Select(_ => new HashSet<char>()).ToArray();


            for (int row = 0; row < n; row++)
            {
                foreach (var c in inputStream.ReadLine())
                {
                    charSet[row].Add(c);
                }
            }

            var palindrome = new char[n];
            for (int row = 0; (row << 1) < n; row++)
            {
                var contained = charSet[row].Intersect(charSet[^(row + 1)]).FirstOrDefault();
                if (contained == default)
                {
                    yield return -1;
                    yield break;
                }

                palindrome[row] = contained;
                palindrome[^(row + 1)] = contained;
            }

            yield return string.Concat(palindrome);
        }
    }
}
