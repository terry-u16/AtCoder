using AtCoderBeginnerContest120.Questions;
using AtCoderBeginnerContest120.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest120.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var islandsCount = nm[0];
            var bridgesCount = nm[1];

            var bridges = new Bridge[bridgesCount];

            for (int i = 0; i < bridgesCount; i++)
            {
                var ab = inputStream.ReadIntArray();
                bridges[i] = new Bridge(ab[0] - 1, ab[1] - 1);
            }

            var conveniences = new long[bridgesCount + 1];
            var islands = new UnionFindTree(islandsCount);
            for (int i = bridges.Length - 1; i >= 0; i--)
            {
                var bridge = bridges[i];
                conveniences[i] = conveniences[i + 1];

                if (!islands.IsInSameGroup(bridge.Island1, bridge.Island2))
                {
                    conveniences[i] += (long)islands.GetGroupSizeOf(bridge.Island1) * islands.GetGroupSizeOf(bridge.Island2);
                    islands.Unite(bridge.Island1, bridge.Island2);
                }
            }

            long unconvenience = 0;
            for (int i = 0; i < bridges.Length; i++)
            {
                unconvenience += conveniences[i] - conveniences[i + 1];
                yield return unconvenience;
            }
        }

        struct Bridge
        {
            public int Island1 { get; }
            public int Island2 { get; }

            public Bridge(int island1, int island2)
            {
                Island1 = island1;
                Island2 = island2;
            }
        }

        // See https://kumikomiya.com/competitive-programming-with-c-sharp/
        public class UnionFindTree
        {
            private UnionFindNode[] _nodes;
            public int Count => _nodes.Length;

            public UnionFindTree(int count)
            {
                _nodes = Enumerable.Range(0, count).Select(i => new UnionFindNode(i)).ToArray();
            }

            public void Unite(int index1, int index2) => _nodes[index1].Unite(_nodes[index2]);
            public bool IsInSameGroup(int index1, int index2) => _nodes[index1].IsInSameGroup(_nodes[index2]);
            public int GetGroupSizeOf(int index) => _nodes[index].GetGroupSize();
            public int GetGroupCount()
            {
                var hashSet = new HashSet<int>();
                foreach (var node in _nodes)
                {
                    hashSet.Add(node.FindRoot().ID);
                }
                return hashSet.Count;
            }

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

                public void Unite(UnionFindNode other)
                {
                    var thisRoot = this.FindRoot();
                    var otherRoot = other.FindRoot();

                    if (thisRoot == otherRoot)
                    {
                        return;
                    }

                    if (thisRoot._height < otherRoot._height)
                    {
                        thisRoot._parent = otherRoot;
                        otherRoot._groupSize += thisRoot._groupSize;
                        otherRoot._height = Math.Max(thisRoot._height + 1, otherRoot._height);
                    }
                    else
                    {
                        otherRoot._parent = thisRoot;
                        thisRoot._groupSize += otherRoot._groupSize;
                        thisRoot._height = Math.Max(otherRoot._height + 1, thisRoot._height);
                    }
                }

                public bool IsInSameGroup(UnionFindNode other) => this.FindRoot() == other.FindRoot();

                public override string ToString() => $"{ID} root:{FindRoot().ID}";
            }
        }


    }
}
