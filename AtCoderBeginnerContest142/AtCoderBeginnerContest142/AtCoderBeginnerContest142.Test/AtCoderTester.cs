using System;
using Xunit;
using AtCoderBeginnerContest142.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest142.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4", @"0.5000000000")]
        [InlineData(@"5", @"0.6000000000")]
        [InlineData(@"1", @"1.0000000000")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            foreach (var pair in outputs.Zip(answers, (exp, act) => new { exp, act }))
            {
                NearlyEquals(double.Parse(pair.exp), double.Parse(pair.act));
            }
        }

        [Theory]
        [InlineData(@"4 150
150 140 100 200", @"2")]
        [InlineData(@"1 500
499", @"0")]
        [InlineData(@"5 1
100 200 300 400 500", @"5")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 3 1", @"3 1 2")]
        [InlineData(@"5
1 2 3 4 5", @"1 2 3 4 5")]
        [InlineData(@"8
8 2 7 3 4 5 6 1", @"8 2 4 5 6 7 3 1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"12 18", @"3")]
        [InlineData(@"420 660", @"4")]
        [InlineData(@"1 2019", @"1")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3
10 1
1
15 1
2
30 2
1 2", @"25")]
        [InlineData(@"12 1
100000 1
2", @"-1")]
        [InlineData(@"4 6
67786 3
1 3 4
3497 1
2
44908 3
2 3 4
2156 3
2 3 4
26230 1
2
86918 1
3", @"69942")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        void NearlyEquals(double expected, double actual, double error = 1e-6) => Assert.InRange(Math.Abs(actual - expected), 0, error);

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
