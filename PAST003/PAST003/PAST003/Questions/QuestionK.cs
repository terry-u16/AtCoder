using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PAST003.Algorithms;
using PAST003.Collections;
using PAST003.Extensions;
using PAST003.Numerics;
using PAST003.Questions;

namespace PAST003.Questions
{
    public class QuestionK : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (desksCount, queriesCount) = inputStream.ReadValue<int, int>();
            var desks = Enumerable.Range(0, desksCount).Select(i => new BidirectionalLinkedList<int>()).ToArray();
            var containers = new Node<int>[desksCount];
            for (int i = 0; i < desksCount; i++)
            {
                var container = new Node<int>(i, null, null);
                desks[i].InsertLast(container, container);
                containers[i] = container;
            }

            for (int q = 0; q < queriesCount; q++)
            {
                var (from, to, container) = inputStream.ReadValue<int, int, int>();
                from--;
                to--;
                container--;

                var firstNode = containers[container];
                var lastNode = desks[from].Last;
                desks[from].RemoveAfter(firstNode);
                desks[to].InsertLast(firstNode, lastNode);
            }

            var positions = new int[desksCount];
            for (int desk = 0; desk < desksCount; desk++)
            {
                foreach (var container in desks[desk])
                {
                    positions[container] = desk;
                }
            }

            foreach (var position in positions)
            {
                yield return position + 1;
            }
        }

        class BidirectionalLinkedList<T> : IEnumerable<T>
        {
            readonly Node<T> _dummy;
            public Node<T> First => _dummy.Next;
            public Node<T> Last => _dummy.Previous;
            public Node<T> End => _dummy;

            public BidirectionalLinkedList()
            {
                _dummy = new Node<T>(default, null, null);
                _dummy.Next = _dummy;
                _dummy.Previous = _dummy;
            }

            public void InsertLast(Node<T> first, Node<T> last)
            {
                first.Previous = Last;
                Last.Next = first;
                last.Next = End;
                End.Previous = last;
            }

            public void RemoveAfter(Node<T> node)
            {
                var previous = node.Previous;
                previous.Next = End;
                End.Previous = previous;
                node.Previous = null;
            }

            public IEnumerator<T> GetEnumerator()
            {
                var node = First;
                while (node != _dummy)
                {
                    yield return node.Value;
                    node = node.Next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        class Node<T>
        {
            public T Value { get; }
            public Node<T> Previous { get; set; }
            public Node<T> Next { get; set; }

            public Node(T value, Node<T> previous, Node<T> next)
            {
                Value = value;
                Previous = previous;
                Next = next;
            }
        }
    }
}
