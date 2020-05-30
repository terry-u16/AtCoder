using VirtualContest20200530.Questions;
using VirtualContest20200530.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VirtualContest20200530.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadLongArray();
            var a = ab[0];
            var b = ab[1];
            var cardCount = (int)(b - a + 1);

            var divisiors = Enumerable.Repeat(0, cardCount).Select(_ => new HashSet<int>()).ToArray();

            for (long i = a; i <= b; i++)
            {
                for (long j = i + 1; j <= b; j++)
                {
                    var gcd = Gcd(i, j);
                    foreach (var divisior in GetDivisiors(gcd))
                    {
                        divisiors[i - a].Add(divisior);
                        divisiors[j - a].Add(divisior);
                    }
                }
            }

            yield return Count(a, a, b, new HashSet<int>(), divisiors);
        }

        long Count(long current, long a, long b, HashSet<int> currentDivs, HashSet<int>[] divs)
        {
            if (current > b)
            {
                return 1;
            }

            long count = 0;

            // 選ばない
            count += Count(current + 1, a, b, currentDivs, divs);

            // 選ぶ
            if (!currentDivs.Overlaps(divs[current - a]))
            {
                var newDivs = new HashSet<int>(currentDivs);
                newDivs.UnionWith(divs[current - a]);
                count += Count(current + 1, a, b, newDivs, divs);
            }

            return count;
        }

        long Pow2(int n) => 1L << n;

        IEnumerable<int> GetDivisiors(int n)
        {
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    var other = n / i;
                    if (i != 1)
                    {
                        yield return i;
                    }
                    if (i != other)
                    {
                        yield return other;
                    }
                }
            }
        }

        public static int Gcd(long a, long b)
        {
            if (a <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a), $"{nameof(b)}は正の整数である必要があります。");
            }
            if (b <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)}は正の整数である必要があります。");
            }
            if (a < b)
            {
                var temp = a;
                a = b;
                b = temp;
            }

            while (b != 0)
            {
                var temp = a % b;
                a = b;
                b = temp;

            }
            return (int)a;
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
