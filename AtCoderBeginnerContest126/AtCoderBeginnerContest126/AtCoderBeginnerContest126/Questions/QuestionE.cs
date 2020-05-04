using AtCoderBeginnerContest126.Questions;
using AtCoderBeginnerContest126.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest126.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];
            var cards = Enumerable.Range(0, n).Select(_ => new UnionFindNode<bool>(false)).ToArray();

            for (int i = 0; i < m; i++)
            {
                var xyz = inputStream.ReadIntArray();
                var x = xyz[0] - 1;
                var y = xyz[1] - 1;
                cards[x].Unite(cards[y]);
            }

            var roots = new HashSet<UnionFindNode<bool>>();
            foreach (var card in cards)
            {
                roots.Add(card.FindRoot());
            }

            yield return roots.Count;
        }

        // See https://kumikomiya.com/competitive-programming-with-c-sharp/
        public class UnionFindNode<T>
        {
            private int _height;        // rootのときのみ有効
            private int _groupSize;     // 同上
            private UnionFindNode<T> _parent;
            public T Item { get; set; }

            public UnionFindNode(T item)
            {
                _height = 0;
                _groupSize = 1;
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

            public int GetGroupSize() => FindRoot()._groupSize;

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

            public bool IsInSameGroup(UnionFindNode<T> other) => this.FindRoot() == other.FindRoot();

            public override string ToString() => $"{Item} root:{FindRoot().Item}";
        }

    }
}
