using Yorukatsu051.Questions;
using Yorukatsu051.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu051.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc141/tasks/abc141_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            switch (s)
            {
                case "Sunny":
                    yield return "Cloudy";
                    yield break;
                case "Cloudy":
                    yield return "Rainy";
                    yield break;
                case "Rainy":
                    yield return "Sunny";
                    yield break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
