using Yorukatsu039.Questions;
using Yorukatsu039.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu039.Questions
{
    /// <summary>
    /// ABC087 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];
            var people = new WeightedUnionFindTree(n);

            for (int i = 0; i < m; i++)
            {
                var lrd = inputStream.ReadIntArray();
                var l = lrd[0] - 1;
                var r = lrd[1] - 1;
                var d = lrd[2];
                if (people.IsInSameGroup(l, r))
                {
                    if (people.GetDifferenceBetween(l, r) != d)
                    {
                        yield return "No";
                        yield break;
                    }
                }
                else
                {
                    people.Unite(l, r, d);
                }
            }

            yield return "Yes";
        }

        // See https://kumikomiya.com/competitive-programming-with-c-sharp/
        public class WeightedUnionFindTree
        {
            private WeightedUnionFindNode[] _nodes;
            public int Count => _nodes.Length;
            public int Groups { get; private set; }

            public WeightedUnionFindTree(int count)
            {
                _nodes = Enumerable.Range(0, count).Select(_ => new WeightedUnionFindNode()).ToArray();
                Groups = _nodes.Length;
            }

            public void Unite(int index1, int index2, long weight)
            {
                var succeed = _nodes[index1].Unite(_nodes[index2], weight);
                if (succeed)
                {
                    Groups--;
                }
            }

            public long GetDifferenceBetween(int index1, int index2) => _nodes[index2].Weight - _nodes[index1].Weight;

            public bool IsInSameGroup(int index1, int index2) => _nodes[index1].IsInSameGroup(_nodes[index2]);
            public int GetGroupSizeOf(int index) => _nodes[index].GetGroupSize();

            private class WeightedUnionFindNode
            {
                private int _height;        // rootのときのみ有効
                private int _groupSize;     // 同上
                private WeightedUnionFindNode _parent;
                private long _weight;

                public long Weight
                {
                    get
                    {
                        FindRoot();
                        return _weight;
                    }
                    private set
                    {
                        _weight = value;
                    }
                }

                public WeightedUnionFindNode()
                {
                    _height = 0;
                    _groupSize = 1;
                    _parent = this;
                    Weight = 0;
                }

                public WeightedUnionFindNode FindRoot()
                {
                    if (_parent != this) // not ref equals
                    {
                        var root = _parent.FindRoot();
                        _weight += _parent._weight;
                        _parent = root;
                    }

                    return _parent;
                }

                public int GetGroupSize() => FindRoot()._groupSize;

                public bool Unite(WeightedUnionFindNode other, long weight)
                {
                    weight += Weight;
                    weight -= other.Weight;

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
                        thisRoot.Weight = -weight;
                        return true;
                    }
                    else
                    {
                        otherRoot._parent = thisRoot;
                        thisRoot._groupSize += otherRoot._groupSize;
                        thisRoot._height = Math.Max(otherRoot._height + 1, thisRoot._height);
                        otherRoot.Weight = +weight;
                        return true;
                    }
                }

                public bool IsInSameGroup(WeightedUnionFindNode other) => this.FindRoot() == other.FindRoot();

                public override string ToString() => $"{Weight} root:{FindRoot().Weight}";
            }
        }

    }
}
