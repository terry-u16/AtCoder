using System;
using Xunit;
using AtCoderBeginnerContest171.Questions;
using System.Collections.Generic;
using System.Linq;
using AtCoderBeginnerContest171.Collections;

namespace AtCoderBeginnerContest171.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"B", @"A")]
        [InlineData(@"a", @"a")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
50 100 80 120 80", @"210")]
        [InlineData(@"1 1
1000", @"1000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2", @"b")]
        [InlineData(@"27", @"aa")]
        [InlineData(@"123456789", @"jjddja")]
        [InlineData(@"26", @"z")]
        [InlineData(@"702", @"zz")]
        [InlineData(@"703", @"aaa")]
        [InlineData(@"475253", @"zzzy")]
        [InlineData(@"475254", @"zzzz")]
        [InlineData(@"475255", @"aaaaa")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1 2 3 4
3
1 2
3 4
2 4", @"11
12
16")]
        [InlineData(@"4
1 1 1 1
3
1 2
2 1
3 5", @"8
4
4")]
        [InlineData(@"2
1 2
3
1 100
2 100
100 1000", @"102
200
2000")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
20 11 9 24", @"26 5 7 22")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
oof", @"575111451")]
        [InlineData(@"37564
whydidyoudesertme", @"318008117")]
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
