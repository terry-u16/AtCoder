using System;
using Xunit;
using Training20200808.Questions;
using System.Collections.Generic;
using System.Linq;
using Training20200808.Collections;

namespace Training20200808.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 2 1
1 2 1 2
1 3 2 4
1 11
1 2
2 5", @"2
14")]
        [InlineData(@"4 4 1
1 2 1 5
1 3 4 4
2 4 2 2
3 4 1 1
3 1
3 1
5 2
6 4", @"5
5
7")]
        [InlineData(@"6 5 1
1 2 1 1
1 3 2 1
2 4 5 1
3 5 11 1
1 6 50 1
1 10000
1 3000
1 700
1 100
1 1
100 1", @"1
9003
14606
16510
16576")]
        [InlineData(@"4 6 1000000000
1 2 50 1
1 3 50 5
1 4 50 7
2 3 50 2
2 4 50 4
3 4 50 3
10 2
4 4
5 5
7 7", @"1
3
5")]
        [InlineData(@"2 1 0
1 2 1 1
1 1000000000
1 1", @"1000000001")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10
1 2 5 3 4 6 7 3 2 4
1 2
2 3
3 4
4 5
3 6
6 7
1 8
8 9
9 10", @"1
2
3
3
4
4
5
2
2
3")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1
1000000000", @"999999993")]
        [InlineData(@"2
5 8", @"124")]
        [InlineData(@"5
52 67 72 25 79", @"269312")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
