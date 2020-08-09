using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderGrandContest047.Algorithms;
using AtCoderGrandContest047.Collections;
using AtCoderGrandContest047.Extensions;
using AtCoderGrandContest047.Numerics;
using AtCoderGrandContest047.Questions;

namespace AtCoderGrandContest047.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = new string[n];
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = inputStream.ReadLine().Reverse().Join();
            }

            Array.Sort(s, StringComparer.Ordinal);

            long result = 0;
            var stack = new Stack<string>();

            for (int i = 0; i < s.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(s[i]);
                }
                else
                {
                    var current = s[i];

                    while (stack.Count > 0)
                    {
                        var last = stack.Pop();
                        var ok = true;
                        for (int j = 0; j < last.Length - 1; j++)
                        {
                            if (last[j] != s[i][j])
                            {
                                ok = false;
                                break;
                            }
                        }

                        if (ok)
                        {
                            ok = false;
                            for (int j = last.Length - 1; j < current.Length; j++)
                            {
                                if (last[^1] == current[j])
                                {
                                    ok = true;
                                    break;
                                }
                            }
                        }

                        if (ok)
                        {
                            stack.Push(last);
                            result += stack.Count;
                            break;
                        }
                    }

                    stack.Push(current);
                }
            }

            yield return result;
        }
    }
}
