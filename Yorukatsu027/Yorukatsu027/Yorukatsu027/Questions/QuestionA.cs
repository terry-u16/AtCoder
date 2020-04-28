using Yorukatsu027.Questions;
using Yorukatsu027.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu027.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        /// <summary>
        /// ABC093 A
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            yield return s.Contains('a') && s.Contains('b') && s.Contains('c') ? "Yes" : "No";
        }
    }
}
