using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest177.Algorithms;
using AtCoderBeginnerContest177.Collections;
using AtCoderBeginnerContest177.Extensions;
using AtCoderBeginnerContest177.Numerics;
using AtCoderBeginnerContest177.Questions;

namespace AtCoderBeginnerContest177.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (people, relations) = inputStream.ReadValue<int, int>();
            var unionFind = new UnionFindTree(people);

            for (int i = 0; i < relations; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                unionFind.Unite(a, b);
            }

            var max = 0;

            for (int i = 0; i < unionFind.Count; i++)
            {
                max = Math.Max(max, unionFind.GetGroupSizeOf(i));
            }

            yield return max;
        }
    }
}
