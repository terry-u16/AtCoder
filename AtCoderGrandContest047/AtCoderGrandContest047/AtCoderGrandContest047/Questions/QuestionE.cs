using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderGrandContest047.Algorithms;
using AtCoderGrandContest047.Collections;
using AtCoderGrandContest047.Extensions;
using AtCoderGrandContest047.Numerics;
using AtCoderGrandContest047.Questions;

namespace AtCoderGrandContest047.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var operations = new Queue<string>();

            operations.Enqueue("+ 0 1 3");  // A+B

            for (int i = 1; i <= 10; i++)
            {
                operations.Enqueue($"< 2 3 {i + 10}"); // 1を生成
            }

            for (int i = 0; i <= 10; i++)
            {
                operations.Enqueue($"+ {i + 10} {i + 11} {i + 11}");
            }

            for (int mul = 0; mul <= 10; mul++)
            {
                for (int add = 0; add <= 10; add++)
                {
                    operations.Enqueue($"< {add + 10} 0 {add + 30}");
                }

                for (int i = 0; i <= 10; i++)
                {
                    operations.Enqueue($"< {mul + 10} 1 {i + 50}");
                }

                for (int add = 0; add <= 10; add++)
                {
                    operations.Enqueue($"+ {add + 30} {add + 50} {add + 30}");
                }

                for (int i = 0; i <= 10; i++)
                {
                    operations.Enqueue($"< 11 {i + 30} {i + 30}");
                }

                for (int i = 0; i <= 10; i++)
                {
                    operations.Enqueue($"+ {i + 30} 2 2");
                }
            }

            yield return operations.Count;
            foreach (var op in operations)
            {
                yield return op;
            }
        }
    }
}
