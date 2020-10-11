using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KUPC2020.Algorithms;
using KUPC2020.Collections;
using KUPC2020.Numerics;
using KUPC2020.Questions;

namespace KUPC2020.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            const int n = 15;
            var results = Enumerable.Repeat(0, n).Select(_ => new char[n]).ToArray();

            var seen = new HashSet<string>();
            var lastSelected = (char)('a' - 1);

            // 適当に埋める
            for (int l = 0; l < 2 * n - 1; l++)
            {
                for (int i = 0; i <= Math.Min(l, 2 * n - 2 - l); i++)
                {
                    var row = l < n ? i : (l - (n - 1)) + i;
                    var column = l < n ? l - i : (n - 1) - i;

                    var vertical = new StringBuilder(row + 1);
                    var horizontal = new StringBuilder(column + 1);

                    for (int r = 0; r < row; r++)
                    {
                        vertical.Append(results[r][column]);
                    }

                    for (int c = 0; c < column; c++)
                    {
                        horizontal.Append(results[row][c]);
                    }

                    var ok = false;

                    for (int diff = 1; diff <= 26; diff++)
                    {
                        var c = (char)(lastSelected + diff);
                        if (c > 'z')
                        {
                            c = (char)(c - 26);
                        }

                        var v = vertical.ToString() + c;
                        var h = horizontal.ToString() + c;

                        var found = false;

                        for (int start = 0; start < v.Length - 1; start++)
                        {
                            if (seen.Contains(v.Substring(start)))
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            for (int start = 0; start < h.Length - 1; start++)
                            {
                                if (seen.Contains(h.Substring(start)))
                                {
                                    found = true;
                                    break;
                                }
                            }
                        }

                        if (!found)
                        {
                            lastSelected = c;
                            results[row][column] = c;
                            ok = true;
                            for (int start = 0; start < v.Length - 1; start++)
                            {
                                seen.Add(v.Substring(start));
                            }
                            for (int start = 0; start < h.Length - 1; start++)
                            {
                                seen.Add(h.Substring(start));
                            }
                            break;
                        }
                    }

                    if (!ok)
                    {
                        throw new Exception();
                    }
                }
            }

            io.WriteLine(n);

            foreach (var line in results)
            {
                io.WriteLine(string.Concat(line));
            }
        }
    }
}
