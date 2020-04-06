using AtCoderTypicalContest001.Questions;
using AtCoderTypicalContest001.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderTypicalContest001.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        int[] _parents = null;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nq = inputStream.ReadIntArray();
            var n = nq[0];
            var q = nq[1];
            _parents = InitializeParents(n);

            for (int i = 0; i < q; i++)
            {
                var pab = inputStream.ReadIntArray();
                var p = pab[0];
                var a = pab[1];
                var b = pab[2];

                if (p == 0)
                {
                    Unite(a, b);
                }
                else
                {
                    yield return IsInSameGroup(a, b) ? "Yes" : "No";
                }
            }
        }

        int[] InitializeParents(int n)
        {
            var r = new int[n];
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = i;
            }
            return r;
        }

        void Unite(int x, int y)
        {
            var rootX = FindRoot(x);
            var rootY = FindRoot(y);

            if (rootX != rootY)
            {
                _parents[x] = rootY;
            }
        }

        int FindRoot(int x)
        {
            if (_parents[x] == x)
            {
                return x;
            }
            else
            {
                _parents[x] = FindRoot(_parents[x]);
                return _parents[x];
            }
        }

        bool IsInSameGroup(int x, int y) => FindRoot(x) == FindRoot(y);
    }
}
