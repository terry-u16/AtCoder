using Kujikatsu003.Questions;
using Kujikatsu003.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu003.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc062/tasks/abc062_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var xy = inputStream.ReadIntArray();
            yield return GetGroup(xy[0]) == GetGroup(xy[1]) ? "Yes" : "No";
        }

        int GetGroup(int n)
        {
            switch (n)
            {
                case 2:
                    return 2;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 1;
                default:
                    return 0;
            }
        }
    }
}
