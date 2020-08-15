using System;
using Xunit;
using AtCoderBeginnerContest175.Questions;
using System.Collections.Generic;
using System.Linq;
using AtCoderBeginnerContest175.Collections;

namespace AtCoderBeginnerContest175.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"RRS", @"2")]
        [InlineData(@"SSS", @"0")]
        [InlineData(@"RSR", @"1")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
4 4 9 7 5", @"5")]
        [InlineData(@"6
4 5 4 3 3 5", @"8")]
        [InlineData(@"10
9 4 6 1 9 6 10 6 6 8", @"39")]
        [InlineData(@"2
1 1", @"0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 2 4", @"2")]
        [InlineData(@"7 4 3", @"1")]
        [InlineData(@"10 1 2", @"8")]
        [InlineData(@"1000000000000000 1000000000000000 1000000000000000", @"1000000000000000")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2
2 4 5 1 3
3 4 -10 -8 8", @"8")]
        [InlineData(@"2 3
2 1
10 -7", @"13")]
        [InlineData(@"3 3
3 1 2
-1000 -2000 -3000", @"-1000")]
        [InlineData(@"10 58
9 1 6 7 8 4 3 2 10 5
695279662 988782657 -119067776 382975538 -151885171 -177220596 -169777795 37619092 389386780 980092719", @"29507023469")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2 3
1 1 3
2 1 4
1 2 5", @"8")]
        [InlineData(@"2 5 5
1 1 3
2 4 20
1 2 1
1 3 4
1 4 2", @"29")]
        [InlineData(@"4 5 10
2 5 12
1 5 12
2 3 15
1 2 20
1 1 28
2 4 26
3 2 27
4 5 21
3 5 10
1 3 10", @"142")]
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
