using Yorukatsu027.Questions;
using Yorukatsu027.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace Yorukatsu027.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        /// <summary>
        /// ABC098 C
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            var east = new int[s.Length + 2];
            var west = new int[s.Length + 2];

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'W')
                {
                    west[i + 1] = west[i] + 1;
                }
                else
                {
                    west[i + 1] = west[i];
                }
            }

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == 'E')
                {
                    east[i + 1] = east[i + 2] + 1;
                }
                else
                {
                    east[i + 1] = east[i + 2];
                }
            }

            var min = int.MaxValue;
            for (int i = 1; i <= s.Length; i++)
            {
                min = Math.Min(min, west[i - 1] + east[i + 1]);
            }

            yield return min;
        }
    }
}
