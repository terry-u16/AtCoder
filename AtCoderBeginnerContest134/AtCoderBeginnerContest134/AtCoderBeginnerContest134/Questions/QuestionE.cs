using AtCoderBeginnerContest134.Questions;
using AtCoderBeginnerContest134.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest134.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var binarySearchTree = new RandomizedBinarySearchTree<int>();

            binarySearchTree.Add(inputStream.ReadInt());

            for (int i = 1; i < n; i++)
            {
                var a = inputStream.ReadInt();
                var upperIndex = binarySearchTree.GetUpperBound(a - 1);
                if (0 <= upperIndex)
                {
                    var last = binarySearchTree[upperIndex];
                    binarySearchTree.Remove(last);
                }

                binarySearchTree.Add(a);
            }

            yield return binarySearchTree.Count;
        }
    }

    public class RandomizedBinarySearchTree<T> : ICollection<T>, IReadOnlyCollection<T> where T : IComparable<T>
    {
        public int Count => _rootNode.Count;
        public bool IsReadOnly => false;

        private Node _rootNode;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _rootNode.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return _rootNode[index].Value;
            }
        }

        // TODO: null処理
        public int GetLowerBound(T minValue) => _rootNode.GetLowerBoundIndex(minValue);
        public int GetUpperBound(T maxValue) => _rootNode.GetUpperBoundIndex(maxValue);

        #region ICollection<T> Members

        public void Add(T item)
        {
            if (_rootNode != null)
            {
                _rootNode = _rootNode.Add(item);
            }
            else
            {
                _rootNode = new Node(item);
            }
        }

        public void Clear() => _rootNode = null;

        public bool Contains(T item) => _rootNode.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            // TODO: Sliceする
            var index = arrayIndex;
            foreach (var node in _rootNode.EnumerateChildren())
            {
                array[index++] = node.Value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_rootNode != null)
            {
                foreach (var node in _rootNode.EnumerateChildren())
                {
                    yield return node.Value;
                }
            }
        }

        public bool Remove(T item)
        {
            if (_rootNode.FindNode(item) != null)
            {
                _rootNode = _rootNode.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        private class Node
        {
            private static Random _random = new Random();
            private Node _leftChild;
            private Node _rightChild;

            public int Count { get; private set; }
            public T Value { get; }

            public Node(T value)
            {
                Value = value;
                Count = 1;
            }

            protected virtual void Update() => Count = (_leftChild?.Count ?? 0) + (_rightChild?.Count ?? 0) + 1;

            public Node this[int index]
            {
                get
                {
                    // range外の値は来ない（親クラスで弾く）と想定
                    var leftCount = _leftChild?.Count ?? 0;
                    if (leftCount > index)
                    {
                        return _leftChild[index];
                    }
                    else if (leftCount == index)
                    {
                        return this;
                    }
                    else
                    {
                        return _rightChild[index - (leftCount + 1)];
                    }
                }
            }

            private static Node Merge(Node left, Node right)
            {
                if (left == null)
                {
                    return right;   // rightもnullだったらnullを返す
                }
                else if (right == null)
                {
                    return left;
                }

                if (left.Count > _random.Next(left.Count + right.Count))    // N / (N + M) の確率でN側が根になる
                {
                    left._rightChild = Merge(left._rightChild, right);
                    left.Update();
                    return left;
                }
                else
                {
                    right._leftChild = Merge(left, right._leftChild);
                    right.Update();
                    return right;
                }
            }

            public Tuple<Node, Node> SplitAt(int index)
            {
                if (index <= (_leftChild?.Count ?? 0))
                {
                    var splittedLeftSubtree = _leftChild?.SplitAt(index);
                    _leftChild = splittedLeftSubtree?.Item2;
                    Update();
                    return new Tuple<Node, Node>(splittedLeftSubtree?.Item1, this);
                }
                else
                {
                    var splittedRightSubtree = _rightChild?.SplitAt(index - (_leftChild?.Count ?? 0) - 1);   // 左側のサブツリーと自分（親）の分飛ばす
                    _rightChild = splittedRightSubtree?.Item1;
                    Update();
                    return new Tuple<Node, Node>(this, splittedRightSubtree?.Item2);
                }
            }

            public IEnumerable<Node> EnumerateChildren()
            {
                // 左の子、自分、右の子の順番で列挙
                if (_leftChild != null)
                {
                    foreach (var node in _leftChild.EnumerateChildren())
                    {
                        yield return node;
                    }
                }
                yield return this;
                if (_rightChild != null)
                {
                    foreach (var nodeValue in _rightChild.EnumerateChildren())
                    {
                        yield return nodeValue;
                    }
                }
            }

            public int GetLowerBoundIndex(T minValue)
            {
                // |<---NG--->|<-----OK----->|となる境界（OK側）を探す
                if (Value.CompareTo(minValue) >= 0)    // 少なくとも自分は満たす
                {
                    // 左の子があればそっち、なければ自分が一番小さいので0
                    return _leftChild?.GetLowerBoundIndex(minValue) ?? 0;
                }
                else
                {
                    // （左の子の個数）+（自分）+（右の子の中で再検索）
                    return (_leftChild?.Count ?? 0) + 1 + (_rightChild?.GetLowerBoundIndex(minValue) ?? 0);
                }
            }

            public int GetUpperBoundIndex(T maxValue)
            {
                // |<---OK--->|<-----NG----->|となる境界（OK側）を探す
                if (Value.CompareTo(maxValue) <= 0)    // 少なくとも自分は満たす
                {
                    // （左の子の個数）+（自分）+（右の子の中で再検索）
                    return (_leftChild?.Count ?? 0) + 1 + (_rightChild?.GetUpperBoundIndex(maxValue) ?? -1);
                }
                else
                {
                    // 左の子があればそっち、なければ自分が一番小さい。後者の場合、自分は当てはまらないので-1。
                    return _leftChild?.GetUpperBoundIndex(maxValue) ?? -1;
                }
            }

            public Node Add(T value)
            {
                var index = GetLowerBoundIndex(value);
                return InsertAt(index, value);
            }

            private Node InsertAt(int index, T value)
            {
                var splitted = SplitAt(index);
                return Merge(Merge(splitted.Item1, new Node(value)), splitted.Item2);
            }

            public Node FindNode(T value)
            {
                var compare = Value.CompareTo(value);
                if (compare > 0)
                {
                    return _leftChild?.FindNode(value);
                }
                else if (compare == 0)
                {
                    return this;
                }
                else
                {
                    return _rightChild?.FindNode(value);
                }
            }

            public bool Contains(T value) => FindNode(value) != null;

            public Node Remove(T item)
            {
                // 存在チェックは親クラスでしているものとする
                var index = GetLowerBoundIndex(item);
                return RemoveAt(index);
            }

            private Node RemoveAt(int index)
            {
                var left = SplitAt(index);
                var right = left.Item2.SplitAt(1);
                return Merge(left.Item1, right.Item2);
            }
        }

    }

}
