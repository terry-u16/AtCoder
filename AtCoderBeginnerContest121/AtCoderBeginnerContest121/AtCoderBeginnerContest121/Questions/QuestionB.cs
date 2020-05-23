using AtCoderBeginnerContest121.Questions;
using AtCoderBeginnerContest121.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest121.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nmc = inputStream.ReadIntArray();
            var n = nmc[0];
            var m = nmc[1];
            var c = nmc[2];
            
            var b = inputStream.ReadIntArray();

            var count = 0;
            for (int i = 0; i < n; i++)
            {
                var a = inputStream.ReadIntArray();
                var sum = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    sum += a[j] * b[j];
                }
                sum += c;
                if (sum > 0)
                {
                    count++;
                }
            }

            yield return count;
        }
    }
}
