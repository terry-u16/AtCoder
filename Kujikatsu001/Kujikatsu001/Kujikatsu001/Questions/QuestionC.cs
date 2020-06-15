using Kujikatsu001.Questions;
using Kujikatsu001.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu001.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc137/tasks/abc137_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var dictionary = new Dictionary<string, long>();

            for (int i = 0; i < n; i++)
            {
                var s = inputStream.ReadLine().ToCharArray();
                Array.Sort(s);
                var ss = new string(s);

                if (dictionary.ContainsKey(ss))
                {
                    dictionary[ss]++;
                }
                else
                {
                    dictionary[ss] = 1;
                }
            }

            long count = 0;
            foreach (var pair in dictionary)
            {
                count += pair.Value * (pair.Value - 1) / 2;
            }

            yield return count;
        }
    }
}
