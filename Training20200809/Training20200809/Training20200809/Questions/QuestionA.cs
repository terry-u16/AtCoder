using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200809.Algorithms;
using Training20200809.Collections;
using Training20200809.Extensions;
using Training20200809.Numerics;
using Training20200809.Questions;
using System.Numerics;

namespace Training20200809.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nikuCount, toEat) = inputStream.ReadValue<int, int>();
            var nikus = new Niku[nikuCount];

            for (int i = 0; i < nikus.Length; i++)
            {
                var (x, y, c) = inputStream.ReadValue<int, int, int>();
                nikus[i] = new Niku(new Complex(x, y), c);
            }

            double GetYakinikuTime(Complex fire)
            {
                var yakinikuTime = nikus.Select(niku => niku.GetYakinikuTime(fire)).OrderBy(t => t).Skip(toEat - 1).First();
                return yakinikuTime;
            }

            double minTime = double.MaxValue;

            for (int i = 0; i < nikus.Length; i++)
            {
                var centerOne = nikus[i].Coordinate;
                minTime = Math.Min(minTime, GetYakinikuTime(centerOne));

                for (int j = i + 1; j < nikus.Length; j++)
                {
                    var centerTwo = Niku.GetCenter(nikus[i], nikus[j]);
                    minTime = Math.Min(minTime, GetYakinikuTime(centerTwo));

                    for (int k = j + 1; k < nikus.Length; k++)
                    {
                        var centerThree = Niku.GetCenter(nikus[i], nikus[j], nikus[k]);
                        minTime = Math.Min(minTime, GetYakinikuTime(centerThree));
                    }
                }
            }

            yield return minTime; 
        }


        [StructLayout(LayoutKind.Auto)]
        readonly struct Niku
        {
            public Complex Coordinate { get; }
            public double Weight { get; }

            public Niku(Complex coordinate, double weight)
            {
                Coordinate = coordinate;
                Weight = weight;
            }

            public static Complex GetCenter(Niku a, Niku b) => (a.Coordinate * a.Weight + b.Coordinate * b.Weight) / (a.Weight + b.Weight);

            public static Complex GetCenter(Niku a, Niku b, Niku c)
            {
                var center = (a.Coordinate * a.Weight + b.Coordinate * b.Weight + c.Coordinate * c.Weight) / (a.Weight + b.Weight + c.Weight);
                const double Eps = 1e-9;
                const double Ratio = 0.8;
                var nikus = new Niku[] { a, b, c };
                Span<double> distances = stackalloc double[3];

                while (true)
                {
                    for (int i = 0; i < distances.Length; i++)
                    {
                        distances[i] = nikus[i].GetYakinikuTime(center);
                    }

                    var minIndex = -1;
                    var maxIndex = -1;
                    var min = double.MaxValue;
                    var max = double.MinValue;

                    for (int i = 0; i < distances.Length; i++)
                    {
                        if (min > distances[i])
                        {
                            min = distances[i];
                            minIndex = i;
                        }
                        if (max < distances[i])
                        {
                            max = distances[i];
                            maxIndex = i;
                        }
                    }

                    var second = 0.0;
                    for (int i = 0; i < distances.Length; i++)
                    {
                        if (i != minIndex && i != maxIndex)
                        {
                            second = distances[i];
                        }
                    }

                    if (max - second < Eps)
                    {
                        break;
                    }
                    else
                    {
                        var diff = (nikus[maxIndex].Coordinate - center) * (max - second) / max * Ratio;
                        center += diff;
                    }
                }

                return center;
            }

            public double GetYakinikuTime(Complex fire) => Weight * (Coordinate - fire).Magnitude;

            public void Deconstruct(out Complex coordinate, out double weight) => (coordinate, weight) = (Coordinate, Weight);
            public override string ToString() => $"{nameof(Coordinate)}: {Coordinate}, {nameof(Weight)}: {Weight}";
        }
    }
}
