using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu085.Algorithms;
using Kujikatsu085.Collections;
using Kujikatsu085.Extensions;
using Kujikatsu085.Numerics;
using Kujikatsu085.Questions;

namespace Kujikatsu085.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, a, b, c) = inputStream.ReadValue<int, int, int, int>();
            var abc = new int[] { a, b, c };
            var current = ToInt(inputStream.ReadLine());

            var operations = new Queue<char>();

            for (int i = 0; i < n; i++)
            {
                var next = i < n - 1 ? ToInt(inputStream.ReadLine()) : 0;

                if (abc[current] == 0 && abc[(current + 1) % 3] == 0)
                {
                    yield return "No";
                    yield break;
                }
                else if (abc[current] == 0)
                {
                    abc[current]++;
                    abc[(current + 1) % 3]--;
                    operations.Enqueue(ToChar(current));
                }
                else if (abc[(current + 1) % 3] == 0)
                {
                    abc[current]--;
                    abc[(current + 1) % 3]++;
                    operations.Enqueue(ToChar(current + 1));
                }
                else if (abc[current] == 1 && abc[(current + 1) % 3] == 1)
                {
                    if (next == (current + 1) % 3)
                    {
                        abc[current]--;
                        abc[(current + 1) % 3]++;
                        operations.Enqueue(ToChar(current + 1));
                    }
                    else
                    {
                        abc[current]++;
                        abc[(current + 1) % 3]--;
                        operations.Enqueue(ToChar(current));
                    }
                }
                else if (abc[current] > abc[(current + 1) % 3])
                {
                    abc[current]--;
                    abc[(current + 1) % 3]++;
                    operations.Enqueue(ToChar(current + 1));
                }
                else
                {
                    abc[current]++;
                    abc[(current + 1) % 3]--;
                    operations.Enqueue(ToChar(current));
                }

                current = next;
            }

            yield return "Yes";
            foreach (var op in operations)
            {
                yield return op;
            }
        }

        int ToInt(string op)
        {
            switch (op)
            {
                case "AB":
                    return 0;
                case "BC":
                    return 1;
                case "AC":
                    return 2;
                default:
                    return -1;
            }
        }

        char ToChar(int n) => (char)(n % 3 + 'A');
    }
}
