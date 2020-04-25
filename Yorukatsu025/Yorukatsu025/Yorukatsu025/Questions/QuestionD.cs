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
    /// ABC064 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            var builder = new StringBuilder(s);

            while (true)
            {
                var leftBracketCount = 0;
                for (int index = 0; index < builder.Length; index++)
                {
                    if (builder[index] == '(')
                    {
                        leftBracketCount++;

                        if (index == builder.Length - 1)
                        {
                            builder.Append(')');
                        }
                    }
                    else
                    {
                        leftBracketCount--;
                        if (leftBracketCount == 0)
                        {
                            if (index == builder.Length - 1)
                            {
                                yield return builder.ToString();
                                yield break;
                            }
                        }
                        else if (leftBracketCount > 0)
                        {
                            if (index == builder.Length - 1)
                            {
                                builder.Append(')');
                            }
                        }
                        else
                        {
                            builder.Insert(0, '(');
                            break;
                        }
                    }
                }
            }
        }
    }
}
