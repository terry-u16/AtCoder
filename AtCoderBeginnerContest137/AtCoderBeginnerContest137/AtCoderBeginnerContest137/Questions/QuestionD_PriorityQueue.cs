using AtCoderBeginnerContest137.Questions;
using AtCoderBeginnerContest137.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest137.Questions
{
    public class QuestionD_PriorityQueue : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];
            var jobs = Enumerable.Range(0, m).Select(_ => new Queue<int>()).ToArray();

            for (int i = 0; i < n; i++)
            {
                var ab = inputStream.ReadIntArray();
                var a = ab[0];
                var b = ab[1];
                if (a <= m)
                {
                    jobs[a - 1].Enqueue(b);
                }
            }

            var jobsQueue = new PriorityQueue<int>();
            var totalSalary = 0;

            for (int day = 0; day < jobs.Length; day++)
            {
                foreach (var job in jobs[day])
                {
                    jobsQueue.Enqueue(job);
                }
                if (jobsQueue.Count > 0)
                {
                    totalSalary += jobsQueue.Dequeue();
                }
            }

            yield return totalSalary;
        }
    }

    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private List<T> _heap = new List<T>();
        private readonly int _reverseFactor;
        public int Count => _heap.Count;
        public bool IsDescending => _reverseFactor == 1;

        public PriorityQueue() : this(null, true) { }

        public PriorityQueue(IEnumerable<T> collection) : this(collection, true) { }

        public PriorityQueue(bool descending) : this(null, descending) { }

        public PriorityQueue(IEnumerable<T> collection, bool descending)
        {
            _reverseFactor = descending ? 1 : -1;
            _heap = new List<T>();

            if (collection != null)
            {
                foreach (var item in collection)
                {
                    Enqueue(item);
                }
            }
        }

        public void Enqueue(T item)
        {
            _heap.Add(item);
            UpHeap();
        }

        public T Dequeue()
        {
            var item = _heap[0];
            DownHeap();
            return item;
        }

        public T Peek() => _heap[0];

        private void UpHeap()
        {
            var child = Count - 1;
            while (child > 0)
            {
                int parent = (child - 1) / 2;

                if (Compare(_heap[child], _heap[parent]) > 0)
                {
                    SwapAt(child, parent);
                    child = parent;
                }
                else
                {
                    break;
                }
            }
        }

        private void DownHeap()
        {
            _heap[0] = _heap[Count - 1];
            _heap.RemoveAt(Count - 1);

            var parent = 0;
            while (true)
            {
                var leftChild = 2 * parent + 1;

                if (leftChild > Count - 1)
                {
                    break;
                }

                var target = (leftChild < Count - 1) && (Compare(_heap[leftChild], _heap[leftChild + 1]) < 0) ? leftChild + 1 : leftChild;

                if (Compare(_heap[parent], _heap[target]) < 0)
                {
                    SwapAt(parent, target);
                }
                else
                {
                    break;
                }

                parent = target;
            }
        }

        private int Compare(T a, T b) => _reverseFactor * a.CompareTo(b);

        private void SwapAt(int n, int m)
        {
            var temp = _heap[n];
            _heap[n] = _heap[m];
            _heap[m] = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var copy = new List<T>(_heap);
            try
            {
                while (Count > 0)
                {
                    yield return Dequeue();
                }
            }
            finally
            {
                _heap = copy;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
