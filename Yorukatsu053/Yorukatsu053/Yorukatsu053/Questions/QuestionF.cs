using Yorukatsu053.Questions;
using Yorukatsu053.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu053.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc065/tasks/arc076_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var cityCount = inputStream.ReadInt();
            var xCoordinates = new IndexCoordinatePair[cityCount];
            var yCoordinates = new IndexCoordinatePair[cityCount];

            for (int i = 0; i < xCoordinates.Length; i++)
            {
                var xy = inputStream.ReadIntArray();
                var x = xy[0];
                var y = xy[1];
                xCoordinates[i] = new IndexCoordinatePair(i, x);
                yCoordinates[i] = new IndexCoordinatePair(i, y);
            }

            Array.Sort(xCoordinates);
            Array.Sort(yCoordinates);

            var cityPairs = new List<CityPair>();
            for (int i = 0; i + 1 < cityCount; i++)
            {
                var xDiff = xCoordinates[i + 1].Coordinate - xCoordinates[i].Coordinate;
                var yDiff = yCoordinates[i + 1].Coordinate - yCoordinates[i].Coordinate;
                cityPairs.Add(new CityPair(xCoordinates[i].Index, xCoordinates[i + 1].Index, xDiff));
                cityPairs.Add(new CityPair(yCoordinates[i].Index, yCoordinates[i + 1].Index, yDiff));
            }

            cityPairs.Sort();

            var unionFind = new UnionFindTree(cityCount);
            long totalCost = 0;
            foreach (var cityPair in cityPairs)
            {
                if (!unionFind.IsInSameGroup(cityPair.CityA, cityPair.CityB))
                {
                    totalCost += cityPair.Distance;
                    unionFind.Unite(cityPair.CityA, cityPair.CityB);
                }
            }

            yield return totalCost;
        }

        struct IndexCoordinatePair : IComparable<IndexCoordinatePair>
        {
            public int Index { get; }
            public int Coordinate { get; }

            public IndexCoordinatePair(int index, int coordinate)
            {
                Index = index;
                Coordinate = coordinate;
            }

            public int CompareTo(IndexCoordinatePair other) => Coordinate.CompareTo(other.Coordinate);
        }

        struct CityPair : IComparable<CityPair>
        {
            public int CityA { get; }
            public int CityB { get; }
            public int Distance { get; }

            public CityPair(int cityA, int cityB, int distance)
            {
                CityA = cityA;
                CityB = cityB;
                Distance = distance;
            }

            public int CompareTo(CityPair other) => Distance.CompareTo(other.Distance);
        }

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