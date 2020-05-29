using Yorukatsu052.Questions;
using Yorukatsu052.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu052.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc158/tasks/abc158_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = new LinkedList<char>(inputStream.ReadLine());
            var reversed = false;
            var queries = inputStream.ReadInt();

            for (int q = 0; q < queries; q++)
            {
                var query = inputStream.ReadLine().Split(' ');
                if (query[0] == "1")
                {
                    reversed = !reversed;
                }
                else
                {
                    var front = int.Parse(query[1]) == 1 ? true : false;
                    var c = query[2][0];

                    if (reversed ^ front)
                    {
                        s.AddFirst(c);
                    }
                    else
                    {
                        s.AddLast(c);
                    }
                }
            }

            if (reversed)
            {
                yield return string.Concat(s.Reverse());
            }
            else
            {
                yield return string.Concat(s);
            }
        }
    }
}
