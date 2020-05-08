using Yorukatsu035.Questions;
using Yorukatsu035.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu035.Questions
{
    /// <summary>
    /// ABC122 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var b = inputStream.ReadLine()[0];

            switch (b)
            {
                case 'A':
                    yield return 'T';
                    yield break;
                case 'T':
                    yield return 'A';
                    yield break;
                case 'C':
                    yield return 'G';
                    yield break;
                case 'G':
                    yield return 'C';
                    yield break;
                default:
                    break;
            }
        }
    }
}
