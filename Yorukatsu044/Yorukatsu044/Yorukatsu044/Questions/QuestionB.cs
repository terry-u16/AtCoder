using Yorukatsu044.Questions;
using Yorukatsu044.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu044.Questions
{
    /// <summary>
    /// ABC079 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abcd = inputStream.ReadString().Select(c => int.Parse(c.ToString())).ToArray();

            for (int flag = 0; flag < 1 << 3; flag++)
            {
                var statement = abcd[0].ToString();
                var sum = abcd[0];
                for (int i = 0; i < 3; i++)
                {
                    var plus = (flag & (1 << i)) > 0;
                    if (plus)
                    {
                        sum += abcd[i + 1];
                        statement += "+";
                    }
                    else
                    {
                        sum -= abcd[i + 1];
                        statement += "-";
                    }
                    statement += abcd[i + 1];
                }

                if (sum == 7)
                {
                    statement += "=7";
                    yield return statement;
                    yield break;
                }
            }
        }
    }
}
