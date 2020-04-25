using System;
using Xunit;
using AtCoderBeginnerContest138.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest138.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3200
pink", @"pink")]
        [InlineData(@"3199
pink", @"red")]
        [InlineData(@"4049
red", @"red")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
10 30", @"7.5")]
        [InlineData(@"3
200 200 200", @"66.66666666666667")]
        [InlineData(@"1
1000", @"1000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            foreach (var pair in outputs.Zip(answers, (exp, act) => new { exp, act }))
            {
                NearlyEquals(double.Parse(pair.exp), double.Parse(pair.act), 1e-5);
            }
        }

        [Theory]
        [InlineData(@"2
3 4", @"3.5")]
        [InlineData(@"3
500 300 200", @"375")]
        [InlineData(@"5
138 138 138 138 138", @"138")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            foreach (var pair in outputs.Zip(answers, (exp, act) => new { exp, act }))
            {
                NearlyEquals(double.Parse(pair.exp), double.Parse(pair.act), 1e-5);
            }
        }

        [Theory]
        [InlineData(@"4 3
1 2
2 3
2 4
2 10
1 100
3 1", @"100 110 111 110")]
        [InlineData(@"6 2
1 2
1 3
2 4
3 6
2 5
1 10
1 10", @"20 20 20 20 20 20")]
        [InlineData(@"3 3
1 3
2 3
2 10
3 100
1 1", @"1 111 101")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"contest
son", @"10")]
        [InlineData(@"contest
programming", @"-1")]
        [InlineData(@"contest
sentence", @"33")]
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
