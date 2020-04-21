using AtCoderBeginnerContest146.Questions;
using AtCoderBeginnerContest146.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest146.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];
            var s = inputStream.ReadLine();

            var me = new Stack<int>();
            var current = n;

            while (current > 0)
            {
                for (int i = Math.Min(m, current); i >= 0; i--)
                {
                    if (i == 0)
                    {
                        yield return -1;
                        yield break;
                    }

                    if (s[current - i] == '0')
                    {
                        current -= i;
                        me.Push(i);
                        break;
                    }
                }
            }

            yield return string.Join(" ", me);
        }
    }
}
