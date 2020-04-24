using AtCoderBeginnerContest139.Questions;
using AtCoderBeginnerContest139.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest139.Questions
{
    /// <summary>
    /// 復習
    /// </summary>
    public class QuestionE_Review : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
        }
    }

    public class Node
    {
        public List<Edge> Edges { get; } = new List<Edge>();

        public Node()
        {
        }


    }

    public class Edge
    {
        public Node From { get; }
        public Node To { get; }

        public Edge(Node from, Node to)
        {
            From = from;
            To = to;
        }
    }

    public class WeightedEdge : Edge
    {
        public int Weight { get; }

        public WeightedEdge(Node from, Node to, int weight) : base(from, to)
        {
            Weight = weight;
        }
    }
}
