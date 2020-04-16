using AtCoderBeginnerContest150.Questions;
using AtCoderBeginnerContest150.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest150.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            var subString = new Queue<char>(s.Take(2));

            int count = 0;
            foreach (var c in s.Skip(2))
            {
                subString.Enqueue(c);
                if (subString.SequenceEqual("ABC"))
                {
                    count++;
                }
                subString.Dequeue();
            }

            yield return count;
        }
    }
}
