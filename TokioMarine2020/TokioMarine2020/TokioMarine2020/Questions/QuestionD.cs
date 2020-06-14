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
    public class QuestionD : AtCoderQuestionBase
    {
        Dictionary<int, int[]> _knapsack;
        Goods[] _goods;
        const int maxCapacity = 100001;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            _goods = new Goods[n + 1];

            for (int i = 1; i < _goods.Length; i++)
            {
                var (v, w) = inputStream.ReadValue<int, int>();
                _goods[i] = new Goods(v, w);
            }

            _knapsack = new Dictionary<int, int[]>();

            var queries = inputStream.ReadInt();
            for (int q = 0; q < queries; q++)
            {
                var (node, capacity) = inputStream.ReadValue<int, int>();
                var values = GetKnapsackAt(node);
                yield return values[capacity];
            }
        }

        int[] GetKnapsackAt(int index)
        {
            if (index == 0)
            {
                var current = new int[maxCapacity];
                return current;
            }
            else if (!_knapsack.ContainsKey(index))
            {
                var current = new int[maxCapacity];
                var previous = GetKnapsackAt(index >> 1);

                for (int w = 0; w < current.Length; w++)
                {
                    current[w] = Math.Max(previous[w], current[w]);
                    var nextWeight = w + _goods[index].Weight;
                    if (nextWeight < current.Length)
                    {
                        current[nextWeight] = Math.Max(current[nextWeight], previous[w] + _goods[index].Value);
                    }
                }
                _knapsack[index] = current;
            }

            return _knapsack[index];
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
