using Yorukatsu038.Questions;
using Yorukatsu038.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu038.Questions
{
    /// <summary>
    /// ABC102 D
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var l = inputStream.ReadInt();

            const int maxNodes = 20;
            const int maxEdges = maxNodes - 1;
            var pow = GetMaximumPow2(l);
            var pow2 = 1 << pow;
            var path0 = maxEdges;
            var path1 = pow - 1;

            var path2s = new Stack<(int node, int length)>();
            for (int i = maxEdges; i >= 0; i--)
            {
                var p = 1 << i;
                if (l - p >= pow2)
                {
                    path2s.Push((node: i, length: l - p));
                    l -= p;
                }
            }

            yield return $"{maxNodes} {path0 + path1 + 1 + path2s.Count}";
            for (int i = 0; i < path0; i++)
            {
                yield return $"{i + 1} {i + 2} 0";
            }
            for (int i = 0; i <= path1; i++)
            {
                yield return $"{i + 1} {i + 2} {1 << i}";
            }
            foreach (var (node, length) in path2s)
            {
                yield return $"{node + 1} {maxNodes} {length}";
            }
        }

        int GetMaximumPow2(int n)
        {
            long accum = 1;
            int i;
            for (i = 0; accum * 2 <= n; i++)
            {
                accum *= 2;
            }
            return i;
        }
    }
}
