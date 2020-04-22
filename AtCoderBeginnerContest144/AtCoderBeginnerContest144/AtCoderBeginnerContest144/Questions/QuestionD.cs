using AtCoderBeginnerContest144.Questions;
using AtCoderBeginnerContest144.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest144.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        double a;
        double b;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abx = inputStream.ReadDoubleArray();
            a = abx[0];
            b = abx[1];
            var x = abx[2];

            yield return ToDegree(BinarySearch(theta => Volume(theta) - x, 0, Math.PI / 2 - double.Epsilon));
        }

        private double ToDegree(double radian) => radian * 180 / Math.PI;

        private double Volume(double theta)
        {
            if (a * Math.Tan(theta) <= b)
            {
                return a * a * (b - a * Math.Tan(theta) / 2);
            }
            else
            {
                return a * b * b / (Math.Tan(theta) * 2);
            }
        }

        private double BinarySearch(Func<double, double> func, double begin, double end)
        {
            const double epsilon = 1e-9;
            var fa = func(begin);
            var fb = func(end);

            if (fa == 0)
            {
                return begin;
            }
            else if (fb == 0)
            {
                return end;
            }

            while (end - begin > epsilon)
            {
                var x = (end + begin) / 2;
                
                var fx = func(x);
                if (fx * fa == 0)
                {
                    return x;
                }
                else if (fx * fa > 0)
                {
                    begin = x;
                    fa = func(begin);
                }
                else
                {
                    end = x;
                }
            }

            return (end + begin) / 2;
        }
    }
}
