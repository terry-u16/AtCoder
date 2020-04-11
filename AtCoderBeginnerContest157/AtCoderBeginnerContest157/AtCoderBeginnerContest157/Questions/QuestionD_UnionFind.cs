using AtCoderBeginnerContest157.Questions;
using AtCoderBeginnerContest157.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest157.Questions
{
    // 復習
    public class QuestionD_UnionFind : AtCoderQuestionBase
    {
        int n, m, k;
        UnionFindNode<int>[] people = null;
        List<int>[] friends = null;
        int[] blockCount;
        int[] group;
        List<int> groupMemberCount = new List<int>();

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nmk = inputStream.ReadIntArray();
            n = nmk[0];
            m = nmk[1];
            k = nmk[2];

            people = Enumerable.Range(0, n).Select(i => new UnionFindNode<int>(i)).ToArray();
            friends = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
            group = Enumerable.Repeat(-1, n).ToArray();
            blockCount = new int[n];

            for (int i = 0; i < m; i++)
            {
                var ab = inputStream.ReadIntArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                people[a].Unite(people[b]);
                friends[a].Add(b);
                friends[b].Add(a);
            }

            for (int i = 0; i < k; i++)
            {
                var cd = inputStream.ReadIntArray();
                if (people[cd[0] - 1].IsInSameGroup(people[cd[1] - 1]))
                {
                    blockCount[cd[0] - 1] += 1;
                    blockCount[cd[1] - 1] += 1;
                }
            }

            yield return string.Join(" ", Enumerable.Range(0, n).Select(i => GetFriendCount(i).ToString()));
        }

        int GetFriendCount(int me)
        {
            return people[me].GetSize() - friends[me].Count - blockCount[me] - 1;
        }
    }

    public class UnionFindNode<T>
    {
        private int _height;    // rootのときのみ有効
        private int _size;      // 同上
        private UnionFindNode<T> _parent;
        public T Item { get; }

        public UnionFindNode(T item)
        {
            _height = 0;
            _size = 1;
            _parent = this;
            Item = item;
        }

        public UnionFindNode<T> FindRoot()
        {
            if (_parent != this) // not ref equals
            {
                var root = _parent.FindRoot();
                _parent = root;
            }

            return _parent;
        }

        public int GetSize() => FindRoot()._size;

        public void Unite(UnionFindNode<T> other)
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
                otherRoot._size += thisRoot._size;
                otherRoot._height = Math.Max(thisRoot._height + 1, otherRoot._height);
            }
            else
            {
                otherRoot._parent = thisRoot;
                thisRoot._size += otherRoot._size;
                thisRoot._height = Math.Max(otherRoot._height + 1, thisRoot._height);
            }
        }

        public bool IsInSameGroup(UnionFindNode<T> other) => this.FindRoot() == other.FindRoot();

        public override string ToString() => $"{Item} root:{FindRoot().Item}";
    }
}
