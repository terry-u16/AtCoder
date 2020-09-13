using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200912.Algorithms;
using Training20200912.Collections;
using Training20200912.Extensions;
using Training20200912.Numerics;
using Training20200912.Questions;

namespace Training20200912.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, days, kinds) = inputStream.ReadValue<int, int, int>();
            var movements = new Movement[days];
            for (int i = 0; i < movements.Length; i++)
            {
                var (l, r) = inputStream.ReadValue<int, int>();
                movements[i] = new Movement(l, r);
            }

            for (int i = 0; i < kinds; i++)
            {
                var (s, t) = inputStream.ReadValue<int, int>();

                if (s < t)
                {
                    for (int day = 0; day < movements.Length; day++)
                    {
                        var m = movements[day];
                        if (m.L <= s && s <= m.R)
                        {
                            s = m.R;
                        }

                        if (s >= t)
                        {
                            yield return day + 1;
                            break;
                        }
                    }
                }
                else
                {
                    for (int day = 0; day < movements.Length; day++)
                    {
                        var m = movements[day];
                        if (m.L <= s && s <= m.R)
                        {
                            s = m.L;
                        }

                        if (s <= t)
                        {
                            yield return day + 1;
                            break;
                        }
                    }

                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Movement
        {
            public int L { get; }
            public int R { get; }

            public Movement(int l, int r)
            {
                L = l;
                R = r;
            }

            public void Deconstruct(out int l, out int r) => (l, r) = (L, R);
            public override string ToString() => $"{nameof(L)}: {L}, {nameof(R)}: {R}";
        }
    }
}
