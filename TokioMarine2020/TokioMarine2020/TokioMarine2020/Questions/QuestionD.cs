using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TokioMarine2020.Algorithms;
using TokioMarine2020.Collections;
using TokioMarine2020.Extensions;
using TokioMarine2020.Numerics;
using TokioMarine2020.Questions;

namespace TokioMarine2020.Questions
{
    /// <summary>
    /// 復習
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        int[,] _values;
        Goods[] _goods;
        const int maxCapacity = 100000;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            _goods = new Goods[n + 1];

            for (int i = 1; i < _goods.Length; i++)
            {
                var (v, w) = inputStream.ReadValue<int, int>();
                _goods[i] = new Goods(v, w);
            }

            var halfPow2 = GetHalfPow2(n);
            Initialize(1 << halfPow2);

            var queries = inputStream.ReadInt();
            for (int q = 0; q < queries; q++)
            {
                var (node, capacity) = inputStream.ReadValue<int, int>();
                yield return GetValueAt(node, capacity);
            }
        }

        int GetHalfPow2(int n)
        {
            int pow;
            for (pow = 0; (1 << pow) < n; pow++) { }
            return (pow + 1) / 2 + (pow >= 5 ? 1 : 0);
        }

        void Initialize(int halfN)
        {
            _values = new int[halfN, maxCapacity + 1];

            for (int i = 1; i < halfN; i++)
            {
                for (int w = 0; w <= maxCapacity; w++)
                {
                    AlgorithmHelpers.UpdateWhenLarge(ref _values[i, w], _values[i >> 1, w]);

                    var nextWeight = w + _goods[i].Weight;
                    if (nextWeight <= maxCapacity)
                    {
                        AlgorithmHelpers.UpdateWhenLarge(ref _values[i, nextWeight], _values[i >> 1, w] + _goods[i].Value);
                    }
                }
            }
        }

        int GetValueAt(int index, int capacity)
        {
            if (index < _values.GetLength(0))
            {
                return _values[index, capacity];
            }
            else
            {
                var nextIndex = index >> 1;
                var value = 0;
                AlgorithmHelpers.UpdateWhenLarge(ref value, GetValueAt(nextIndex, capacity));
                var nextCapacity = capacity - _goods[index].Weight;
                if (nextCapacity >= 0)
                {
                    AlgorithmHelpers.UpdateWhenLarge(ref value, GetValueAt(nextIndex, nextCapacity) + _goods[index].Value);
                }
                return value;
            }
        }

        struct Goods
        {
            public int Value { get; }
            public int Weight { get; }

            public Goods(int value, int weight)
            {
                Value = value;
                Weight = weight;
            }
        }
    }
}
