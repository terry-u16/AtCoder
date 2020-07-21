using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu037.Algorithms;
using Kujikatsu037.Collections;
using Kujikatsu037.Extensions;
using Kujikatsu037.Numerics;
using Kujikatsu037.Questions;

namespace Kujikatsu037.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc097/tasks/arc097_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var k = inputStream.ReadInt();

            var (_, result) = Dfs(s, k, "", 0);
            yield return result;
        }

        (int count, string result) Dfs(string s, int k, string searching, int total)
        {
            var found = false;
            int count = 0;
            if (searching == string.Empty)
            {
                found = true;
                count--;
            }
            else
            {
                for (int i = 0; i <= s.Length - searching.Length; i++)
                {
                    var span = s.AsSpan(i, searching.Length);
                    var ok = true;
                    for (int j = 0; j < searching.Length; j++)
                    {
                        ok &= span[j] == searching[j];
                    }
                    if (ok)
                    {
                        found = true;
                        break;
                    }
                }
            }

            if (found)
            {
                count++;
                if (total + count >= k)
                {
                    return (count, searching);
                }

                for (char c = 'a'; c <= 'z'; c++)
                {
                    var (cnt, res) = Dfs(s, k, searching + c, total + count);
                    count += cnt;

                    if (res != null)
                    {
                        return (count, res);
                    }
                }
            }

            return (count, null);
        }
    }
}
