using AtCoderBeginnerContest123.Questions;
using AtCoderBeginnerContest123.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest123.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var dishes = new int[5];
            for (int i = 0; i < 5; i++)
            {
                dishes[i] = inputStream.ReadInt();
            }

            yield return Enumerable.Range(0, 5)
                .Min(except => dishes
                    .Take(except)
                    .Concat(dishes.Skip(except + 1))
                    .Sum(d => (int)Math.Ceiling((decimal)d / 10) * 10) + dishes[except]);
        }
    }
}
