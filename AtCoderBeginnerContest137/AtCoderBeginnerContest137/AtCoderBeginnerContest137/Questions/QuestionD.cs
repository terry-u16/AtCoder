using AtCoderBeginnerContest137.Questions;
using AtCoderBeginnerContest137.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest137.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];
            var jobs = new Job[n];

            for (int i = 0; i < n; i++)
            {
                var ab = inputStream.ReadIntArray();
                jobs[i] = new Job(ab[0], ab[1]);
            }

            var orderedJobs = jobs.Where(j => j.Delay <= m).OrderByDescending(j => j.Salary).ToArray();
            var jobsQueue = new Queue<Job>();

            var availableDays = new SegmentTree<int>(Enumerable.Range(1, m).ToArray(), (a, b) => Math.Min(a, b), int.MaxValue);

            foreach (var job in orderedJobs)
            {
                var availableMinDay = availableDays.Query(job.Delay - 1, availableDays.Length);
                if (availableMinDay != int.MaxValue)
                {
                    availableDays[availableMinDay - 1] = int.MaxValue;
                    jobsQueue.Enqueue(job);
                }
            }

            yield return jobsQueue.Sum(j => j.Salary);
        }
    }

    struct Job
    {
        public int Delay { get; }
        public int Salary { get; }

        public Job(int delay, int salary)
        {
            Delay = delay;
            Salary = salary;
        }

        public override string ToString() => $"Delay:{Delay}, Salary:{Salary}";
    }

    public class SegmentTree<T> : IEnumerable<T>
    {
        private readonly T[] _data;
        private readonly T _identityElement;
        private readonly Func<T, T, T> _queryOperation;

        private readonly int _leafOffset;   // n - 1
        private readonly int _leafLength;   // n (= 2^k)

        public int Length { get; }          // 実データ長

        public SegmentTree(ICollection<T> data, Func<T, T, T> queryOperation, T identityElement)
        {
            Length = data.Count;
            _leafLength = GetMinimumPow2(data.Count);
            _leafOffset = _leafLength - 1;
            _data = new T[_leafOffset + _leafLength];
            _queryOperation = queryOperation;
            _identityElement = identityElement;

            data.CopyTo(_data, _leafOffset);
            BuildTree();
        }

        public T this[int index]
        {
            set
            {
                index += _leafOffset;
                _data[index] = value;
                while (index > 0)
                {
                    // 一つ上の親の更新
                    index = (index - 1) / 2;
                    _data[index] = _queryOperation(_data[index * 2 + 1], _data[index * 2 + 2]);
                }
            }
        }

        public T Query(int begin, int end) => Query(begin, end, 0, 0, _leafLength);

        private T Query(int begin, int end, int index, int left, int right)
        {
            if (right <= begin || end <= left)      // 範囲外
            {
                return _identityElement;
            }
            else if (begin <= left && right <= end) // 全部含まれる
            {
                return _data[index];
            }
            else    // 一部だけ含まれる
            {
                var leftValue = Query(begin, end, index * 2 + 1, left, (left + right) / 2);     // 左の子
                var rightValue = Query(begin, end, index * 2 + 2, (left + right) / 2, right);   // 右の子
                return _queryOperation(leftValue, rightValue);
            }
        }

        private void BuildTree()
        {
            for (int i = _leafOffset + Length; i < _data.Length; i++)
            {
                _data[i] = _identityElement;
            }

            for (int i = _leafLength - 2; i >= 0; i--)  // 葉の親から順番に一つずつ上がっていく
            {
                _data[i] = _queryOperation(_data[2 * i + 1], _data[2 * i + 2]); // f(left, right)
            }
        }

        private int GetMinimumPow2(int n)
        {
            var p = 1;
            while (p < n)
            {
                p *= 2;
            }
            return p;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var upperIndex = _leafOffset + Length;
            for (int i = _leafOffset; i < upperIndex; i++)
            {
                yield return _data[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
