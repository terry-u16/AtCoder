using System;
using Xunit;
using AtCoderBeginnerContest177.Questions;
using System.Collections.Generic;
using System.Linq;
using AtCoderBeginnerContest177.Collections;

namespace AtCoderBeginnerContest177.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1000 15 80", @"Yes")]
        [InlineData(@"2000 20 100", @"Yes")]
        [InlineData(@"10000 1 1", @"No")]
        [InlineData(@"100 9 11", @"No")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"cabacc
abc", @"1")]
        [InlineData(@"codeforces
atcoder", @"6")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 3", @"11")]
        [InlineData(@"4
141421356 17320508 22360679 244949", @"437235829")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
1 2
3 4
5 1", @"3")]
        [InlineData(@"4 10
1 2
2 1
1 2
2 1
1 2
1 3
1 4
2 3
2 4
3 4", @"4")]
        [InlineData(@"10 4
3 1
4 1
5 9
2 6", @"3")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3 4 5", @"pairwise coprime")]
        [InlineData(@"3
6 10 15", @"setwise coprime")]
        [InlineData(@"3
6 10 16", @"not coprime")]
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
