using Training20200606.Questions;
using Training20200606.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200606.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/m-solutions2019/tasks/m_solutions2019_d
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nodeCount = inputStream.ReadInt();
            var edgeCount = nodeCount - 1;

            var edges = new Edge[edgeCount];
            for (int i = 0; i < edgeCount; i++)
            {
                var ab = inputStream.ReadIntArray().Select(n => n - 1).ToArray();
                edges[i] = new Edge(ab[0], ab[1]);
            }

            var c = inputStream.ReadIntArray();
            Array.Sort(c);
            Array.Reverse(c);

            var numbers = new int[nodeCount];
            numbers[edges[0].Node1] = c[0];
            numbers[edges[0].Node2] = c[1];

            for (int i = 2; i < c.Length; i++)
            {
                for (int j = 0; j < edges.Length; j++)
                {
                    if (numbers[edges[j].Node1] == 0 && numbers[edges[j].Node2] != 0)
                    {
                        numbers[edges[j].Node1] = c[i];
                        break;
                    }
                    else if (numbers[edges[j].Node1] != 0 && numbers[edges[j].Node2] == 0)
                    {
                        numbers[edges[j].Node2] = c[i];
                        break;
                    }
                }
            }

            yield return c.Skip(1).Sum();
            yield return string.Join(" ", numbers);
        }

        struct Edge
        {
            public int Node1 { get; }
            public int Node2 { get; }

            public Edge(int node1, int node2)
            {
                Node1 = node1;
                Node2 = node2;
            }
        }
    }
}
