using Yorukatsu023.Questions;
using Yorukatsu023.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace Yorukatsu023.Questions
{
    /// <summary>
    /// ABC097 B
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadInt();

            int max = 1;
            for (int b = 2; b <= 1000; b++)
            {
                for (int p = 2; p < int.MaxValue; p++)
                {
                    var pow = Pow(b, p);
                    if (pow > x)
                    {
                        break;
                    }

                    max = Math.Max(max, pow);
                }
            }
            yield return max;
        }

        int Pow(int b, int p)
        {
            var result = 1;
            for (int i = 0; i < p; i++)
            {
                result *= b;
            }
            return result;
        }
    }
}
