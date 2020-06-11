using Training20200611.Questions;
using Training20200611.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200611.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc005/tasks/agc005_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadLine();
            var stack = new Stack<char>();

            foreach (var xi in x)
            {
                if (stack.Count > 0 && stack.Peek() == 'S' && xi == 'T')
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(xi);
                }
            }

            yield return stack.Count;
        }
    }
}
