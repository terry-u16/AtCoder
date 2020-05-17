using AtCoderBeginnerContest168.Algorithms;
using AtCoderBeginnerContest168.Collections;
using AtCoderBeginnerContest168.Questions;
using AtCoderBeginnerContest168.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Numerics;

namespace AtCoderBeginnerContest168.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (hourLength, minutesLength, hour, minutes) = inputStream.ReadValue<double, double, double, double>();
            var hourPosition = Complex.FromPolarCoordinates(hourLength, (hour + minutes / 60) / 12 * 2 * Math.PI);
            var minutesPosition = Complex.FromPolarCoordinates(minutesLength, minutes / 60 * 2 * Math.PI);
            yield return (hourPosition - minutesPosition).Magnitude;
        }
    }
}
