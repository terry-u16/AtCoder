// ここにQuestionクラスをコピペ
using Training20200530.Questions;
using Training20200530.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200530
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtCoderQuestion question = new QuestionB();    // 問題に合わせて書き換え
            var answers = question.Solve(Console.In);
            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }
    }

    public interface INode
    {
        int Index { get; }
    }

    public interface IEdge<TNode> where TNode : INode
    {
        TNode From { get; }
        TNode To { get; }
    }

    public interface IWeightedEdge<TNode> : IEdge<TNode> where TNode : INode
    {
        int Weight { get; }
    }

    public interface IGraph<TNode, TEdge> where TEdge : IEdge<TNode> where TNode : INode
    {
        IEnumerable<TEdge> this[TNode node] { get; }
        IEnumerable<TEdge> Edges { get; }
        IEnumerable<TNode> Nodes { get; }
        int NodeCount { get; }
    }

    public struct BasicNode : INode
    {
        public int Index { get; }

        public BasicNode(int index)
        {
            Index = index;
        }

        public override string ToString() => Index.ToString();
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
    public struct WeightedEdge : IWeightedEdge<BasicNode>
    {
        public BasicNode From { get; }
        public BasicNode To { get; }
        public int Weight { get; }

        public WeightedEdge(int from, int to) : this(from, to, 1) { }

        public WeightedEdge(int from, int to, int weight)
        {
            From = new BasicNode(from);
            To = new BasicNode(to);
            Weight = weight;
        }

        public override string ToString() => $"{From}--[{Weight}]-->{To}";
    }

    public class WeightedGraph : IGraph<BasicNode, WeightedEdge>
    {
        private readonly List<WeightedEdge>[] _edges;
        public IEnumerable<WeightedEdge> this[BasicNode node] => _edges[node.Index];
        public IEnumerable<WeightedEdge> Edges => Nodes.SelectMany(node => this[node]);
        public IEnumerable<BasicNode> Nodes => Enumerable.Range(0, NodeCount).Select(i => new BasicNode(i));
        public int NodeCount { get; }

        public WeightedGraph(int nodeCount) : this(nodeCount, Enumerable.Empty<WeightedEdge>()) { }

        public WeightedGraph(int nodeCount, IEnumerable<WeightedEdge> edges)
        {
            _edges = Enumerable.Repeat(0, nodeCount).Select(_ => new List<WeightedEdge>()).ToArray();
            NodeCount = nodeCount;
            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        public WeightedGraph(int nodeCount, IEnumerable<IEnumerable<int>> distances)
        {
            _edges = new List<WeightedEdge>[nodeCount];

            int i = 0;
            foreach (var row in distances)
            {
                _edges[i] = new List<WeightedEdge>(nodeCount);
                int j = 0;
                foreach (var distance in row)
                {
                    _edges[i].Add(new WeightedEdge(i, j++, distance));
                }
                i++;
            }
        }

        public void AddEdge(WeightedEdge edge) => _edges[edge.From.Index].Add(edge);
    }

    namespace Algorithms
    {
        public class BellmanFord<TNode, TEdge> where TEdge : IWeightedEdge<TNode> where TNode : INode
        {
            protected readonly List<TEdge> _edges;
            protected readonly int _nodeCount;

            public BellmanFord(IGraph<TNode, TEdge> graph) : this(graph.Edges, graph.NodeCount) { }

            public BellmanFord(IEnumerable<TEdge> edges, int nodeCount)
            {
                _edges = edges.ToList();
                _nodeCount = nodeCount;
            }

            public Tuple<long[], bool[]> GetDistancesFrom(TNode startNode)
            {
                var distances = Enumerable.Repeat(long.MaxValue, _nodeCount).ToArray();
                var negativeCycleNodes = new bool[_nodeCount];
                distances[startNode.Index] = 0;

                for (int i = 1; i <= 2 * _nodeCount; i++)
                {
                    foreach (var edge in _edges)
                    {
                        // そもそも出発点に未到達なら無視
                        if (distances[edge.From.Index] < (long.MaxValue >> 1))
                        {
                            if (i <= _nodeCount)
                            {
                                var newCost = distances[edge.From.Index] + edge.Weight;
                                if (distances[edge.To.Index] > newCost)
                                {
                                    distances[edge.To.Index] = newCost;
                                    if (i == _nodeCount)
                                    {
                                        negativeCycleNodes[edge.To.Index] = true;
                                    }
                                }
                            }
                            else if (negativeCycleNodes[edge.From.Index])
                            {
                                negativeCycleNodes[edge.To.Index] = true;
                            }
                        }
                    }
                }

                for (int i = 0; i < _nodeCount; i++)
                {
                    if (negativeCycleNodes[i])
                    {
                        distances[i] = long.MinValue;
                    }
                }

                return new Tuple<long[], bool[]>(distances, negativeCycleNodes);
            }
        }
    }

}

#region Base Classes

namespace Training20200530.Questions
{

    public interface IAtCoderQuestion
    {
        IEnumerable<object> Solve(string input);
        IEnumerable<object> Solve(TextReader inputStream);
    }

    public abstract class AtCoderQuestionBase : IAtCoderQuestion
    {
        public IEnumerable<object> Solve(string input)
        {
            var stream = new MemoryStream(Encoding.Unicode.GetBytes(input));
            var reader = new StreamReader(stream, Encoding.Unicode);

            return Solve(reader);
        }

        public abstract IEnumerable<object> Solve(TextReader inputStream);
    }

}

#endregion

#region Extensions

namespace Training20200530.Extensions
{
    internal static class TextReaderExtensions
    {
        internal static int ReadInt(this TextReader reader) => int.Parse(ReadString(reader));
        internal static long ReadLong(this TextReader reader) => long.Parse(ReadString(reader));
        internal static double ReadDouble(this TextReader reader) => double.Parse(ReadString(reader));
        internal static string ReadString(this TextReader reader) => reader.ReadLine();

        internal static int[] ReadIntArray(this TextReader reader, char separator = ' ') => ReadStringArray(reader, separator).Select(int.Parse).ToArray();
        internal static long[] ReadLongArray(this TextReader reader, char separator = ' ') => ReadStringArray(reader, separator).Select(long.Parse).ToArray();
        internal static double[] ReadDoubleArray(this TextReader reader, char separator = ' ') => ReadStringArray(reader, separator).Select(double.Parse).ToArray();
        internal static string[] ReadStringArray(this TextReader reader, char separator = ' ') => reader.ReadLine().Split(separator);
    }
}

#endregion