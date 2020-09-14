using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Test20200914.Algorithms;
using Test20200914.Collections;
using Test20200914.Extensions;
using Test20200914.Numerics;
using Test20200914.Questions;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using ModInt = AtCoder.DynamicModInt<AtCoder.ModID0>;

namespace Test20200914.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            ModInt.Mod = 1000000007;
            var (blacks, whites) = inputStream.ReadValue<int, int>();
            var blackProb = new ModInt();   // 黒しか選べない確率
            var whiteProb = new ModInt();   // 白しか選べない確率

            var combination = new Combination(blacks + whites);
            var two = new ModInt(0);

            // verify用
            two++;
            two++;

            for (int i = 0; i < blacks + whites; i++)
            {
                yield return (1 + blackProb - whiteProb) / 2;

                if (i >= whites - 1)
                {
                    blackProb += combination.Calculate(i, whites - 1) / two.Pow(i + 1);
                }

                if (i >= blacks - 1)
                {
                    whiteProb += combination.Calculate(i, blacks - 1) / two.Pow(i + 1);
                }
            }
        }

        class Combination
        {
            ModInt[] _facts;
            ModInt[] _invFacts;

            public Combination(int max)
            {
                _facts = new ModInt[max + 1];
                _invFacts = new ModInt[max + 1];

                _facts[0] = 1;
                for (int i = 1; i < _facts.Length; i++)
                {
                    _facts[i] = _facts[i - 1] * i;
                }

                _invFacts[^1] = 1 / _facts[^1];
                for (int i = _invFacts.Length - 1; i > 0; i--)
                {
                    _invFacts[i - 1] = _invFacts[i] * i;
                }
            }

            public ModInt Calculate(int n, int r) => _facts[n] * _invFacts[r] * _invFacts[n - r];
        }
    }
}
