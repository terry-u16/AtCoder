using Yorukatsu023.Questions;
using Yorukatsu023.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu023.Questions
{
    /// <summary>
    /// ABC112 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLine();
            switch (n)
            {
                case "1":
                    yield return "Hello World";
                    yield break;
                case "2":
                    var a = inputStream.ReadInt();
                    var b = inputStream.ReadInt();
                    yield return a + b;
                    yield break;
                default:
                    break;
            }
        }
    }
}
