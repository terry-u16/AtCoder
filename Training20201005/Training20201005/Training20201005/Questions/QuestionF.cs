using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20201005.Algorithms;
using Training20201005.Collections;
using Training20201005.Numerics;
using Training20201005.Questions;

namespace Training20201005.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var rbTree = new RedBlackTree<int>();

            for (int i = 0; i < 10; i++)
            {
                rbTree.Add(i);
                rbTree.Add(i + 1);
                rbTree.Add(i + 2);
            }

            foreach (var item in rbTree.EnumerateRange(3, 8))
            {
                Console.WriteLine(item);
            }
        }
    }
}
