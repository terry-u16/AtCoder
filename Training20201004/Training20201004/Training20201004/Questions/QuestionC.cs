using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20201004.Algorithms;
using Training20201004.Collections;
using Training20201004.Numerics;
using Training20201004.Questions;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using AtCoder;
using AtCoder.Internal;
using ModInt = AtCoder.StaticModInt<AtCoder.Mod1000000007>;

namespace Training20201004.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var s = io.ReadString();
            var (moves, plus, minus) = Decode(s);
            var movePoints = new int[moves.Length];

            for (int i = 0; i < moves.Length; i++)
            {
                var index = moves[i];
                movePoints[i] = (plus[^1] - plus[index]) - (minus[^1] - minus[index]);
            }

            movePoints.Sort((a, b) => b.CompareTo(a));

            var total = 0;

            for (int i = 0; i < movePoints.Length / 2; i++)
            {
                total += movePoints[i];
            }

            for (int i = movePoints.Length / 2; i < movePoints.Length; i++)
            {
                total -= movePoints[i];
            }

            io.WriteLine(total);
        }

        (int[] moveIndice, int[] plusSum, int[] minusSum) Decode(string s)
        {
            var moves = new List<int>();
            var plus = new int[s.Length + 1];
            var minus = new int[s.Length + 1];

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'M':
                        moves.Add(i);
                        break;
                    case '+':
                        plus[i + 1]++;
                        break;
                    case '-':
                        minus[i + 1]++;
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i + 1 < plus.Length; i++)
            {
                plus[i + 1] += plus[i];
                minus[i + 1] += minus[i];
            }

            return (moves.ToArray(), plus, minus);
        }
    }
}
