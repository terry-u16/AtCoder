using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20201002.Algorithms;
using Training20201002.Collections;
using Training20201002.Numerics;
using Training20201002.Questions;
using System.Numerics;

namespace Training20201002.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var k = io.ReadInt();
            var s = io.ReadIntArray(n);

            if (s.Contains(0))
            {
                io.WriteLine(n);
                return;
            }

            long mul = 1;
            int maxLength = 0;
            var right = 0;

            for (int left = 0; left < s.Length; left++)
            {
                while (right < s.Length && mul * s[right] <= k)
                {
                    mul *= s[right++];
                }

                maxLength.ChangeMax(right - left);


                if (right == left)
                {
                    right++;
                }
                else
                {
                    mul /= s[left];
                }
            }

            io.WriteLine(maxLength);
        }
    }
}
