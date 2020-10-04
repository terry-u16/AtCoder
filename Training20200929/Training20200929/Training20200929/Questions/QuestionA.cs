using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200929.Algorithms;
using Training20200929.Collections;
using Training20200929.Numerics;
using Training20200929.Questions;

namespace Training20200929.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadLongArray(n);

            a.Sort((x, y) => y.CompareTo(x));


            var last = long.MaxValue;
            var first = -1L;

            foreach (var ai in a)
            {
                if (last == ai)
                {
                    if (first == -1)
                    {
                        first = ai;
                        last = long.MaxValue;   
                    }
                    else
                    {
                        io.WriteLine(first * ai);
                        return;
                    }
                }
                else
                {
                    last = ai;
                }
            }

            io.WriteLine(0);
        }
    }

    static class Util
    {
        public static void Sort<T>(this T[] array) where T : IComparable<T>
        {
            Array.Sort(array);
        }

        public static void Sort<T>(this T[] array, Comparison<T> comparison)
        {
            Array.Sort(array, comparison);
        }
    }
}
