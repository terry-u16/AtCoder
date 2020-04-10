using AtCoderBeginnerContest158.Questions;
using AtCoderBeginnerContest158.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest158.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var q = inputStream.ReadInt();
            var builder = new LinkedList<char>(s);

            bool reversed = false;

            for (int i = 0; i < q; i++)
            {
                var query = inputStream.ReadStringArray();
                var t = query[0][0];

                if (t == '1')
                {
                    reversed = !reversed;
                }
                else
                {
                    var f = query[1][0];
                    var head = (f == '1') ^ reversed;
                    var c = query[2][0];

                    if (head)
                    {
                        builder.AddFirst(c);
                    }
                    else
                    {
                        builder.AddLast(c);
                    }
                }
            }

            var result = !reversed ? builder : builder.Reverse();

            yield return string.Join("", result);
        }
    }
}
