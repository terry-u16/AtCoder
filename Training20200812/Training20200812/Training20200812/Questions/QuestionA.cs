using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200812.Algorithms;
using Training20200812.Collections;
using Training20200812.Extensions;
using Training20200812.Numerics;
using Training20200812.Questions;
using System.Numerics;

namespace Training20200812.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var engines = new Complex[n];
            for (int i = 0; i < engines.Length; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                engines[i] = new Complex(x, y);
            }

            Array.Sort(engines, (z1, z2) => Math.Sign(z1.Phase - z2.Phase));

            double max = 0;

            for (int left = 0; left < engines.Length; left++)
            {
                for (int select = 1; select <= engines.Length; select++)
                {
                    var position = Complex.Zero;
                    for (int i = 0; i < select; i++)
                    {
                        position += engines[(left + i) % engines.Length];
                    }
                    max = Math.Max(max, position.Magnitude);
                }
            }

            yield return max;
        }
    }
}
