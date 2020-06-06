using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    public class QuestionL : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var columnCount = inputStream.ReadInt();
            var foodsStocks = Enumerable.Range(0, columnCount).Select(_ => new Queue<Food>()).ToArray();
            var availableFoods = Enumerable.Range(0, 2).Select(_ => new PriorityQueue<Food>(true)).ToArray();
            var bought = new SortedSet<Food>();

            for (int column = 0; column < columnCount; column++)
            {
                var input = inputStream.ReadIntArray();
                foreach (var expired in input.Skip(1))
                {
                    foodsStocks[column].Enqueue(new Food(column, expired));
                }

                var food = foodsStocks[column].Dequeue();
                availableFoods[0].Enqueue(food);
                availableFoods[1].Enqueue(food);
                if (foodsStocks[column].Count > 0)
                {
                    var nextFood = foodsStocks[column].Peek();
                    availableFoods[1].Enqueue(nextFood);
                }
            }

            var customersCount = inputStream.ReadInt();
            var views = inputStream.ReadIntArray();

            for (int customer = 0; customer < customersCount; customer++)
            {
                if (views[customer] == 1 || availableFoods[1].Count == 0)
                {
                    Food next;

                    while (true)
                    {
                        next = availableFoods[0].Peek();
                        if (!bought.Contains(next))
                        {
                            break;
                        }
                        _ = availableFoods[0].Dequeue();
                    }

                    bought.Add(next);
                    yield return next.Expired;

                    if (foodsStocks[next.Column].Count > 0)
                    {
                        availableFoods[0].Enqueue(foodsStocks[next.Column].Dequeue());
                    }
                    if (foodsStocks[next.Column].Count > 0)
                    {
                        availableFoods[1].Enqueue(foodsStocks[next.Column].Peek());
                    }
                }
                else
                {
                    var nextTwo = new Food[2];
                    nextTwo[0] = availableFoods[0].Peek();

                    for (int i = 0; i < 2; i++)
                    {
                        while (true)
                        {
                            nextTwo[i] = availableFoods[i].Peek();
                            if (!bought.Contains(nextTwo[i]))
                            {
                                break;
                            }
                            _ = availableFoods[i].Dequeue();
                        }
                    }

                    if (nextTwo[0].CompareTo(nextTwo[1]) > 0)
                    {
                        var next = availableFoods[0].Dequeue();
                        bought.Add(next);
                        yield return next.Expired;

                        if (foodsStocks[next.Column].Count > 0)
                        {
                            availableFoods[0].Enqueue(foodsStocks[next.Column].Dequeue());
                        }
                        if (foodsStocks[next.Column].Count > 0)
                        {
                            availableFoods[1].Enqueue(foodsStocks[next.Column].Peek());
                        }
                    }
                    else
                    {
                        var next = availableFoods[1].Dequeue();
                        bought.Add(next);
                        yield return next.Expired;

                        if (foodsStocks[next.Column].Count > 0)
                        {
                            availableFoods[0].Enqueue(foodsStocks[next.Column].Dequeue());
                        }
                        if (foodsStocks[next.Column].Count > 0)
                        {
                            availableFoods[1].Enqueue(foodsStocks[next.Column].Peek());
                        }

                    }
                }
            }
        }

        readonly struct Food : IComparable<Food>, IEquatable<Food>
        {
            public int Column { get; }
            public int Expired { get; }

            public Food(int type, int expired)
            {
                Column = type;
                Expired = expired;
            }

            public override string ToString() => $"Type:{Column}, Expired:{Expired}";

            public int CompareTo([AllowNull] Food other) => Expired.CompareTo(other.Expired);

            public override bool Equals(object obj)
            {
                return obj is Food food && Equals(food);
            }

            public bool Equals(Food other)
            {
                return Column == other.Column &&
                       Expired == other.Expired;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Column, Expired);
            }

            public static bool operator ==(Food left, Food right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Food left, Food right)
            {
                return !(left == right);
            }
        }
    }
}
