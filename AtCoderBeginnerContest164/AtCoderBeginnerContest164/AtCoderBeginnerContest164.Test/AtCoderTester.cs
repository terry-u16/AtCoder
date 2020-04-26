using System;
using Xunit;
using AtCoderBeginnerContest164.Questions;
using System.Collections.Generic;
using System.Linq;
using AtCoderBeginnerContest164.Collections;

namespace AtCoderBeginnerContest164.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4 5", @"unsafe")]
        [InlineData(@"100 2", @"safe")]
        [InlineData(@"10 10", @"unsafe")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10 9 10 10", @"No")]
        [InlineData(@"46 4 40 5", @"Yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
apple
orange
apple", @"2")]
        [InlineData(@"5
grape
grape
grape
grape
grape", @"1")]
        [InlineData(@"4
aaaa
a
aaa
aa", @"4")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1817181712114", @"3")]
        [InlineData(@"14282668646", @"2")]
        [InlineData(@"2119", @"0")]
        [InlineData(@"1817118171", @"3")]
        [InlineData(@"181711817118171", @"6")]
        [InlineData(@"1817118171127197", @"6")]
        [InlineData(@"18171181711127197", @"4")]
        [InlineData(@"181711181711127197", @"3")]
        [InlineData(@"1817118171181712", @"6")]
        [InlineData(@"127197127197127197", @"6")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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

        void AssertNearlyEqual(IEnumerable<string> expected, IEnumerable<string> actual, double acceptableError = 1e-6)
        {
            Assert.Equal(expected.Count(), actual.Count());
            foreach (var (exp, act) in (expected, actual).Zip().Select(p => (double.Parse(p.v1), double.Parse(p.v2))))
            {
                var error = act - exp;
                Assert.InRange(Math.Abs(error), 0, acceptableError);
            }
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
