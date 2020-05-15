using AtCoderBeginnerContest116.Questions;
using AtCoderBeginnerContest116.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest116.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var a = inputStream.ReadInt();
            var hashSet = new HashSet<int>();

            for (int m = 1; true; m++)
            {
                if (!hashSet.Add(a))
                {
                    yield return m;
                    yield break;
                }
                a = F(a);
            }
        }

        int F(int n)
        {
            if (n % 2 == 0)
            {
                return n / 2;
            }
            else
            {
                return 3 * n + 1;
            }
        }
    }
}
