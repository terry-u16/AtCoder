using Yorukatsu025.Questions;
using Yorukatsu025.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu025.Questions
{
    /// <summary>
    /// ABC056 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadInt();

            var position = 0;
            for (int time = 1; true; time++)
            {
                position += time;
                if (position >= x)
                {
                    yield return time;
                    yield break;
                }
            }
        }
    }
}
