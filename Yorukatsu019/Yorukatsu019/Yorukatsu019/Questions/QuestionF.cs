using Yorukatsu019.Questions;
using Yorukatsu019.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu019.Questions
{
    /// <summary>
    /// ABC152 F
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        List<int>[] nodes;
        List<int>[] constraints;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var treeCount = inputStream.ReadInt();
            nodes = Enumerable.Range(0, treeCount).Select(_ => new List<int>()).ToArray();

            for (int i = 0; i < treeCount; i++)
            {
                var ab = inputStream.ReadIntArray().Select(j => j - 1).ToArray();
                nodes[ab[0]].Add(ab[1]);
                nodes[ab[1]].Add(ab[0]);
            }

            var constraintCount = inputStream.ReadInt();
            constraints = new List<int>[constraintCount];

            for (int i = 0; i < constraintCount; i++)
            {

            }
        }

        int[] firstOrder;
        int[] lastOrder;

        List<int>GetPath(int from, int to)
        {
            var seen = Enumerable.Range(0, nodes.Length).Select(i => i == from).ToArray();
            firstOrder = 
        }

        List<int> GetPath(int from, int to, bool[] seen)
        {
            var currentPath = new Stack<int>();
            var toDo = new Stack<int>();

            foreach (var node in nodes[from])
            {
                toDo.Push(node);
            }

            while (from != to)
            {
                var currentNode = toDo.Pop();

                foreach (var nextNode in nodes[currentNode].Where(i => !seen[i]))
                {
                    toDo.Push(nextNode);
                }
            }
        }
    }
}
