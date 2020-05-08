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
    /// ABC043 B
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var inputs = inputStream.ReadLine();
            var buffer = new List<char>();

            foreach (var input in inputs)
            {
                switch (input)
                {
                    case '0':
                        buffer.Add('0');
                        break;
                    case '1':
                        buffer.Add('1');
                        break;
                    case 'B':
                        if (buffer.Count > 0)
                        {
                            buffer.RemoveAt(buffer.Count - 1);
                        }
                        break;
                    default:
                        break;
                }
            }

            yield return string.Concat(buffer);
        }
    }
}
