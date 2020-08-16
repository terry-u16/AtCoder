using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200723.Algorithms;
using Training20200723.Collections;
using Training20200723.Extensions;
using Training20200723.Numerics;
using Training20200723.Questions;

namespace Training20200723.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/jsc2019-final/tasks/jsc2019_final_a
    /// </summary>
    public class QuestionI : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int Max = 2000001;
            (_, _) = inputStream.ReadValue<int, int>();
            var sharis = inputStream.ReadIntArray();
            var netas = inputStream.ReadIntArray();
            var sushis = new Sushi[Max].SetAll(_ => new Sushi(-1, -1));

            for (int shariIndex = 0; shariIndex < sharis.Length; shariIndex++)
            {
                for (int netaIndex = 0; netaIndex < netas.Length; netaIndex++)
                {
                    var total = sharis[shariIndex] + netas[netaIndex];
                    if (sushis[total] != new Sushi(-1, -1))
                    {
                        var (shari2, neta2) = sushis[total];
                        yield return $"{shari2} {neta2} {shariIndex} {netaIndex}";
                        yield break;
                    }
                    sushis[total] = new Sushi(shariIndex, netaIndex);
                }
            }

            yield return -1;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Sushi : IEquatable<Sushi>
        {
            public int Shari { get; }
            public int Neta { get; }

            public Sushi(int shari, int neta)
            {
                Shari = shari;
                Neta = neta;
            }

            public void Deconstruct(out int shari, out int neta) => (shari, neta) = (Shari, Neta);
            public override string ToString() => $"{nameof(Shari)}: {Shari}, {nameof(Neta)}: {Neta}";

            public override bool Equals(object obj)
            {
                return obj is Sushi sushi && Equals(sushi);
            }

            public bool Equals(Sushi other)
            {
                return Shari == other.Shari &&
                       Neta == other.Neta;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Shari, Neta);
            }

            public static bool operator ==(Sushi left, Sushi right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Sushi left, Sushi right)
            {
                return !(left == right);
            }
        }
    }
}
