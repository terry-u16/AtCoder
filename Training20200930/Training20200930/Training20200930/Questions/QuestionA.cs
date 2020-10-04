using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200930.Algorithms;
using Training20200930.Collections;
using Training20200930.Numerics;
using Training20200930.Questions;

namespace Training20200930.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var rooms = new RedBlackTree<int>[100000];

            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = new RedBlackTree<int>();
            }

            for (int i = 0; i < n; i++)
            {
                var a = io.ReadInt() - 1;
                rooms[a].Add(i + 1);
            }

            var current = 1;
            var loops = 0;

            for (int fun = 0; fun < rooms.Length; fun++)
            {
                while (rooms[fun].Count > 0)
                {
                    var next = rooms[fun].EnumerateRange(current, int.MaxValue).FirstOrDefault();

                    if (next == default)
                    {
                        next = rooms[fun].Min;
                        loops++;
                    }

                    current = next;
                    rooms[fun].Remove(next);
                }
            }

            if (current > 1)
            {
                loops++;
            }

            io.WriteLine(loops);
        }
    }
}
