using AtCoderBeginnerContest119.Questions;
using AtCoderBeginnerContest119.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest119.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            decimal otoshidama = 0m;

            for (int i = 0; i < n; i++)
            {
                var xu = inputStream.ReadStringArray();
                var x = decimal.Parse(xu[0]);
                if (xu[1] == "JPY")
                {
                    otoshidama += x;
                }
                else
                {
                    otoshidama += x * 380000.0m;
                }
            }

            yield return otoshidama;
        }
    }
}
