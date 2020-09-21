using System;
using Xunit;
using AtCoderBeginnerContest179.Questions;
using System.Collections.Generic;
using System.Linq;
using AtCoderBeginnerContest179.Collections;

namespace AtCoderBeginnerContest179.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"apple", @"apples")]
        [InlineData(@"bus", @"buses")]
        [InlineData(@"box", @"boxs")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1 2
6 6
4 4
3 3
3 2", @"Yes")]
        [InlineData(@"5
1 1
2 2
3 4
5 5
6 6", @"No")]
        [InlineData(@"6
1 1
2 2
3 3
4 4
5 5
6 6", @"Yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3", @"3")]
        [InlineData(@"100", @"473")]
        [InlineData(@"1000000", @"13969985")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2
1 1
3 4", @"4")]
        [InlineData(@"5 2
3 3
5 5", @"0")]
        [InlineData(@"5 1
1 2", @"5")]
        [InlineData(@"60 3
5 8
1 3
10 15", @"221823067")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 2 1001", @"1369")]
        [InlineData(@"1000 2 16", @"6")]
        [InlineData(@"10000000000 10 99959", @"492443256176507")]
        [InlineData(@"1000 0 10", @"0")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 5
1 3
2 3
1 4
2 2
1 2", @"1")]
        [InlineData(@"200000 0", @"39999200004")]
        [InlineData(@"176527 15
1 81279
2 22308
2 133061
1 80744
2 44603
1 170938
2 139754
2 15220
1 172794
1 159290
2 156968
1 56426
2 77429
1 97459
2 71282", @"31159505795")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = SplitByNewLine(question.Solve(input).Trim());

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
