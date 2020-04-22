using System;
using Xunit;
using AtCoderBeginnerContest144.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest144.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2 5", @"10")]
        [InlineData(@"5 10", @"-1")]
        [InlineData(@"9 9", @"81")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10", @"Yes")]
        [InlineData(@"50", @"No")]
        [InlineData(@"81", @"Yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10", @"5")]
        [InlineData(@"50", @"13")]
        [InlineData(@"10000000019", @"10000000018")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2 4", @"45.0000000000")]
        [InlineData(@"12 21 10", @"89.7834636934")]
        [InlineData(@"3 1 8", @"4.2363947991")]
        [InlineData(@"1 1 1", @"0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            foreach (var pair in outputs.Zip(answers, (exp, act) => new { exp, act }))
            {
                NearlyEquals(double.Parse(pair.exp), double.Parse(pair.act));
            }
        }

        [Theory]
        [InlineData(@"3 5
4 2 1
2 3 1", @"2")]
        [InlineData(@"3 8
4 2 1
2 3 1", @"0")]
        [InlineData(@"11 14
3 1 4 1 5 9 2 6 5 3 5
8 9 7 9 3 2 3 8 4 6 2", @"12")]
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
