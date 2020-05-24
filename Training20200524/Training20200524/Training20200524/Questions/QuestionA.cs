using Training20200524.Questions;
using Training20200524.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200524.Questions
{
    /// <summary>
    /// http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_7_B&lang=ja
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            while (true)
            {
                var nx = inputStream.ReadIntArray();
                var n = nx[0];
                var x = nx[1];
                if (n == 0 && x == 0)
                {
                    break;
                }

                var count = 0;
                for (int i = 1; i <= n; i++)
                {
                    for (int j = i + 1; j <= n; j++)
                    {
                        for (int k = j + 1; k <= n; k++)
                        {
                            if (i + j + k == x)
                            {
                                count++;
                            }
                        }
                    }
                }

                yield return count;
            }
        }
    }
}
