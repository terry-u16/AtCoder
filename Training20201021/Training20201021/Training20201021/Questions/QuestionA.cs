using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using Training20201021.Algorithms;
using Training20201021.Collections;
using Training20201021.Numerics;
using Training20201021.Questions;

namespace Training20201021.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var s = io.ReadString();
            var dp = new int[s.Length + 1, 26];
            dp.Fill(1 << 28);

            for (int i = 0; i < 26; i++)
            {
                dp[0, i] = 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (var c = 0; c < 26; c++)
                {
                    for (var next = 0; next < 26; next++)
                    {
                        dp[i + 1, next].ChangeMin(dp[i, c] + 1);
                    }

                    if (s[i] != c + 'a')
                    {
                        dp[i + 1, c].ChangeMin(dp[i, c]);
                    }
                }
            }

            var minLength = int.MaxValue;

            for (int c = 0; c < 26; c++)
            {
                minLength.ChangeMin(dp[s.Length, c]);
            }

            var reachable = new bool[s.Length + 1, 26];

            for (int c = 0; c < 26; c++)
            {
                if (dp[s.Length, c] == minLength)
                {
                    reachable[s.Length, c] = true;
                    break;
                }
            }

            for (int i = s.Length; i > 0; i--)
            {
                for (int c = 0; c < 26; c++)
                {
                    if (reachable[i, c])
                    {
                        for (int before = 0; before < 26; before++)
                        {
                            if ((c == before && dp[i, c] - dp[i - 1, c] == 0) || dp[i, c] - dp[i - 1, before] == 1)
                            {
                                reachable[i - 1, before] = true;
                            }
                        }
                    }
                }
            }

            var result = new StringBuilder(minLength);
            var last = int.MaxValue;

            for (int i = 0; i < s.Length; i++)
            {
                for (int c = 0; c < 26; c++)
                {
                    if (reachable[i, c])
                    {
                        if (last == c && dp[i, c] - result.Length == 0)
                        {
                            last = c;
                            break;
                        }
                        else if (dp[i, c] - result.Length == 1)
                        {
                            last = c;
                            result.Append((char)(c + 'a'));
                            break;
                        }
                    }
                }
            }

            io.WriteLine(result.ToString());
        }
    }
}
