using Yorukatsu052.Questions;
using Yorukatsu052.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu052.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc120/tasks/abc120_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var islandsCount = nm[0];
            var bridgesCount = nm[1];

            var bridges = new Bridge[bridgesCount];

            for (int i = 0; i < bridges.Length; i++)
            {
                var ab = inputStream.ReadIntArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                bridges[i] = new Bridge(a, b);
            }

            var inconvenienceDiff = new Stack<long>(bridgesCount);
            var islandGroups = new UnionFindTree(islandsCount);

            foreach (var bridge in bridges.Reverse())
            {
                if (!islandGroups.IsInSameGroup(bridge.IslandA, bridge.IslandB))
                {
                    long groupA = islandGroups.GetGroupSizeOf(bridge.IslandA);
                    long groupB = islandGroups.GetGroupSizeOf(bridge.IslandB);
                    inconvenienceDiff.Push(groupA * groupB);
                    islandGroups.Unite(bridge.IslandA, bridge.IslandB);
                }
                else
                {
                    inconvenienceDiff.Push(0);
                }
            }

            long total = 0;
            foreach (var diff in inconvenienceDiff)
            {
                total += diff;
                yield return total;
            }
        }

        struct Bridge
        {
            public int IslandA { get; }
            public int IslandB { get; }

            public Bridge(int islandA, int islandB)
            {
                IslandA = islandA;
                IslandB = islandB;
            }
        }

        // See https://kumikomiya.com/competitive-programming-with-c-sharp/
        public class UnionFindTree
        {
            private UnionFindNode[] _nodes;
            public int Count => _nodes.Length;
            public int Groups { get; private set; }

            public UnionFindTree(int count)
            {
                _nodes = Enumerable.Range(0, count).Select(i => new UnionFindNode(i)).ToArray();
                Groups = _nodes.Length;
            }

            public void Unite(int index1, int index2)
            {
                var succeed = _nodes[index1].Unite(_nodes[index2]);
                if (succeed)
                {
                    Groups--;
                }
            }

            public bool IsInSameGroup(int index1, int index2) => _nodes[index1].IsInSameGroup(_nodes[index2]);
            public int GetGroupSizeOf(int index) => _nodes[index].GetGroupSize();

            private class UnionFindNode
            {
                private int _height;        // rootのときのみ有効
                private int _groupSize;     // 同上
                private UnionFindNode _parent;
                public int ID { get; }

                public UnionFindNode(int id)
                {
                    _height = 0;
                    _groupSize = 1;
                    _parent = this;
                    ID = id;
                }

                public UnionFindNode FindRoot()
                {
                    if (_parent != this) // not ref equals
                    {
                        var root = _parent.FindRoot();
                        _parent = root;
                    }

                    return _parent;
                }

                public int GetGroupSize() => FindRoot()._groupSize;

                public bool Unite(UnionFindNode other)
                {
                    var thisRoot = this.FindRoot();
                    var otherRoot = other.FindRoot();

                    if (thisRoot == otherRoot)
                    {
                        return false;
                    }

                    if (thisRoot._height < otherRoot._height)
                    {
                        thisRoot._parent = otherRoot;
                        otherRoot._groupSize += thisRoot._groupSize;
                        otherRoot._height = Math.Max(thisRoot._height + 1, otherRoot._height);
                        return true;
                    }
                    else
                    {
                        otherRoot._parent = thisRoot;
                        thisRoot._groupSize += otherRoot._groupSize;
                        thisRoot._height = Math.Max(otherRoot._height + 1, thisRoot._height);
                        return true;
                    }
                }

                public bool IsInSameGroup(UnionFindNode other) => this.FindRoot() == other.FindRoot();

                public override string ToString() => $"{ID} root:{FindRoot().ID}";
            }
        }

    }
}
