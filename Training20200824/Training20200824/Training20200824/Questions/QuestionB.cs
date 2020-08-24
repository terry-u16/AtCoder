using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200824.Algorithms;
using Training20200824.Collections;
using Training20200824.Extensions;
using Training20200824.Numerics;
using Training20200824.Questions;

namespace Training20200824.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/joi2020yo2/tasks/joi2020_yo2_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var results = new bool?[n + 1];
            var count = 0;

            for (int i = 1; i <= n; i++)
            {
                if (Dfs(i))
                {
                    count++;
                }
            }

            yield return count;

            bool Dfs(int m)
            {
                if (m > n)
                {
                    return false;
                }
                else if (m == n)
                {
                    return true;
                }
                else if (results[m] != null)
                {
                    return results[m].Value;
                }
                else
                {
                    var added = m + DigitSum(m);
                    results[m] = Dfs(added);
                    return results[m].Value;
                }
            }
        }

        int DigitSum(int n)
        {
            var result = 0;
            while (n > 0)
            {
                result += n % 10;
                n /= 10;
            }
            return result;
        }
    }
}
